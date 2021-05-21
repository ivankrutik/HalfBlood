// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeFilterView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The pro filter view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace UI.Components.Filters
{
    using Buisness.Filters;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using Halfblood.Common;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The pro filter view.
    /// </summary>
    [Export(typeof(IViewFor<IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeDto>>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ActSelectionOfProbeFilterView : UserControl, IViewFor<IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto>>
    {
        private readonly DisposableContext _disposableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbeFilterView"/> class.
        /// </summary>
        public ActSelectionOfProbeFilterView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto> ViewModel
        {
            get { return this.DataContext as IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto>; }
            set
            {
                this.DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto>)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);
        }
        
        private void ActSelectionOfProbeStateOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var state = (ActSelectionOfProbeState)checkBox.Content;

            ViewModel.Filter.State.Remove(state);

            if ((bool)checkBox.IsChecked)
            {
                ViewModel.Filter.State.Add(state);
            }
        }
    }
}