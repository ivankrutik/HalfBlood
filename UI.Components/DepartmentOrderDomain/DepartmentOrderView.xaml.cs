// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<IDepartmentOrderViewModel>))]
    public partial class DepartmentOrderView : UserControl, IViewFor<IDepartmentOrderViewModel>
    { 
        #region private fields
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _editRowMenuItem;
        private readonly MenuItem _insertRowMenuItem;
        private readonly MenuItem _insertMenuItem;
        private readonly MenuItem _statusMenuItem;
        private readonly MenuItem _removeMenuItem;
        #endregion

        public DepartmentOrderView()
        {
            InitializeComponent();

            _editRowMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "EditRowMenuItem");
            _insertRowMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "InsertRowMenuItem");
            _insertMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridMenu"]).Items.Cast<MenuItem>()
                                                                 .First(x => x.Name == "InsertMenuItem");
            _statusMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "StatusRowMenuItem");
            _removeMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "RemoveRowMenuItem");

            _disposableContext = new DisposableContext(this);
        }

        public IDepartmentOrderViewModel ViewModel
        {
            get { return DataContext as IDepartmentOrderViewModel; }
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
            set { this.ViewModel = (IDepartmentOrderViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.IsBusy,
                    v => v.BusyControl.IsActive);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.IsBusy,
                    v => v.Root.IsEnabled,
                    isBusy => !isBusy);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.DepartmentOrderFilteringObject,
                    v => v.ManufacturersCertificateFilterView.ViewModel);

            yield return
                this.Bind(this.ViewModel, vm => vm.SelectedDepartmentOrder, v => v.DtDepartmentOrders.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.DepartmentOrderFilteringObject.Result,
                    v => v.DtDepartmentOrders.ItemsSource);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.DepartmentOrderFilteringObject.IsBusy,
                    v => v.BusyControl.IsActive);

            yield return
                this.OneWayBind(
                    this.ViewModel,
                    vm => vm.DepartmentOrderFilteringObject.IsBusy,
                    v => v.Root.IsEnabled,
                    isBusy => !isBusy);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForEditDepartmentOrderCommand,
                    v => v._editRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForAddDepartmentOrderCommand,
                    v => v._insertRowMenuItem);

            yield return
                this.BindCommand(this.ViewModel, vm => vm.PreparingForAddDepartmentOrderCommand, v => v._insertMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForStatusDepartmentOrderCommand,
                    v => v._statusMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel,
                    vm => vm.PreparingForRemoveDepartmentOrderCommand,
                    v => v._removeMenuItem);
        }
    }
}