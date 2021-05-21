namespace UI.Components.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using Halfblood.Common;
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.Resources;

    [Export(typeof(IViewFor<IEditablePermissionMaterialViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditablePermissionMaterialView : UserControl, IViewFor<IEditablePermissionMaterialViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public EditablePermissionMaterialView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditablePermissionMaterialViewModel)value; }
        }

        public IEditablePermissionMaterialViewModel ViewModel
        {
            get { return DataContext as IEditablePermissionMaterialViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        public void SetUserFilter(IFilterViewModel<EmployeeFilter, EmployeeDto> filterViewModel, string enteredText)
        {
            filterViewModel.Filter.Fullname = string.Empty;

            AcbPermisMatUser.ValueMemberPath = HelperExtensions.GetName<EmployeeDto>(x => x.Fullname);
            filterViewModel.Filter.Fullname = enteredText;
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return ViewModel.WhenAny(x => x.EditState).Subscribe(
                state =>
                {
                    if (state == EditState.Clone || state == EditState.Edit)
                    {
                        AcatalogView.IsEnabled = false;
                    }
                    else
                    {
                        AcatalogView.IsEnabled = true;
                    }
                });
            yield return 
                this.OneWayBind(ViewModel, vm => vm.GetCatalogAccess.Result, v => v.AcatalogView.ItemsSource);
            yield return 
                this.Bind(ViewModel, vm => vm.EditableObject.Catalog, v => v.AcatalogView.SelectedItem);
            yield return 
                ViewModel.WhenAny(x => x.IsBusy, x => x.Value).Subscribe(isBusy => Root.IsEnabled = !isBusy);
            yield return
                AcbPermisMatUser.Binding(
                    ViewModel.EmployeeFilterViewModel,
                    SetUserFilter,
                    isBusy => BusyUser.Visibility = isBusy.ToVisibility());
            yield return
                this.Bind(ViewModel, vm => vm.SelectedEmployee, v => v.AcbPermisMatUser.SelectedItem);
            yield return
                this.Bind(ViewModel, vm => vm.SelectedDgPermisMatUser, v => v.DgPermisMatUser.SelectedItem);
            yield return
              this.BindCommand(ViewModel, vm => vm.PreparingForAddingPermissionMaterialCommand, v => v.BtnAddUser);
            yield return
              this.BindCommand(ViewModel, vm => vm.PreparingForRemovingPermisMatUserCommand, v => v.BtnRemoveUser);

            Title.Text = ViewModel.EditState == EditState.Insert ? CustomMessages.Creation : CustomMessages.Editing;
        }
    }
}