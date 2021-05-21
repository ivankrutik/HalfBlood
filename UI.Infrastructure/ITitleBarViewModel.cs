namespace UI.Infrastructure
{
    using System.Windows.Input;
    using ReactiveUI;

    public interface ITitleBarViewModel : IRoutableViewModel
    {
        ICommand NavigateBackCommand { get; }
        ICommand GoToReferencesCommand { get; }
        ICommand GoToLinksCommand { get; }
        ICommand GoToSettingsCommand { get; }
    }
}
