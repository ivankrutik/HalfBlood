namespace UI.Components.CuttingOrderDomain.CuttingOrderSpecification
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using Infrastructure.ViewModels.CuttingOrderDomain;
    using UI.Components.Helpers;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Reactive.Linq;

    /// <summary>
    /// Логика взаимодействия для CuttingOrderSpecification.xaml
    /// </summary>
    [Export(typeof(IViewFor<ICuttingOrderSpecificationViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CuttingOrderSpecificationView
        : UserControl, IViewFor<ICuttingOrderSpecificationViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _editRowMenuItem;
        private readonly MenuItem _insertRowMenuItem;
        private readonly MenuItem _insertMenuItem;
        #endregion

        public CuttingOrderSpecificationView()
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
            _disposableContext = new DisposableContext(this);

        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderSpecificationViewModel ViewModel
        {
            get { return DataContext as ICuttingOrderSpecificationViewModel; }
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
            set { this.ViewModel = (ICuttingOrderSpecificationViewModel)value; }
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
                   this.ViewModel, vm => vm.SelectedCuttingOrderSpecification, v => v.DtGridCuttingOrderSpecifications.SelectedItem);

            yield return
                this.OneWayBind(
                    this.ViewModel, vm => vm.CuttingOrderSpecificationFilterViewModel.Result, v => v.DtGridCuttingOrderSpecifications.ItemsSource);

            yield return
               this.OneWayBind(
                   this.ViewModel, vm => vm.CuttingOrderSpecificationFilterViewModel.IsBusy, v => v.BusyIndicator.IsActive);

            yield return
                this.BindCommand(
                    this.ViewModel, vm => vm.PreparingForEditCuttingOrderSpecificationCommand, v => v._editRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel, vm => vm.PreparingForEditCuttingOrderSpecificationCommand, v => v._insertRowMenuItem);

            yield return
                this.BindCommand(
                    this.ViewModel, vm => vm.PreparingForEditCuttingOrderSpecificationCommand, v => v._insertMenuItem);

            yield return
                ViewModel.WhenAny(x => x.CuttingOrderSpecificationFilterViewModel.Result, x => x.Value)
                          .Where(res => res != null && res.Count > 0)
                          .Subscribe(_ => DtGridCuttingOrderSpecifications.SelectedIndex = 0);


        }
    }

}
