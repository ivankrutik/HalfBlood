//// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetImageViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the GetImageViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.AttachedDocumentDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Halfblood.Common.Helpers.FileManagers;
    using Halfblood.Common.Helpers.FileManagers.Converters;
    using Halfblood.Common.Log;

    using ReactiveUI;

    using Toolkit.Infrastructure.Scanner;

    using UI.Infrastructure.ViewModels.AttachedDocumentDomain;

    /// <summary>
    /// The file manager view model.
    /// </summary>
    [Export(typeof(IGetImageViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetImageViewModel : ReactiveObject, IGetImageViewModel
    {
        #region private fields
        private ReactiveCommand _scanningCommand;
        private ReactiveCommand _fromFileSystemCommand;
        private ReactiveCommand _scanningWithAdvancedSettingsCommand;
        private bool _isBusy;
        private Image _image;
        private readonly IScannerManager _scannerManager;
        private readonly Subject<Unit> _readingFileCompletedNotification = new Subject<Unit>();
        #endregion

        ~GetImageViewModel()
        {
            LogManager.Log.Debug("GetImageViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public GetImageViewModel(IScannerManager scannerManager, IScreen screen)
        {
            HostScreen = screen;
            _scannerManager = scannerManager;
        }

        public IObservable<Unit> ReadingFileCompletedNotification
        {
            get
            {
                return _readingFileCompletedNotification;
            }
        }
        public ICommand ScanningCommand
        {
            get
            {
                if (_scanningCommand == null)
                {
                    _scanningCommand = new ReactiveCommand(CanExecute());
                    _scanningCommand.ThrownExceptions.Subscribe(OnError);
                    _scanningCommand.RegisterAsyncTask(_ => OnScanning(false))
                        .Subscribe();
                }

                return _scanningCommand;
            }
        }
        public ICommand ScanningWithAdvancedSettingsCommand
        {
            get
            {
                if (_scanningWithAdvancedSettingsCommand == null)
                {
                    _scanningWithAdvancedSettingsCommand = new ReactiveCommand(CanExecute());
                    _scanningWithAdvancedSettingsCommand.ThrownExceptions.Subscribe(OnError);
                    _scanningWithAdvancedSettingsCommand.RegisterAsyncTask(_ => OnScanning(true))
                        .Subscribe();
                }

                return _scanningWithAdvancedSettingsCommand;
            }
        }
        public ICommand FromFileSystemCommand
        {
            get
            {
                if (_fromFileSystemCommand == null)
                {
                    _fromFileSystemCommand = new ReactiveCommand(CanExecute());
                    _fromFileSystemCommand.ThrownExceptions.Subscribe(OnError);
                    _fromFileSystemCommand
                        .RegisterAsyncTask(fileName =>
                        {
                            if (!string.IsNullOrWhiteSpace((string) fileName))
                            {
                                return OnGetFromFileSystem((string) fileName);
                            }

                            return Task.Factory.StartNew(() => { });
                        })
                        .Subscribe();
                }

                return _fromFileSystemCommand;
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public Image Image
        {
            get { return this._image; }
            private set
            {
                _image = value;
                this.RaisePropertyChanged();
            }
        }
        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }

        public void Dispose()
        {
            if (_scanningCommand != null)
            {
                _scanningCommand.Dispose();
                _scanningCommand = null;
            }

            if (_fromFileSystemCommand != null)
            {
                _fromFileSystemCommand.Dispose();
                _fromFileSystemCommand = null;
            }
        }

        private IObservable<bool> CanExecute()
        {
            return this.WhenAny(x => x.IsBusy, x => x.Value).Select(isBusy => !isBusy);
        }
        private Task OnGetFromFileSystem(string fileName)
        {
            return RunAsync(new FileSystemStrategy(fileName));
        }
        private Task OnScanning(bool withAdvancedSettings)
        {
            var scaner = (IGetFileStrategy)_scannerManager;
            scaner.SetParams(50, 50, withAdvancedSettings);
            return RunAsync(scaner);
        }
        private Task RunAsync(IGetFileStrategy strategy)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    IsBusy = true;
                    var image = ImagesConverter.ToImage(strategy.GetFile());
                    return ImagesConverter.ConvertInFormat(image, System.Drawing.Imaging.ImageFormat.Png);
                }).ContinueWith(
                        task =>
                        {
                            IsBusy = false;
                            if (task.IsFaulted)
                            {
                                //_readingFileCompletedNotification.OnNext(Unit.Default);
                                throw task.Exception.InnerExceptions[0];
                            }
                            Image = task.Result;
                            _readingFileCompletedNotification.OnNext(Unit.Default);
                        });
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("При сканирование ошибка", exception);
        }
    }
}