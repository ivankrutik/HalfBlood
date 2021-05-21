namespace UI.Components.CertificateQualityDomain.PermissionMaterialDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using ReactiveUI;
    using Helpers;
    using Infrastructure.ViewModels.PermissionMaterialDomain;

    /// <summary>
    /// Логика взаимодействия для PermissionMaterialPageView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IPermissionMaterialPageViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PermissionMaterialPageView : UserControl, IViewFor<IPermissionMaterialPageViewModel>, INotifyPropertyChanged
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionMaterialPageView"/> class.
        /// </summary>
        public PermissionMaterialPageView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IPermissionMaterialPageViewModel ViewModel
        {
            get { return this.DataContext as IPermissionMaterialPageViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
             //   _disposableContext.Add(Binding());
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPermissionMaterialPageViewModel)value; }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        //private IEnumerable<IDisposable> Binding()
        //{
        //    //PermissionMaterialFilterView.ViewModel = ViewModel;

        //    //yield return
        //    //    ViewModel.PermissionMaterialViewModel.WhenAny(x => x.IsBusy, x => x.Value)
        //    //                             .CombineLatest(
        //    //                                 ViewModel.PermissionMaterialViewModel.WhenAny(x => x.IsBusy, x => x.Value),
        //    //                                 (pc, pro) => pro || pc)
        //    //                             .ObserveOnUiSafeScheduler()
        //    //                             .Subscribe(
        //    //                                 isBusy =>
        //    //                                 {
        //    //                                     this.BusyControl.IsActive = isBusy;
        //    //                                     this.Root.IsEnabled = !isBusy;
        //    //                                 });
        //}
    }
}