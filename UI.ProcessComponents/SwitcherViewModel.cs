// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitcherViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the SwitcherViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The switcher view model.
    /// </summary>
    [Export(typeof(ISwitcherViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SwitcherViewModel : ReactiveObject, ISwitcherViewModel
    {
        private readonly IRoutableViewModelManager _viewModelManager;
        private ReactiveCommand _goToPageCommand;

        ~SwitcherViewModel()
        {
            LogManager.Log.Debug("SwitcherViewModel IS DESTROYED");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitcherViewModel"/> class.
        /// </summary>
        /// <param name="hostScreen">
        /// The host screen.
        /// </param>
        /// <param name="viewModelManager">
        /// The view model manager.
        /// </param>
        [ImportingConstructor]
        public SwitcherViewModel(IScreen hostScreen, IRoutableViewModelManager viewModelManager)
        {
            _viewModelManager = viewModelManager;
            HostScreen = hostScreen;
        }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get
            {
                return "SwitcherViewModel";
            }
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the go to page command.
        /// </summary>
        public ICommand GoToPageCommand
        {
            get
            {
                if (this._goToPageCommand == null)
                {
                    this._goToPageCommand = new ReactiveCommand(Observable.Return(true));
                    this._goToPageCommand.Subscribe(resolveType => this.OnNavigate((Type)resolveType));
                }

                return this._goToPageCommand;
            }
        }

        private void OnNavigate(Type resolveType)
        {
            Contract.Requires(resolveType != null, "The resolve type must be defined");

            var vm = _viewModelManager.Get(resolveType);
            HostScreen.Router.Navigate.Execute(vm);
        }
    }
}
