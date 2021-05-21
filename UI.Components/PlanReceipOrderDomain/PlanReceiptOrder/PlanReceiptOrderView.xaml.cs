// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanReceiptOrder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using UI.Components.Converters;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    public interface IPlanReceiptOrderView : IViewFor<IPlanReceiptOrderViewModel>
    {
        IObservable<Unit> LoadedNotification { get; }
        IObservable<Unit> UnloadedNotification { get; }
        DataGrid DataGrid { get; }
    }

    [Export(typeof(IViewFor<IPlanReceiptOrderViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PlanReceiptOrderView : UserControl, IPlanReceiptOrderView
    {
        #region PRIVATE FIELDS
        private readonly MenuItem _editRowMenuItem;
        private readonly MenuItem _insertRowMenuItem;
        private readonly MenuItem _insertMenuItem;
        private readonly MenuItem _statusMenuItem;
        private readonly MenuItem _removeMenuItem;
        private readonly MenuItem _groupStatusRowMenuItem;
        private readonly DisposableContext _disposableContext;
        private readonly Subject<Unit> _loadedNotificationSubject = new Subject<Unit>();
        private readonly Subject<Unit> _unloadedNotificationSubject = new Subject<Unit>();
        #endregion

        ~PlanReceiptOrderView()
        {
            LogManager.Log.Debug("PlanReceiptOrderView IS DESTROYED");
        }

        public PlanReceiptOrderView()
        {
            InitializeComponent();

            _groupStatusRowMenuItem = this.GetMenuItem("DataGridRowMenu", "SetGroupPersonalAccountPlanReceiptOrderRowMenuItem");
            _editRowMenuItem = this.GetMenuItem("DataGridRowMenu", "EditRowMenuItem");
            _insertRowMenuItem = this.GetMenuItem("DataGridRowMenu", "InsertRowMenuItem");
            _insertMenuItem = this.GetMenuItem("DataGridMenu", "InsertMenuItem");
            _statusMenuItem = this.GetMenuItem("DataGridRowMenu", "StatusRowMenuItem");
            _removeMenuItem = this.GetMenuItem("DataGridRowMenu", "RemoveRowMenuItem");
            _disposableContext = new DisposableContext(this);
        }

        public IObservable<Unit> LoadedNotification
        {
            get { return _loadedNotificationSubject; }
        }
        public IObservable<Unit> UnloadedNotification
        {
            get { return _unloadedNotificationSubject; }
        }
        public DataGrid DataGrid
        {
            get { return DtGridPlanReceiptOrders; }
        }
        public IPlanReceiptOrderViewModel ViewModel
        {
            get { return DataContext as IPlanReceiptOrderViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPlanReceiptOrderViewModel)value; }
        }
        private IEnumerable<IDisposable> Binding()
        {
            Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => Loaded += h, h => Loaded -= h)
                .Subscribe(_ => _loadedNotificationSubject.OnNext(Unit.Default));

            Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => Unloaded += h, h => Unloaded -= h)
                .Subscribe(_ => _unloadedNotificationSubject.OnNext(Unit.Default));

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.PlanReceiptOrderFilterViewModel.Result,
                    v => v.DtGridPlanReceiptOrders.ItemsSource);

            yield return
                this.Bind(
                    this.ViewModel,
                    vm => vm.SelectedPlanReceiptOrder,
                    v => v.DtGridPlanReceiptOrders.SelectedItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForEditPlanReceiptOrderCommand,
                    v => v._editRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForAddPlanReceiptOrderCommand,
                    v => v._insertRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForAddPlanReceiptOrderCommand,
                    v => v._insertMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForRemovePlanReceiptOrderCommand,
                    v => v._removeMenuItem);

            yield return
                ViewModel.WhenAny(vm => vm.PlanReceiptOrderFilterViewModel.Result, x => x.Value)
                    .Where(x => x != null)
                    .ObserveOnUiSafeScheduler()
                    .Subscribe(x => TxbRowsCount.Text = x.Count.ToString(CultureInfo.InvariantCulture));

            yield return
                Observable.FromEventPattern<SelectionChangedEventHandler, SelectionChangedEventArgs>(
                    h => DtGridPlanReceiptOrders.SelectionChanged += h,
                    h => DtGridPlanReceiptOrders.SelectionChanged -= h)
                    .Subscribe(
                        _ =>
                        TxbSelectedRowsCount.Text =
                        DtGridPlanReceiptOrders.SelectedItems.Count.ToString(CultureInfo.InvariantCulture));

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForEditPlanReceiptOrderCommand,
                    v => v.DtGridPlanReceiptOrders,
                    "MouseDoubleClick");

            _groupStatusRowMenuItem.SetBinding(
                MenuItem.CommandProperty,
                new Binding(ViewModel.GetName(x => x.PreparingChangeGroupStateCommand)) { Source = ViewModel });

            _groupStatusRowMenuItem.SetBinding(
                MenuItem.CommandParameterProperty,
                new Binding(DtGridPlanReceiptOrders.GetName(x => x.SelectedItems)) {
                    Source = DtGridPlanReceiptOrders,
                    Converter = new SelectedItemsConverter<PlanReceiptOrderLiteDto>()
                });
            yield return Disposable.Create(() => BindingOperations.ClearAllBindings(_groupStatusRowMenuItem));

            _statusMenuItem.SetBinding(
                MenuItem.CommandProperty,
                new Binding(ViewModel.GetName(x => x.PreparingForStatusPlanReceiptOrderCommand)) { Source = ViewModel });

            _statusMenuItem.SetBinding(
                MenuItem.CommandParameterProperty,
                new Binding(DtGridPlanReceiptOrders.GetName(x => x.SelectedItems)) {
                    Source = DtGridPlanReceiptOrders,
                    Converter = new SelectedItemsConverter<PlanReceiptOrderLiteDto>()
                });
            yield return Disposable.Create(() => BindingOperations.ClearAllBindings(_statusMenuItem));
        }
    }
}