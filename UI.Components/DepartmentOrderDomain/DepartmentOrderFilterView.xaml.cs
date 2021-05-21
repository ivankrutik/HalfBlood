namespace UI.Components.DepartmentOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IViewFor<IDepartmentOrderFilterViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DepartmentOrderFilterView : UserControl, IViewFor<IDepartmentOrderFilterViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public DepartmentOrderFilterView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
            _disposableContext.Add(Binding());
        }

        public IDepartmentOrderFilterViewModel ViewModel
        {
            get { return DataContext as IDepartmentOrderFilterViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IDepartmentOrderFilterViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.BindCommand(ViewModel, vm => vm.InvokeCommand, v => v.BtnLoad);
        }
        private void StateOnChecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

//            var checkBox = (CheckBox)sender;
//            var state = (SightState)checkBox.Content;
//
//            ViewModel.Filter.Sight.State.Remove(state);
//
//            if (checkBox.IsChecked != null && (bool)checkBox.IsChecked)
//            {
//                ViewModel.Filter.Sight.State.Add(state);
//            }
        }
    }
}
