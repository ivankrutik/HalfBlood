// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AddPlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;

    using FluentValidation;

    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CommonDomain;

    using ReactiveUI;
    
    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IEditablePlanReceiptOrderViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditablePlanReceiptOrderViewModel : PolicyEditableViewModelBase<PlanReceiptOrder>,
                                                     IEditablePlanReceiptOrderViewModel
    {
        #region private fields
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private IFilterViewModel<UserFilter, UserDto> _userContractorFilterViewModel;
        private IFilterViewModel<StoreGasStationOilDepotFilter, StoreLiteDto> _gasStationOilDepotFilterViewModel;
        private IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> _groundReceiptTypeOfDocumentFilterViewModel;
        private IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> _groundDocTypeOfDocumentFilterViewModel;
        #endregion

        ~EditablePlanReceiptOrderViewModel()
        {
            LogManager.Log.Debug("EditablePlanReceiptOrderViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public EditablePlanReceiptOrderViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
            GroundDocTypeOfDocumentFilterViewModel.InvokeCommand.Execute(null);
            GroundReceiptTypeOfDocumentFilterViewModel.InvokeCommand.Execute(null);
            GasStationOilDepotFilterViewModel.InvokeCommand.Execute(null);
        }

        public string UrlPathSegment
        {
            get { return "/EditablePlanReceiptOrder"; }
        }
        public IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> GroundReceiptTypeOfDocumentFilterViewModel
        {
            get
            {
                return this._groundReceiptTypeOfDocumentFilterViewModel
                       ?? (this._groundReceiptTypeOfDocumentFilterViewModel =
                           this._filterViewModelFactory.Create<TypeOfDocumentFilter, TypeOfDocumentDto>());
            }
        }
        public IFilterViewModel<UserFilter, UserDto> UserContractorFilterViewModel
        {
            get
            {
                return this._userContractorFilterViewModel
                       ?? (this._userContractorFilterViewModel =
                           this._filterViewModelFactory.Create<UserFilter, UserDto>());
            }
        }
        public IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> GroundDocTypeOfDocumentFilterViewModel
        {
            get
            {
                return this._groundDocTypeOfDocumentFilterViewModel
                       ?? (this._groundDocTypeOfDocumentFilterViewModel =
                           this._filterViewModelFactory.Create<TypeOfDocumentFilter, TypeOfDocumentDto>());
            }
        }
        public IFilterViewModel<StoreGasStationOilDepotFilter, StoreLiteDto> GasStationOilDepotFilterViewModel
        {
            get
            {
                return this._gasStationOilDepotFilterViewModel
                       ?? (this._gasStationOilDepotFilterViewModel =
                           this._filterViewModelFactory.Create<StoreGasStationOilDepotFilter, StoreLiteDto>());
            }
        }

        protected override void ApplyAction(PlanReceiptOrder planReceiptOrder)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                if (EditState == EditState.Edit)
                {
                    service.UpdatePlanReceiptOrder(planReceiptOrder.MapTo<PlanReceiptOrderDto>());
                }
                else
                {
                    var addedEntity = service.AddPlanReceiptOrder(planReceiptOrder.MapTo<PlanReceiptOrderDto>());
                    EditableObject.Rn = addedEntity.Rn;
                    EditableObject.Numb = addedEntity.Numb;
                    EditableObject.Pref = addedEntity.Pref;
                    EditableObject.UserCreator = addedEntity.UserCreator == null
                                                     ? null
                                                     : addedEntity.UserCreator.MapTo<User>();
                }

                unitOfWork.Commit();
            }
        }
    }
}