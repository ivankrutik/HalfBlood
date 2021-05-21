namespace UI.Components.CuttingOrderDomain.Sample
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
    /// Логика взаимодействия для SampleView.xaml
    /// </summary>
    [Export(typeof(IViewFor<ISampleViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SampleView
        : UserControl, IViewFor<ISampleViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        #endregion
        public SampleView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public ISampleViewModel ViewModel
        {
            get { return DataContext as ISampleViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.Bind(
                  this.ViewModel, vm => vm.SelectedSample, v => v.DtGridSamples.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.SampleFilterViewModel.Result, v => v.DtGridSamples.ItemsSource);

            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.SampleFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);
           
            yield return
                ViewModel.WhenAny(x => x.SampleFilterViewModel.Result, x => x.Value)
                          .Where(res => res != null && res.Count > 0)
                          .Subscribe(_ => DtGridSamples.SelectedIndex = 0);
            
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ISampleViewModel)value; }
        }
    }
}
