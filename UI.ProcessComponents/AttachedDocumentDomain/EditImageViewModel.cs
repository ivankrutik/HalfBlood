// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditImageViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The image manager view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.AttachedDocumentDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows.Input;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels.AttachedDocumentDomain;

    /// <summary>
    /// The image manager. Rotate and crop image.
    /// </summary>
    [Export(typeof(IEditImageViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditImageViewModel : ReactiveObject, IEditImageViewModel
    {
        private IImageManager _imageManager;
        private ReactiveCommand _rotateCommand;
        private readonly Subject<Image> imageTransformedNotification = new Subject<Image>();

        ~EditImageViewModel()
        {
            LogManager.Log.Debug("EditImageViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public EditImageViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        public IObservable<Image> ImageTransformedNotification
        {
            get { return this.imageTransformedNotification; }
        }
        public ICommand RotateCommand
        {
            get
            {
                if (_rotateCommand == null)
                {
                    _rotateCommand = new ReactiveCommand(CanExecute());
                    _rotateCommand.Subscribe(_ => OnRotate());
                }

                return _rotateCommand;
            }
        }
        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
        public void SetImage(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            this.Reset();
            _imageManager = new ImageManager(image);
        }
        public void Reset()
        {
            _imageManager = null;
            if (_rotateCommand != null)
            {
                _rotateCommand.Dispose();
                _rotateCommand = null;
                this.RaisePropertyChanged("RotateCommand");
            }
        }

        public void Dispose()
        {
            if (_rotateCommand != null)
            {
                _rotateCommand.Dispose();
            }
        }

        private void OnRotate()
        {
            if (_imageManager == null)
            {
                return;
            }

            _imageManager.Rotate(RotateFlipType.Rotate90FlipNone);
            this.imageTransformedNotification.OnNext(_imageManager.Image);
        }
        private IObservable<bool> CanExecute()
        {
            var observable = Observable.Return(true);
            return observable;
        }
    }
}
