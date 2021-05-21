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
    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IViewFor<IProFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ProFilterView : UserControl, IViewFor<IProFilterViewModel>
    {
        private readonly DisposableContext _disposableContext;

        ~ProFilterView()
        {
            LogManager.Log.Debug("ProFilterView IS DESTROYED");
        }

        public ProFilterView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public IProFilterViewModel ViewModel
        {
            get { return DataContext as IProFilterViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(() => DataContext = null);
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IProFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);
            yield return this.BindCommand(ViewModel, vm => vm.ClearFilterCommand, v => v.BtnClear);
        }
        private void PlanReceiptOrderStateOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var state = (PlanReceiptOrderState)checkBox.Content;

            ViewModel.Filter.States.Remove(state);

            if ((bool)checkBox.IsChecked)
            {
                ViewModel.Filter.States.Add(state);
            }
        }
    }
}