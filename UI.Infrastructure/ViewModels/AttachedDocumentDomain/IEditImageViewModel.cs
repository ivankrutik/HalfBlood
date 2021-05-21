// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditImageViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The EditImageViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.AttachedDocumentDomain
{
    using System;
    using System.Drawing;
    using System.Windows.Input;

    using ReactiveUI;

    public interface IEditImageViewModel : IDisposable, IRoutableViewModel
    {
        ICommand RotateCommand { get; }
        IObservable<Image> ImageTransformedNotification { get; }

        void SetImage(Image image);
        void Reset();
    }
}
