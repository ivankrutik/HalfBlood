// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetImageViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The GetImageViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.AttachedDocumentDomain
{
    using System;
    using System.Drawing;
    using System.Reactive;
    using System.Windows.Input;

    using ReactiveUI;

    public interface IGetImageViewModel : IDisposable, IRoutableViewModel
    {
        IObservable<Unit> ReadingFileCompletedNotification { get; }
        ICommand ScanningCommand { get; }
        ICommand ScanningWithAdvancedSettingsCommand { get; }
        ICommand FromFileSystemCommand { get; }
        bool IsBusy { get; }
        Image Image { get; }
    }
}
