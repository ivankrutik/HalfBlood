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
    [Export(typeof(IViewFor<IEditableActSelectionOfProbeDepartmentRequirementViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableActSelectionOfProbeDepartmentRequirementView : UserControl, IViewFor<IEditableActSelectionOfProbeDepartmentRequirementViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~EditableActSelectionOfProbeDepartmentRequirementView()
        {
            LogManager.Log.Debug("EditableActSelectionOfProbeDepartmentRequirementView IS DESTROYED");
        }

        public EditableActSelectionOfProbeDepartmentRequirementView()
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
            set { this.ViewModel = (IEditableActSelectionOfProbeDepartmentRequirementViewModel)value; }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditableActSelectionOfProbeDepartmentRequirementViewModel ViewModel
        {
            get { return this.DataContext as IEditableActSelectionOfProbeDepartmentRequirementViewModel; }
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

        
            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);
        }
    }
}