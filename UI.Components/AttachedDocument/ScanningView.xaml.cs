// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanningView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for ScanningView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.AttachedDocument
{
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using Microsoft.Win32;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.AttachedDocumentDomain;

    /// <summary>
    /// Interaction logic for ScanningView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IGetImageViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ScanningView : UserControl, IViewFor<IGetImageViewModel>, INotifyPropertyChanged
    {
        private readonly DisposableContext _disposableContext;
        private string _fileName;

        ~ScanningView()
        {
            LogManager.Log.Debug("ScanningView IS DESTROYED");
        }

        public ScanningView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public string FileName
        {
            get { return _fileName; }
            private set
            {
                _fileName = value;
                OnPropertyChanged("Filename");
            }
        }
        public IGetImageViewModel ViewModel
        {
            get { return DataContext as IGetImageViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IGetImageViewModel)value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "Изображения|*.jpg;*.bmp;*.png" };
            fileDialog.ShowDialog(Application.Current.MainWindow);

            this.FileName = fileDialog.FileName;
        }
    }
}
