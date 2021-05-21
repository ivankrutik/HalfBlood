namespace UI.Components.CuttingOrderDomain.CuttingOrder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Controls;
    using Helpers;
    using Infrastructure.ViewModels.CuttingOrderDomain;
    using ReactiveUI;

    /// <summary>
    /// Логика взаимодействия для CuttingOrderView.xaml
    /// </summary>
    [Export(typeof(IViewFor<ICuttingOrderViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CuttingOrderView
        : UserControl, IViewFor<ICuttingOrderViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        //private readonly MenuItem _editRowMenuItem;
        //private readonly MenuItem _insertRowMenuItem;
        //private readonly MenuItem _insertMenuItem;
        private readonly MenuItem _detaileViewRowMenuItem;
        private readonly MenuItem _statusMenuItem;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="CuttingOrderView"/> class.
        /// </summary>
        public CuttingOrderView()
        {
            InitializeComponent();
            //_editRowMenuItem =
            //    ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
            //                                                        .First(x => x.Name == "EditRowMenuItem");
            //_insertRowMenuItem =
            //    ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
            //                                                        .First(x => x.Name == "InsertRowMenuItem");
            //_insertMenuItem =
            //    ((ContextMenu)RootGrid.Resources["DataGridMenu"]).Items.Cast<MenuItem>()
            //                                                     .First(x => x.Name == "InsertMenuItem");
            _detaileViewRowMenuItem =
                ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                 .First(x => x.Name == "DetaileViewRowMenuItem");

            _statusMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "StatusRowMenuItem");
            _disposableContext = new DisposableContext(this);

            DtGridCuttingOrders.MouseDoubleClick += DtGridCuttingOrders_MouseDoubleClick;
        }

        void DtGridCuttingOrders_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.ViewModel.SelectedCuttingOrder != null) 
            {
                this.ViewModel.PreparingForDetailedCuttingOrderCommand.Execute(sender);
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderViewModel ViewModel
        {
            get { return DataContext as ICuttingOrderViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }

        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ICuttingOrderViewModel)value; }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            this.Bind(
                   this.ViewModel, vm => vm.SelectedCuttingOrder, v => v.DtGridCuttingOrders.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.CuttingOrderFilterViewModel.Result, v => v.DtGridCuttingOrders.ItemsSource);

            yield return
                this.BindCommand(
                    this.ViewModel, vm => vm.PreparingForDetailedCuttingOrderCommand, v => v._detaileViewRowMenuItem);

            yield return
               this.BindCommand(
                   this.ViewModel, vm => vm.PreparingForDetailedCuttingOrderCommand, v => v._detaileViewRowMenuItem);


            //yield return
            //    this.BindCommand(
            //        this.ViewModel, vm => vm.PreparingForDetailedCuttingOrderCommand, v => v._insertRowMenuItem);

            //yield return
            //    this.BindCommand(
            //        this.ViewModel, vm => vm.PreparingForDetailedCuttingOrderCommand, v => v._insertMenuItem);


            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.CuttingOrderFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);
            //yield return
            //    this.BindCommand(
            //        this.ViewModel, vm => vm.PreparingForStatusCuttingOrderCommand, v => v._statusMenuItem);

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }

    }
}
