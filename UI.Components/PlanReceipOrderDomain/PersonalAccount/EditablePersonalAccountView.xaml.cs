// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditablePersonalAccountView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EditPersonalAccountView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.PlanReceipOrderDomain.PersonalAccount
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The editable personal account view.
    /// </summary>
    [Export(typeof(IViewFor<IEditablePersonalAccountViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditablePersonalAccountView : UserControl, IViewFor<IEditablePersonalAccountViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditablePersonalAccountView"/> class.
        /// </summary>
        public EditablePersonalAccountView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IEditablePersonalAccountViewModel ViewModel
        {
            get { return DataContext as IEditablePersonalAccountViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                //_disposableContext.Add(ContractView);
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditablePersonalAccountViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            Title.Text = ViewModel.EditState == EditState.Insert ? CustomMessages.Creation : CustomMessages.Editing;

            yield return this.BindCommand(ViewModel, vm => vm.ApplyCommand, v => v.BtnApply);

            yield return
                AcbContract.Binding(
                    ViewModel.PersonalAccountFilterViewModel,
                    (model, s) => model.Filter.Numb = s,
                    isBusy => BusyAcbContract.Visibility = isBusy.ToVisibility());

            yield return
                this.Bind(ViewModel, vm => vm.UserContractor.TableNumber, v => v.AcbContract.Text);
        }
    }
}