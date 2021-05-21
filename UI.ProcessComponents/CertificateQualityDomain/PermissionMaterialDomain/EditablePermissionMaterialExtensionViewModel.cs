namespace UI.ProcessComponents.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Filters;
    using FluentValidation;
    using Halfblood.Common.Mappers;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using UI.Entities.PermissionMaterialDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IEditablePermissionMaterialExtensionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePermissionMaterialExtensionViewModel
        : EditableViewModelBase<PermissionMaterialExtension>, IEditablePermissionMaterialExtensionViewModel
    {
        #region private
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private EmployeeDto _selectedEmployee;
        private PermissionMaterialExtensionUser _selectedDgPermisMatUser;
        private ReactiveCommand _preparingForAddingPermisMatUserCommand;
        private ReactiveCommand _preparingForRemovePermisMatUserCommand;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeFilterViewModel;
        #endregion

        [ImportingConstructor]
        public EditablePermissionMaterialExtensionViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IRoutableViewModelManager routableViewModelManager,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
        }


        public string UrlPathSegment
        {
            get { return "/EditablePermissionMaterialExtensionView"; }
        }


        // selected ==================================================================================
        public EmployeeDto SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployee, value); }
        }
        public PermissionMaterialExtensionUser SelectedDgPermisMatUser
        {
            get { return _selectedDgPermisMatUser; }
            set { this.RaiseAndSetIfChanged(ref _selectedDgPermisMatUser, value); }
        }


        // filters ===================================================================================
        public IFilterViewModel<EmployeeFilter, EmployeeDto> EmployeeFilterViewModel
        {
            get
            {
                return _employeeFilterViewModel
                       ?? (_employeeFilterViewModel =
                           _filterViewModelFactory.Create<EmployeeFilter, EmployeeDto>());
            }
        }


        // save pme and pmeu ==========================================================================
        protected override void ApplyAction(PermissionMaterialExtension permissionMaterialExtension)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPermissionMaterialService>();

                //обновляем udo_permismatex
                if (EditState == EditState.Edit)
                {
                    service.UpdatePermissionMaterialExtension(permissionMaterialExtension.MapTo<PermissionMaterialExtensionDto>());
                }
                else
                {
                    service.AddPermissionMaterialExtension(permissionMaterialExtension.MapTo<PermissionMaterialExtensionDto>());
                }

                unitOfWork.Commit();
            }
        }


        // add pmeu ===================================================================================
        public ICommand PreparingForAddingPermissionMaterialCommand
        {
            get
            {
                if (_preparingForAddingPermisMatUserCommand != null) return _preparingForAddingPermisMatUserCommand;

                // нада добить это о_О если запись повторяется, то кнопка добавить должна быть не активна
                //
                //var observable =
                //    Observable.Merge(
                //        ((ReactiveList<PermissionMaterialExtensionUserDto>)PermissionMaterialExUserFilterViewModel.Result)
                //            .CountChanged.Select(_ => Unit.Default),
                //        this.WhenAnyValue(x => x.SelectedEmployee).Select(_ => Unit.Default))
                //        .Select(_ => SelectedEmployee != null && SelectedEmployee.Rn != 0
                //                     &&
                //                     PermissionMaterialExUserFilterViewModel.Result.All(x => x.RnUser != SelectedEmployee.Rn))
                //        .StartWith(SelectedEmployee != null && SelectedEmployee.Rn > 0);

                var observable =
                    this.WhenAny(x => x.SelectedEmployee, x => x.Value)
                        .Select(x => x != null && x.Rn != 0)
                        .StartWith(SelectedEmployee != null);

                _preparingForAddingPermisMatUserCommand = CreateCommandAddPermisMatUser(observable);

                return _preparingForAddingPermisMatUserCommand;
            }
        }
        private ReactiveCommand CreateCommandAddPermisMatUser(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(_ => AddPermisMatUser())
                .Subscribe(
                    result =>
                    {
                        if (result != null)
                        {
                            EditableObject.PmeUsers.Add(result);
                        }
                        else
                        {
                            UserError.Throw("Указанный сотрудник уже присутствует в списке людей для согласования.");
                        }
                    });

            return command;
        }
        protected PermissionMaterialExtensionUser AddPermisMatUser()
        {
            var duplicateRow = EditableObject.PmeUsers.Where(x => x.RnUser == SelectedEmployee.Rn);
            if (duplicateRow.Any()) return null;

            var pmeUser = new PermissionMaterialExtensionUser
                {
                    PermissionMaterialExtension = EditableObject,
                    RnUser = SelectedEmployee.Rn,
                    Fullname = SelectedEmployee.Fullname,
                    UserPsdepName = SelectedEmployee.PsdepName,
                    UserDept = SelectedEmployee.Dept
                };

            return pmeUser;
        }


        // remove pmeu ================================================================================
        public ICommand PreparingForRemovingPermisMatUserCommand
        {
            get
            {
                if (_preparingForRemovePermisMatUserCommand != null) return _preparingForRemovePermisMatUserCommand;

                var observable =
                    this.WhenAny(x => x.SelectedDgPermisMatUser, x => x.Value)
                        .Select(x => x != null && x.RnUser != 0)
                        .StartWith(SelectedDgPermisMatUser != null);
                _preparingForRemovePermisMatUserCommand = CreateCommandRemovePermisMatUser(observable);

                return _preparingForRemovePermisMatUserCommand;
            }
        }
        private ReactiveCommand CreateCommandRemovePermisMatUser(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsyncFunction(_ => RemovePermisMatExUser())
               .Subscribe(
                    result =>
                    {
                        if (result != null)
                        {
                            EditableObject.PmeUsers.Remove(result);
                        }
                        else
                        {
                            UserError.Throw("Не удалось удалить сотрудника из списка лиц для согласования.");
                        }
                    }
                    );

            return command;
        }
        protected PermissionMaterialExtensionUser RemovePermisMatExUser()
        {
            return SelectedDgPermisMatUser;
        }
    }
}