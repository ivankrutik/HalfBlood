// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableCuttingOrderSpecificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditableCuttingOrderSpecificationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.CuttingOrderDomain.CuttingOrderSpecificationDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Entities.CuttingOrderDomain;

    using FluentValidation;

    using Halfblood.Common.Mappers;

    using ReactiveUI;
    
    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CuttingOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    /// <summary>
    /// The editable cutting order specification view model.
    /// </summary>
    [Export(typeof(IEditableCuttingOrderSpecificationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditableCuttingOrderSpecificationViewModel
        : PolicyEditableViewModelBase<CuttingOrderSpecification>, IEditableCuttingOrderSpecificationViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        [ImportingConstructor]
        public EditableCuttingOrderSpecificationViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus,
            IValidatorFactory validatorFactory)
            : base(screen, messageBus, validatorFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public string UrlPathSegment
        {
            get { return "/EditableCuttingOrderSpecificationView"; }
        }

        protected override void ApplyAction(CuttingOrderSpecification cuttingOrderSpecification)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ICuttingOrderService>();
                if (EditState == EditState.Edit)
                {
                    service.UpdateCuttingOrderSpecification(cuttingOrderSpecification.MapTo<CuttingOrderSpecificationDto>());
                }
                else
                {
                    service.AddCuttingOrderSpecification(cuttingOrderSpecification.MapTo<CuttingOrderSpecificationDto>());
                }

                unitOfWork.Commit();
            }
        }
    }
}
