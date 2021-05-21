// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProFilterView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ProFilterView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;
    using Halfblood.Common;
    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The pro filter view.
    /// </summary>
    [Export(typeof(IViewFor<ICuttingOrderFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CuttingOrderFilterView : UserControl, IViewFor<ICuttingOrderFilterViewModel>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProFilterView"/> class.
        /// </summary>
        public CuttingOrderFilterView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ICuttingOrderFilterViewModel ViewModel
        {
            get { return this.DataContext as ICuttingOrderFilterViewModel; }
            set
            {
                this.DataContext = value;
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
            set { this.ViewModel = (ICuttingOrderFilterViewModel)value; }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);
        }

        /// <summary>
        /// The plan receipt order state on checked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CuttingOrderStateOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var state = (CuttingOrderState)checkBox.Content;

            ViewModel.Filter.State.Remove(state);

            if ((bool)checkBox.IsChecked)
            {
                ViewModel.Filter.State.Add(state);
            }
        }
    }
}