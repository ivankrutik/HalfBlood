// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ContractViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.ContractDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Filters;

    using ParusModelLite.ContractDomain;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.ContractDomain;
    using UI.Infrastructure.ViewModels.Filters;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IContractViewModel))]
    public class ContractViewModel : ReactiveObject, IContractViewModel
    {
        #region private fields
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private ContractLiteDto _selectedSContract;
        private StagesOfTheContractLiteDto _selectedStagesOfTheContract;
        private IFilterViewModel<ContractFilter, ContractLiteDto> _contractFilterViewModel;
        private IFilterViewModel<StagesOfTheContractFilter, StagesOfTheContractLiteDto> _stagesOfTheContractFilterViewModel;
        private IFilterViewModel<PlanAndSpecificationFilter, PlanAndSpecificationLiteDto> _planAndSpecificationFilterViewModel;
        private bool _isBusy;
       
        
        #endregion
        [ImportingConstructor]
        public ContractViewModel(
            IScreen screen,
            IFilterViewModelFactory filterViewModelFactory)
        {
            _filterViewModelFactory = filterViewModelFactory;
            HostScreen = screen;
        }

        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "/ContractView"; }
        }

        public IFilterViewModel<ContractFilter, ContractLiteDto> ContractFilterViewModel
        {
            get
            {
                return this._contractFilterViewModel
                       ?? (this._contractFilterViewModel =
                           this._filterViewModelFactory.Create<ContractFilter, ContractLiteDto>());
            }
        }
        public IFilterViewModel<StagesOfTheContractFilter, StagesOfTheContractLiteDto> StagesOfTheContractFilterViewModel
        {
            get
            {
                return this._stagesOfTheContractFilterViewModel
                       ?? (this._stagesOfTheContractFilterViewModel =
                           this._filterViewModelFactory.Create<StagesOfTheContractFilter, StagesOfTheContractLiteDto>());
            }
        }
        public IFilterViewModel<PlanAndSpecificationFilter, PlanAndSpecificationLiteDto> PlanAndSpecificationFilterViewModel
        {
            get
            {
                return this._planAndSpecificationFilterViewModel
                       ?? (this._planAndSpecificationFilterViewModel =
                           this._filterViewModelFactory.Create<PlanAndSpecificationFilter, PlanAndSpecificationLiteDto>());
            }
        }
        public ContractLiteDto SelectedSContract
        {
            get { return _selectedSContract; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSContract, value);
                OnSelectedContract(value);
                PlanAndSpecificationFilterViewModel.Result.Clear();
            }
        }
        public StagesOfTheContractLiteDto SelectedStagesOfTheContract
        {
            get { return _selectedStagesOfTheContract; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedStagesOfTheContract, value);
                OnSelectedStagesOfTheContract(value);
            }
        }

        private void OnSelectedContract(ContractLiteDto contractDto)
        {
            if (contractDto == null)
            {
                return;
            }

            StagesOfTheContractFilterViewModel.Filter.RnContract = SelectedSContract.Rn;
            StagesOfTheContractFilterViewModel.InvokeCommand.Execute(null);
        }
        private void OnSelectedStagesOfTheContract(StagesOfTheContractLiteDto stagesOfTheContract)
        {
            if (stagesOfTheContract == null)
            {
                return;
            }

            PlanAndSpecificationFilterViewModel.Filter.PersonalAccount.Rn = stagesOfTheContract.PersonalAccountRN;
            PlanAndSpecificationFilterViewModel.InvokeCommand.Execute(null);
        }
    }
}
