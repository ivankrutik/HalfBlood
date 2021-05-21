// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for AttachedDocumentView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Halfblood.Common.Helpers.FileManagers.Converters;

namespace UI.Components.AttachedDocument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Converters;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels;

    [Export(typeof(IViewFor<IAttachedDocumentViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AttachedDocumentView
        : UserControl, IViewFor<IAttachedDocumentViewModel>, INotifyPropertyChanged
    {
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _removeMenuItem;
        private readonly BitmapSource _defaultImage;
        private System.Drawing.Image _image;
        private readonly DisposableObject _disposableObject = new DisposableObject();

        public AttachedDocumentView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
            _removeMenuItem =
                ((ContextMenu)this.RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                    .First(x => x.Name == "RemoveRowMenuItem");
            _defaultImage = new BitmapImage(new Uri("/Assets/NoImage.png", UriKind.RelativeOrAbsolute));

            Loaded += (sender, args) => ReBind();
            Unloaded += (sender, args) => _disposableObject.Dispose();
        }

        ~AttachedDocumentView()
        {
            LogManager.Log.Debug("AttachedDocumentView IS DESTROYED");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IAttachedDocumentViewModel ViewModel
        {
            get { return DataContext as IAttachedDocumentViewModel; }
            set
            {
                DataContext = value;
                ReBind();
            }
        }
        public System.Drawing.Image Image
        {
            get { return this._image; }
            private set
            {
                //dirty huck
                this._image = null;
                OnPropertyChanged();

                this._image = value;
                OnPropertyChanged();
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IAttachedDocumentViewModel)value; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private IEnumerable<IDisposable> Binding()
        {
            this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.RootProgressRing.IsActive);
            this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.RootGrid.IsEnabled, isBusy => !isBusy);
            yield return this.ViewModel.WhenAnyValue(x => x.DocumentManagerViewModel.ManageImageMode).Subscribe(
                mode =>
                {
                    switch (mode)
                    {
                        case ManageImageMode.Inserting:
                            this.ImgCurrent.Source = _defaultImage;
                            this.ViewHost.ViewModel = this.ViewModel.DocumentManagerViewModel.GetImageViewModel;
                            break;

                        case ManageImageMode.ImageEditing:
                            this.ViewHost.ViewModel = this.ViewModel.DocumentManagerViewModel.EditImageViewModel;
                            break;

                        case ManageImageMode.Cancelling:
                            this.Image = null;
                            this.ViewHost.ViewModel = null;
                            LsbAttacheDoc.SelectedIndex = 0;
                            break;
                        
                        case ManageImageMode.Apply:
                          //  LsbAttacheDoc.SelectedIndex = ViewModel.HasDocument.Documents.Count - 1;
                            break;
                    }
                });

            yield return this.ViewModel.WhenAnyValue(x => x.DocumentManagerViewModel.IsInserting).Subscribe(
                isEditing =>
                {
                    DocumentsGroupBox.IsEnabled = !isEditing;
                    BeginAddingButton.IsEnabled = !isEditing;
                    ViewHost.Visibility = isEditing ? Visibility.Visible : Visibility.Collapsed;
                    MetadataGroupBox.Visibility = isEditing ? Visibility.Visible : Visibility.Collapsed;
                });

            yield return
                this.WhenAnyValue(x => x.Image)
                    .ObserveOnUiSafeScheduler()
                    .Subscribe(
                        image =>
                        ImgCurrent.Source = image == null ? _defaultImage : ImageToBitmapSource.ToBitmapSource(image));

            yield return
                this.ViewModel.DocumentManagerViewModel.ImageChangedNotification.ObserveOnUiSafeScheduler()
                    .Subscribe(image => Image = image);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.AttachedDocumentTypes,
                    v => v.CmbAttachedDocumentType.ItemsSource);

            yield return this.OneWayBind(ViewModel, vm => vm.CatalogAccess.IsBusy, v => v.BusyLoadCatalogs.IsActive);
            yield return this.OneWayBind(ViewModel, vm => vm.CatalogAccess.Result, v => v.AcatalogView.ItemsSource);
            yield return this.OneWayBind(ViewModel, vm => vm.HasDocument.Documents, v => v.LsbAttacheDoc.ItemsSource);
            yield return this.Bind(ViewModel, vm => vm.SelectedDocument, v => v.LsbAttacheDoc.SelectedItem);

            yield return this.ViewModel.WhenAnyValue(x => x.SelectedDocument).Subscribe(
                document =>
                    {
                        if (document != null && document.Content != null)
                        {
                            Image = ImagesConverter.ToImage( document.Content);
                        }
                        else
                        {
                            Image = null;
                        }
                    });

            var d = new Binding("SelectedItem") { Source = this.LsbAttacheDoc, Mode = BindingMode.OneWay };
            var d1 = new Binding { Source = this.ViewModel.DocumentManagerViewModel.RemoveDocumentCommand, Mode = BindingMode.OneWay };

            this._removeMenuItem.SetBinding(MenuItem.CommandProperty, d1);
            this._removeMenuItem.SetBinding(MenuItem.CommandParameterProperty, d);

            yield return Disposable.Create(() => BindingOperations.ClearAllBindings(this._removeMenuItem));
        }
        private void ReBind()
        {
            _disposableObject.Dispose();
            _disposableObject.Add(Binding());
        }
    }
}
