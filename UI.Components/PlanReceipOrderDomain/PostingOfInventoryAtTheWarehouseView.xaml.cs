// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostingOfInventoryAtTheWarehouseView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PostingOfInventoryAtTheWarehouseView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using ReactiveUI;
    using UI.Components.Helpers;

    [Export(typeof(IViewFor<IPostingOfInventoryAtTheWarehouseViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PostingOfInventoryAtTheWarehouseView
        : UserControl, IViewFor<IPostingOfInventoryAtTheWarehouseViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~PostingOfInventoryAtTheWarehouseView()
        {
            LogManager.Log.Debug("PostingOfInventoryAtTheWarehouseView IS DESTROYED");
        }

        public PostingOfInventoryAtTheWarehouseView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IPostingOfInventoryAtTheWarehouseViewModel ViewModel
        {
            get { return this.DataContext as IPostingOfInventoryAtTheWarehouseViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
                _disposableContext.Add(Disposable.Create(() => ProFilterView.ViewModel = null));
                _disposableContext.Add(Disposable.Create(() => PlanReceiptOrderView.ViewModel = null));
                _disposableContext.Add(Disposable.Create(() => PlanCertificateView.ViewModel = null));
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPostingOfInventoryAtTheWarehouseViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(ViewModel, vm => vm.PlanReceiptOrderViewModel, v => v.PlanReceiptOrderView.ViewModel);

            yield return
                this.OneWayBind(ViewModel, vm => vm.PlanCertificateViewModel, v => v.PlanCertificateView.ViewModel);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.PlanReceiptOrderViewModel.PlanReceiptOrderFilterViewModel,
                    v => v.ProFilterView.ViewModel);

            yield return ViewModel.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(
                isBusy =>
                {
                    BusyControl.IsActive = isBusy;
                    RootContentGrid.IsEnabled = !isBusy;
                });
        }
    }
}