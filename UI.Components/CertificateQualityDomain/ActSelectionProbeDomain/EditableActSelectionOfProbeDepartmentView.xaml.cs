// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditPersonalAccountView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.Components.CertificateQualityDomain.ActSelectionProbeDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Resources;
    using System.Reactive.Disposables;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using System.Reactive.Linq;
    using Halfblood.Common.Log;

    /// <summary>
    /// The editable personal account view.
    /// </summary>
    [Export(typeof(IViewFor<IEditableActSelectionOfProbeDepartmentViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableActSelectionOfProbeDepartmentView : UserControl, IViewFor<IEditableActSelectionOfProbeDepartmentViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditableActSelectionOfProbeDepartmentView()
        {
            LogManager.Log.Debug("EditableActSelectionOfProbeDepartmentView IS DESTROYED");
        }

        public EditableActSelectionOfProbeDepartmentView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableActSelectionOfProbeDepartmentViewModel)value; }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableActSelectionOfProbeDepartmentViewModel ViewModel
        {
            get { return DataContext as IEditableActSelectionOfProbeDepartmentViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }


        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            Title.Text = ViewModel.EditState == EditState.Insert ? CustomMessages.Creation : CustomMessages.Editing;

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.StaffingDivisionReceiver.Result,
                    v => v.CmbDepartmentReceiver.ItemsSource);

            yield return
             this.OneWayBind(
                 ViewModel,
                 vm => vm.StaffingDivisionMakingSample.Result,
                 v => v.CmbDepartmentMakingSample.ItemsSource);

            yield return
                ViewModel.WhenAny(x => x.EditState)
                    .Subscribe(state => AcatalogView.IsEnabled = state != EditState.Edit);

            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return this.OneWayBind(ViewModel, vm => vm.GetCatalogAccess.Result, v => v.AcatalogView.ItemsSource);
           // yield return this.Bind(ViewModel, vm => vm.EditableObject.Catalog, v => v.AcatalogView.SelectedItem);

        }
    }
}