// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditablePersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PersonalAccountDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;
    using FluentValidation;
    using Halfblood.Common;
    using Halfblood.Common.Mappers;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.ContractDomain;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    /// <summary>
    /// The editable personal account view model.
    /// </summary>
    [Export(typeof(IEditablePersonalAccountViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePersonalAccountViewModel
        : EditableViewModelBase<PlanReceiptOrderPersonalAccount>, IEditablePersonalAccountViewModel
    {
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private UserDto _userContractor;
        private string _measure;

        [ImportingConstructor]
        public EditablePersonalAccountViewModel(
            IScreen screen,
            IMessageBus messageBus,
            IUnitOfWorkFactory unitOfWork,
            IFilterViewModelFactory filterViewModelFactory,
            IRoutableViewModelManager routableViewModelManager,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _filterViewModelFactory = filterViewModelFactory;
            _unitOfWorkFactory = unitOfWork;
            PersonalAccountFilterViewModel = _filterViewModelFactory.Create<PersonalAccountFilter, PersonalAccountDto>();
            ContractViewModel = routableViewModelManager.Get<IContractViewModel>();

            this.WhenAny(x => x.UserContractor, x => x.Value)
                .Where(x => x != null)
                .Subscribe(x =>
                {
                    ContractViewModel.ContractFilterViewModel.SetFilter(new ContractFilter { Contaractor = x ,State=ContractStatusState.Approved});
                    ContractViewModel.StagesOfTheContractFilterViewModel.SetFilter(new StagesOfTheContractFilter { State=StageStatusState.Open});
                    ContractViewModel.ContractFilterViewModel.InvokeCommand.Execute(null);
                });
        }

        public string UrlPathSegment
        {
            get { return "/EditPersonalAccountViewModel"; }
        }
        public UserDto UserContractor
        {
            get { return _userContractor; }
            set { this.RaiseAndSetIfChanged(ref _userContractor, value); }
        }
        public string Measure
        {
            get { return _measure; }
            set { this.RaiseAndSetIfChanged(ref _measure, value); }
        }
        public IFilterViewModel<PersonalAccountFilter, PersonalAccountDto> PersonalAccountFilterViewModel { get; private set; }
        public IContractViewModel ContractViewModel { get; private set; }

        protected override void ApplyAction(PlanReceiptOrderPersonalAccount editObject)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                if (EditState == EditState.Edit)
                {
                    service.UpdatePersonalAccount(editObject.MapTo<PlanReceiptOrderPersonalAccountDto>());
                }
                else
                {
                    EditableObject.Rn =
                        service.AddPlanReceiptOrderPersonalAccount(
                            editObject.MapTo<PlanReceiptOrderPersonalAccountDto>()).Rn;
                }

                unitOfWork.Commit();
            }
        }
        protected override IObservable<bool> CanExecute(IObservable<bool> validateObservable)
        {
            IObservable<bool> secondObservable =
                EditableObject.WhenAny(x => x.PersonalAccount, x => x.Value).Select(x => x != null && x.Rn > 0);

            return validateObservable.CombineLatest(secondObservable, (left, right) => left && right);
        }
    }
}