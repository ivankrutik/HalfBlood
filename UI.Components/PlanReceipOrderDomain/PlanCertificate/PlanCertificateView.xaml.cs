// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanCertificateView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PlanCertificate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using UI.Components.Converters;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [Export(typeof(IViewFor<IPlanCertificateViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PlanCertificateView : UserControl, IViewFor<IPlanCertificateViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _editRowMenuItem;
        private readonly MenuItem _insertRowMenuItem;
        private readonly MenuItem _insertMenuItem;
        private readonly MenuItem _removeRowMenuItem;
        private readonly MenuItem _copyRowMenuItem;
        private readonly MenuItem _attachedDocumentMenuItem;
        private readonly MenuItem _personalAccountEditRowMenuItem;
        private readonly MenuItem _personalAccountInsertRowMenuItem;
        private readonly MenuItem _personalAccountRemoveRowMenuItem;
        private readonly MenuItem _personalAccountInsertMenuItem;
        private readonly MenuItem _personalAccountStatusRowMenuItem;
        private readonly MenuItem _changeStatusCertificate;
        private IDisposable _disposableDataGrid = Disposable.Empty;
        #endregion

        ~PlanCertificateView()
        {
            LogManager.Log.Debug("PlanCertificateView IS DESTROYED");
        }

        public PlanCertificateView()
        {
            InitializeComponent();

            _changeStatusCertificate = this.GetMenuItem("DataGridRowMenu", "ChangeStatusRowMenuItem");
            _insertMenuItem = this.GetMenuItem("DataGridMenu", "InsertMenuItem");
            _editRowMenuItem = this.GetMenuItem("DataGridRowMenu", "EditRowMenuItem");
            _insertRowMenuItem = this.GetMenuItem("DataGridRowMenu", "InsertRowMenuItem");
            _removeRowMenuItem = this.GetMenuItem("DataGridRowMenu", "RemoveRowMenuItem");
            _copyRowMenuItem = this.GetMenuItem("DataGridRowMenu", "CopyRowMenuItem");
            _personalAccountInsertRowMenuItem = this.GetMenuItem("SubDgRowMenu", "PersonalAccountInsertRowMenuItem");
            _personalAccountEditRowMenuItem = this.GetMenuItem("SubDgRowMenu", "PersonalAccountEditRowMenuItem");
            _personalAccountInsertMenuItem = this.GetMenuItem("SubDgMenu", "PersonalAccountInsertMenuItem");
            _personalAccountRemoveRowMenuItem = this.GetMenuItem("SubDgRowMenu", "PersonalAccountRemoveRowMenuItem");
            _personalAccountStatusRowMenuItem = this.GetMenuItem("SubDgRowMenu", "PersonalAccountStatusRowMenuItem");

            _disposableContext = new DisposableContext(this);
        }

        public IPlanCertificateViewModel ViewModel
        {
            get { return DataContext as IPlanCertificateViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
                //_disposableContext.Add(Disposable.Create(() => RootGrid.Resources.Clear()));
                _disposableContext.Add(Binding());
            }
        }

        public DataGrid DataGridPersonalAccounts { get; set; }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IPlanCertificateViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                ViewModel.PlanCertificateFilterViewModel.WhenAny(x => x.IsBusy, x => x.Value)
                    .Subscribe(isBusy => Root.IsEnabled = !isBusy);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.PlanCertificateFilterViewModel.IsBusy,
                    v => v.BusyIndicator.IsActive);

            yield return
                this.Bind(
                    this.ViewModel,
                    vm => vm.SelectedPlanCertificate,
                    v => v.DtGridPlanCertificate.SelectedValue);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.PlanCertificateFilterViewModel.Result,
                    v => v.DtGridPlanCertificate.ItemsSource);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingEditablePlanCertificateCommand,
                    v => v._editRowMenuItem);

            yield return
                this.BindCommand(this.ViewModel, vm => vm.PreparingCopyPlanCertificateCommand, v => v._copyRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingAddingPlanCertificateCommand,
                    v => v._insertRowMenuItem);

            yield return
                this.BindCommand(this.ViewModel, vm => vm.PreparingAddingPlanCertificateCommand, v => v._insertMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingEditablePersonalAccountCommand,
                    v => v._personalAccountEditRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingAddingPersonalAccountCommand,
                    v => v._personalAccountInsertRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingAddingPersonalAccountCommand,
                    v => v._personalAccountInsertMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingRemovingPlanCertificateCommand,
                    v => v._removeRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingRemovingPersonalAccountCommand,
                    v => v._personalAccountRemoveRowMenuItem);

            yield return
                ViewModel.WhenAny(vm => vm.PlanCertificateFilterViewModel.Result, x => x.Value)
                    .Where(x => x != null)
                    .Subscribe(x => TxbRowsCount.Text = x.Count.ToString(CultureInfo.InvariantCulture));

            yield return
                Observable.FromEventPattern<SelectionChangedEventHandler, SelectionChangedEventArgs>(
                    h => this.DtGridPlanCertificate.SelectionChanged += h,
                    h => this.DtGridPlanCertificate.SelectionChanged -= h).Subscribe(
                        _ =>
                            {
                                TxbSelectedRowsCount.Text =
                                    this.DtGridPlanCertificate.SelectedItems.Count.ToString(
                                        CultureInfo.InvariantCulture);
                                TxbSumCountByDocumentSelectedRows.Text =
                                    (from PlanCertificateLiteDto elem in this.DtGridPlanCertificate.SelectedItems
                                     select elem.CountByDocument
                                     into countByDocument
                                     where countByDocument != null
                                     select countByDocument).Sum().ToString();

                                TxbSumCountFactSelectedRows.Text = (from PlanCertificateLiteDto elem in
                                                                        this.DtGridPlanCertificate.SelectedItems
                                                                    select elem.CountFact
                                                                    into countFact
                                                                    select countFact).Sum()
                                    .ToString(CultureInfo.InvariantCulture);

                                TxbSumSelectedPriseCount.Text =
                                    (from PlanCertificateLiteDto elem in this.DtGridPlanCertificate.SelectedItems
                                     where elem.SumWithTaxDocumenta != null
                                     select elem.SumWithTaxDocumenta).Sum().ToString();
                            });

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingEditablePlanCertificateCommand,
                    v => v.DtGridPlanCertificate, "MouseDoubleClick");

            _personalAccountStatusRowMenuItem.SetBinding(
                MenuItem.CommandProperty,
                new Binding(ViewModel.GetName(x => x.PreparingForStatusPersonalAccountCommand)) { Source = ViewModel });

            _changeStatusCertificate.SetBinding(
                MenuItem.CommandProperty,
                new Binding(ViewModel.GetName(x => x.PreparingForStatusPlanCertificateCommand)) { Source = ViewModel });

            _changeStatusCertificate.SetBinding(
                MenuItem.CommandParameterProperty,
                new Binding(DtGridPlanCertificate.GetName(x => x.SelectedItems)) {
                    Source = DtGridPlanCertificate,
                    Converter = new SelectedItemsConverter<PlanCertificateLiteDto>()
                });
            yield return Disposable.Create(() => BindingOperations.ClearAllBindings(_changeStatusCertificate));
        }
        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.PreparingEditablePersonalAccountCommand.CanExecute(null))
            {
                ViewModel.PreparingEditablePersonalAccountCommand.Execute(null);
            }
        }
        private void DataGridPersonalAccounts_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridPersonalAccounts = (DataGrid)sender;

            this._disposableDataGrid.Dispose();
            _personalAccountStatusRowMenuItem.SetBinding(
                MenuItem.CommandParameterProperty,
                new Binding(DataGridPersonalAccounts.GetName(x => x.SelectedItems))
                {
                    Source = DataGridPersonalAccounts,
                    Converter = new SelectedItemsConverter<PersonalAccountOfPlanReceiptOrderLiteDto>()
                });

            this._disposableDataGrid = Disposable.Create(() => BindingOperations.ClearAllBindings(_personalAccountStatusRowMenuItem));
        }
    }
}