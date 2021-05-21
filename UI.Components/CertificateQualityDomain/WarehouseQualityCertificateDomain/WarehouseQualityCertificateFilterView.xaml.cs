namespace UI.Components.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IViewFor<IWarehouseQualityCertificateFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class WarehouseQualityCertificateFilterView : UserControl, IViewFor<IWarehouseQualityCertificateFilterViewModel>
    {
        private DisposableContext disposableContext;

        public WarehouseQualityCertificateFilterView()
        {
            disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IWarehouseQualityCertificateFilterViewModel ViewModel
        {
            get { return DataContext as IWarehouseQualityCertificateFilterViewModel; }
            set
            {
                DataContext = value;
                disposableContext.Dispose();
                disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IWarehouseQualityCertificateFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.Bind(ViewModel, vm => vm.Filter.FullRepresentation, v => v.FullRepresentationTextBox.Text);

            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.SearchButton);

            yield return
                Observable.FromEventPattern<KeyEventHandler, KeyEventArgs>(
                    h => FullRepresentationTextBox.KeyDown += h,
                    h => FullRepresentationTextBox.KeyDown -= h)
                    .Where(args => args.EventArgs.Key == Key.Enter)
                    .Where(_ => ViewModel.InvokeCommand != null && ViewModel.InvokeCommand.CanExecute(null))
                    .Subscribe(_ => ViewModel.InvokeCommand.Execute(null));
        }
    }
}
