// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PROFilterViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace UI.ProcessComponents.FilterViewModels.CertificateQualityDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Filters;

    using Halfblood.Common.Log;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IProFilterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProFilterViewModel : GenericFilterViewModel<PlanReceiptOrderFilter, PlanReceiptOrderLiteDto>, 
                                      IProFilterViewModel
    {
        ~ProFilterViewModel()
        {
            LogManager.Log.Debug("ProFilterViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public ProFilterViewModel(IScreen screen, IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            HostScreen = screen;
            Filter = PlanReceiptOrderFilter.Default;
        }

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
    }
}