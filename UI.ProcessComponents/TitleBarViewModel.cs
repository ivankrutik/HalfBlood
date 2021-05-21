// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TitleBarViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TitleBarViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Input;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Common;
    using UI.Infrastructure.ViewModels.Settings;

    [Export(typeof(ITitleBarViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TitleBarViewModel : ReactiveObject, ITitleBarViewModel
    {
        #region private fields
        private ReactiveCommand _goToReferencesCommand;
        private ReactiveCommand _goToLinksCommand;
        private ReactiveCommand _goToSettingsCommand;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        #endregion

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }

        [ImportingConstructor]
        public TitleBarViewModel(IScreen hostScreen, IRoutableViewModelManager routableViewModelManager)
        {
            HostScreen = hostScreen;
            _routableViewModelManager = routableViewModelManager;
        }

        public ICommand NavigateBackCommand
        {
            get { return HostScreen.Router.NavigateBack; }
        }
        public ICommand GoToReferencesCommand
        {
            get
            {
                if (this._goToReferencesCommand == null)
                {
                    _goToReferencesCommand = new ReactiveCommand();
                    _goToReferencesCommand.Subscribe(
                        _ => HostScreen.Router.Navigate.Execute(this._routableViewModelManager.Get<ISwitcherViewModel>()));
                }

                return this._goToReferencesCommand;
            }
        }
        public ICommand GoToLinksCommand
        {
            get
            {
                if (this._goToLinksCommand == null)
                {
                    _goToLinksCommand = new ReactiveCommand();
                    _goToLinksCommand.Subscribe(
                        _ => HostScreen.Router.Navigate.Execute(this._routableViewModelManager.Get<ILinkViewModel>()));
                }

                return this._goToLinksCommand;
            }
        }
        public ICommand GoToSettingsCommand
        {
            get
            {
                if (this._goToSettingsCommand == null)
                {
                    _goToSettingsCommand = new ReactiveCommand();
                    _goToSettingsCommand.Subscribe(
                        _ => HostScreen.Router.Navigate.Execute(_routableViewModelManager.Get<IEditorSettingViewModel>()));
                }

                return this._goToSettingsCommand;
            }
        }
    }
}
