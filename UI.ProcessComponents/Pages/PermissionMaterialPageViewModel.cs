// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionMaterialPageViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PermissionMaterialPageViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Pages
{
    using System.ComponentModel.Composition;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;

    [Export(typeof(IPermissionMaterialPageViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PermissionMaterialPageViewModel : ReactiveObject, IPermissionMaterialPageViewModel
    {
        private readonly IRoutableViewModelManager routableViewModelManager;
        private IPermissionMaterialViewModel _permissionMaterialViewModel;

        [ImportingConstructor]
        public PermissionMaterialPageViewModel(
            IScreen screen, 
            IRoutableViewModelManager routableViewModelManager)
        {
            this.routableViewModelManager = routableViewModelManager;
            HostScreen = screen;
        }

        /// <summary>
        /// Gets the plan certificate view model.
        /// </summary>
        public IPermissionMaterialViewModel PermissionMaterialViewModel
        {
            get
            {
                return _permissionMaterialViewModel
                       ?? (_permissionMaterialViewModel = this.routableViewModelManager.Get<IPermissionMaterialViewModel>());
            }
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
            get { return "/PermissionMaterialPageView"; }
        }
    }
}
