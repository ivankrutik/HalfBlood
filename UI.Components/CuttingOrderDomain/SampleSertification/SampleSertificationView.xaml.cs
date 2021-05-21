namespace UI.Components.CuttingOrderDomain.SampleCertification
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;
    using System.Reactive.Linq;

    /// <summary>
    /// Логика взаимодействия для SampleCertification.xaml
    /// </summary>
    [Export(typeof(IViewFor<ISampleCertificationViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SampleCertificationView
        : UserControl, IViewFor<ISampleCertificationViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        #endregion

        public SampleCertificationView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public ISampleCertificationViewModel ViewModel
        {
            get { return DataContext as ISampleCertificationViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ISampleCertificationViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.Bind(
                  this.ViewModel, vm => vm.SelectedSampleCertification, v => v.DtGridSampleCertifications.SelectedItem);
            
            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.SampleCertificationFilterViewModel.Result, v => v.DtGridSampleCertifications.ItemsSource);
            
            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.SampleCertificationFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);

            yield return
                ViewModel.WhenAny(x => x.SampleCertificationFilterViewModel.Result, x => x.Value)
                          .Where(res => res != null && res.Count > 0)
                          .Subscribe(_ => DtGridSampleCertifications.SelectedIndex = 0);
        }
    }
}
