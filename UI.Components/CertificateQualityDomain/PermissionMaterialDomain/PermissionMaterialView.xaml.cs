namespace UI.Components.CertificateQualityDomain.PermissionMaterialDomain
{
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;

    [Export(typeof(IViewFor<IPermissionMaterialViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PermissionMaterialView : UserControl, IViewFor<IPermissionMaterialViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private readonly MenuItem _editRowMenuItem;
        private readonly MenuItem _statusMenuItem;
        private readonly MenuItem _removeMenuItem;
        private readonly MenuItem _extendMenuItem;

        private readonly MenuItem _insertExMenuItem;
        private readonly MenuItem _insertExRowMenuItem;
        private readonly MenuItem _editExRowMenuItem;
        private readonly MenuItem _removeExRowMenuItem;
        #endregion

        public PermissionMaterialView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();

            _editRowMenuItem =
             ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                 .First(x => x.Name == "EditRowMenuItem");
            _statusMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "StatusRowMenuItem");
            _removeMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "RemoveRowMenuItem");
            _extendMenuItem =
               ((ContextMenu)RootGrid.Resources["DataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "ExtendRowMenuItem");
            _insertExMenuItem =
               ((ContextMenu)RootGrid.Resources["ExDataGridMenu"]).Items.Cast<MenuItem>()
                                                                .First(x => x.Name == "ExInsertMenuItem");
            _insertExRowMenuItem =
                ((ContextMenu)RootGrid.Resources["ExDataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "ExInsertRowMenuItem");
            _editExRowMenuItem =
             ((ContextMenu)RootGrid.Resources["ExDataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                 .First(x => x.Name == "ExEditRowMenuItem");
            _removeExRowMenuItem =
               ((ContextMenu)RootGrid.Resources["ExDataGridRowMenu"]).Items.Cast<MenuItem>()
                                                                    .First(x => x.Name == "ExRemoveRowMenuItem");
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IPermissionMaterialViewModel)value; }
        }

        public IPermissionMaterialViewModel ViewModel
        {
            get { return DataContext as IPermissionMaterialViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.OneWayBind(ViewModel, vm => vm.PermissionMaterialFilterViewModel.Result, v => v.DtPermissionMaterials.ItemsSource);
            yield return
                this.Bind(ViewModel, vm => vm.SelectedPermissionMaterial, v => v.DtPermissionMaterials.SelectedItem);

            yield return
                this.BindCommand(ViewModel, vm => vm.PreparingForEditPermissionMaterialCommand, v => v._editRowMenuItem);
            yield return
                this.BindCommand(ViewModel, vm => vm.PreparingForStatusPermissionMaterialCommand, v => v._statusMenuItem);
            yield return
              this.BindCommand(ViewModel, vm => vm.PreparingForRemovingPermissionMaterialCommand, v => v._removeMenuItem);
            yield return
              this.BindCommand(ViewModel, vm => vm.PreparingForAddingPermissionMaterialExCommand, v => v._extendMenuItem);

            yield return
                this.BindCommand(ViewModel, vm => vm.PreparingForAddingPermissionMaterialExCommand, v => v._insertExMenuItem);
            yield return
                this.BindCommand(ViewModel, vm => vm.PreparingForAddingPermissionMaterialExCommand, v => v._insertExRowMenuItem);
            yield return
               this.BindCommand(ViewModel, vm => vm.PreparingForEditPermissionMaterialExCommand, v => v._editExRowMenuItem);
            yield return
               this.BindCommand(ViewModel, vm => vm.PreparingForRemovingPermissionMaterialExCommand, v => v._removeExRowMenuItem);

            yield return
                Observable.FromEventPattern<SelectionChangedEventArgs>(DtPermissionMaterials, "SelectionChanged")
                    .Subscribe(
                        _ =>
                        TxbSelectedRowsCount.Text =
                        DtPermissionMaterials.SelectedItems.Count.ToString(CultureInfo.InvariantCulture));
            yield return
                ViewModel.WhenAny(vm => vm.PermissionMaterialFilterViewModel.Result, x => x.Value)
                    .Where(x => x != null)
                    .Subscribe(x => TxbRowsCount.Text = x.Count.ToString(CultureInfo.InvariantCulture));
        }
    }
}