// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderMainViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The posting of inventory at the warehouse view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Pages
{
    using System.ComponentModel.Composition;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// The posting of inventory at the warehouse view model.
    /// </summary>
    [Export(typeof(ICuttingOrderMainViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CuttingOrderMainViewModel : ReactiveObject, ICuttingOrderMainViewModel
    {
        private readonly IRoutableViewModelManager routableViewModelManager;
        private ICuttingOrderViewModel _cuttingOrderViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderMainViewModel"/> class.
        /// </summary>
        /// <param name="screen">
        /// The screen.
        /// </param>
        /// <param name="routableViewModelManager">
        /// The view model manager.
        /// </param>
        [ImportingConstructor]
        public CuttingOrderMainViewModel(IScreen screen, IRoutableViewModelManager routableViewModelManager)
        {
            this.routableViewModelManager = routableViewModelManager;
            HostScreen = screen;
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
            get { return "/CuttingOrderMainView"; }
        }

        /// <summary>
        /// Gets the cutting order view model.
        /// </summary>
        public ICuttingOrderViewModel CuttingOrderViewModel
        {
            get
            {
                return _cuttingOrderViewModel
                       ?? (_cuttingOrderViewModel = this.routableViewModelManager.Get<ICuttingOrderViewModel>());
            }
        }
    }
}
