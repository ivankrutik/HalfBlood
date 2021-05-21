// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderFilterViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels.CuttingOrderDomain
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Buisness.Filters;

    using Halfblood.Common.Mappers;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CuttingOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(ICuttingOrderFilterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderFilterViewModel
        : FilterViewModelBase<CuttingOrderFilter, CuttingOrder>, ICuttingOrderFilterViewModel
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderFilterViewModel"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">
        /// The unit of work factory.
        /// </param>
        [ImportingConstructor]
        public CuttingOrderFilterViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            Filter = CuttingOrderFilter.Default;
        }

        /// <summary>
        /// The do load.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        protected override IList<CuttingOrder> DoLoad()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ICuttingOrderService>();
                return service.GetCuttingOrderForView(Filter).MapTo<CuttingOrder>();
            }
        }
    }
}
