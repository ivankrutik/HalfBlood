namespace UI.ProcessComponents.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Filters;
    using EditViewModels;
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

    [Export(typeof(IEditablePermissionMaterialViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePermissionMaterialViewModel : PolicyEditableViewModelBase<PermissionMaterial>, IEditablePermissionMaterialViewModel
    {
        #region private
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private long _rnCertificateQuality;
        private EmployeeDto _selectedEmployee;
        private PermissionMaterialUser _selectedDgPermisMatUser;
        private ReactiveCommand _preparingForAddingPermisMatUserCommand;
        private ReactiveCommand _preparingForRemovePermisMatUserCommand;
        private IFilterViewModel<EmployeeFilter, EmployeeDto> _employeeFilterViewModel;
        #endregion

        [ImportingConstructor]
        public EditablePermissionMaterialViewModel(
            IFilterViewModelFactory filterViewModelFactory,
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IValidatorFactory validatorFactory,
            IMessageBus messageBus,
            IGetCatalogAccess getCatalogAccess)
            : base(screen, messageBus, validatorFactory)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
        }


        public string UrlPathSegment
        {
            get { return "/EditablePermissionMaterialView"; }
        }

        public long RnCertificateQuality
        {
            get { return _rnCertificateQuality; }
            set { this.RaiseAndSetIfChanged(ref _rnCertificateQuality, value); }
        }

        // selected ==================================================================================
        public EmployeeDto SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { this.RaiseAndSetIfChanged(ref _selectedEmployee, value); }
        }
        public PermissionMaterialUser SelectedDgPermisMatUser
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


        // save pm and pmu ===========================================================================
        protected override void ApplyAction(PermissionMaterial permissionMaterial)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPermissionMaterialService>();

                //обновляем udo_permismat
                if (EditState == EditState.Edit)
                {
                    service.UpdatePermissionMaterial(permissionMaterial.MapTo<PermissionMaterialDto>());
                }
                else
                {
                    var entity = service.AddPermissionMaterial(permissionMaterial.MapTo<PermissionMaterialDto>());
                    service.SetDocumentLinks(RnCertificateQuality, entity.Rn);
                }

                unitOfWork.Commit();
            }
        }


        // add pmu ===================================================================================
        public ICommand PreparingForAddingPermissionMaterialCommand
        {
            get
            {
                if (_preparingForAddingPermisMatUserCommand != null) return _preparingForAddingPermisMatUserCommand;

                // нада добить это о_О если запись повторяется, то кнопка добавить должна быть не активна
                //
                //var observable =
                //    Observable.Merge(
                //        ((ReactiveList<PermissionMaterialUserDto>)PermissionMaterialUserFilterViewModel.Result)
                //            .CountChanged.Select(_ => Unit.Default),
                //        this.WhenAnyValue(x => x.SelectedEmployee).Select(_ => Unit.Default))
                //        .Select(_ => SelectedEmployee != null && SelectedEmployee.Rn != 0
                //                     &&
                //                     PermissionMaterialUserFilterViewModel.Result.All(x => x.RnUser != SelectedEmployee.Rn))
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
                            EditableObject.PmUsers.Add(result);
                        }
                        else
                        {
                            UserError.Throw("Указанный сотрудник уже присутствует в списке людей для согласования.");
                        }
                    });

            return command;
        }
        protected PermissionMaterialUser AddPermisMatUser()
        {
            var duplicateRow = EditableObject.PmUsers.Where(x => x.RnUser == SelectedEmployee.Rn);
            if (duplicateRow.Any()) return null;

            var pmUser = new PermissionMaterialUser
            {
                PermissionMaterial = EditableObject,
                RnUser = SelectedEmployee.Rn,
                Fullname = SelectedEmployee.Fullname,
                UserPsdepName = SelectedEmployee.PsdepName,
                UserDept = SelectedEmployee.Dept
            };

            return pmUser;
        }


        // remove pmu ================================================================================
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

            command.RegisterAsyncFunction(_ => RemovePermisMatUser())
                .Subscribe(
                    result =>
                    {
                        if (result != null)
                        {
                            EditableObject.PmUsers.Remove(result);
                        }
                        else
                        {
                            UserError.Throw("Не удалось удалить сотрудника из списка лиц для согласования.");
                        }
                    }
                    );

            return command;
        }
        protected PermissionMaterialUser RemovePermisMatUser()
        {
            return SelectedDgPermisMatUser;
        }
    }

}