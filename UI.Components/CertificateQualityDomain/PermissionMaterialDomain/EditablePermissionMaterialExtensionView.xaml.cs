namespace UI.Components.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using Halfblood.Common;
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.Resources;

    [Export(typeof(IViewFor<IEditablePermissionMaterialExtensionViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditablePermissionMaterialExtensionView : UserControl, IViewFor<IEditablePermissionMaterialExtensionViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public EditablePermissionMaterialExtensionView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }
        
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IEditablePermissionMaterialExtensionViewModel)value; }
        }

        public IEditablePermissionMaterialExtensionViewModel ViewModel
        {
            get { return DataContext as IEditablePermissionMaterialExtensionViewModel; }
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

            AcbPermisMatExUser.ValueMemberPath = HelperExtensions.GetName<EmployeeDto>(x => x.Fullname);
            filterViewModel.Filter.Fullname = enteredText;
        }
        
        private IEnumerable<IDisposable> Binding()
        {
            yield return
                AcbPermisMatExUser.Binding(
                    ViewModel.EmployeeFilterViewModel,
                    SetUserFilter,
                    isBusy => BusyUser.Visibility = isBusy.ToVisibility());
            yield return
                this.Bind(ViewModel, vm => vm.SelectedEmployee, v => v.AcbPermisMatExUser.SelectedItem);
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