// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Interaction logic for ActSelectionOfProbeView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.CertificateQualityDomain.ActSelectionProbeDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;
    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain;
    using System.Reactive;
    using System.Reactive.Subjects;
    using System.Windows;

    /// <summary>
    /// Interaction logic for ActSelectionOfProbeView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IActSelectionOfProbeViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ActSelectionOfProbeView : UserControl, IViewFor<IActSelectionOfProbeViewModel>
    {
        #region private fields
        private readonly DisposableContext _disposableContext;
        private readonly Subject<Unit> _loadedNotificationSubject = new Subject<Unit>();
        private readonly Subject<Unit> _unloadedNotificationSubject = new Subject<Unit>();

        private readonly MenuItem _dataGridActSelectionOfProbeEditRowMenuItem;
        private readonly MenuItem _dataGridActSelectionOfProbeStateRowMenuItem;
        private readonly MenuItem _dataGridActSelectionOfProbeRemoveRowMenuItem;
        private readonly MenuItem _dataGridMakingSampleInsertRowMenuItem;
        private readonly MenuItem _dataGridMakingSampleEditRowMenuItem;
        private readonly MenuItem _dataGridMakingSamplePrintLabelRowMenuItem;
        private readonly MenuItem _dataGridMakingSampleRemoveRowMenuItem;
        private readonly MenuItem _dataGridMakingSampleChangeStatusRowMenuItem;
        private readonly MenuItem _dataGridMakingSampleInsertMenuItem;
        
        private readonly MenuItem _dataGridRequirementsInsertMenuItem;
        private readonly MenuItem _dataGridRequirementsInsertRowMenuItem;
        private readonly MenuItem _dataGridRequirementsRemoveRowMenuItem;
        private readonly MenuItem _dataGridRequirementsEditRowMenuItem;
        #endregion

        public ActSelectionOfProbeView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);


            _dataGridActSelectionOfProbeEditRowMenuItem = this.GetMenuItem("DataGridActSelectionOfProbeGridRowMenu", "DataGridActSelectionOfProbeEditRowMenuItem");
            _dataGridActSelectionOfProbeStateRowMenuItem = this.GetMenuItem("DataGridActSelectionOfProbeGridRowMenu", "DataGridActSelectionOfProbeStateRowMenuItem");
            _dataGridActSelectionOfProbeRemoveRowMenuItem = this.GetMenuItem("DataGridActSelectionOfProbeGridRowMenu", "DataGridActSelectionOfProbeRemoveRowMenuItem");

            _dataGridMakingSampleInsertRowMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridRowMenu", "DataGridMakingSampleInsertRowMenuItem");
            _dataGridMakingSampleEditRowMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridRowMenu", "DataGridMakingSampleEditRowMenuItem");

            _dataGridMakingSamplePrintLabelRowMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridRowMenu", "DataGridMakingSamplePrintLabelRowMenuItem");
            

            _dataGridMakingSampleRemoveRowMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridRowMenu", "DataGridMakingSampleRemoveRowMenuItem");
            _dataGridMakingSampleChangeStatusRowMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridRowMenu", "DataGridMakingSampleChangeStatusRowMenuItem");

            _dataGridMakingSampleInsertMenuItem = this.GetMenuItem("DataGridMakingSampleDataGridMenu", "DataGridMakingSampleInsertSendMenuItem");
            
            
            _dataGridRequirementsInsertMenuItem = this.GetMenuItem("DataGridRequirementsMenu", "DataGridRequirementsInsertMenuItem");
            _dataGridRequirementsInsertRowMenuItem = this.GetMenuItem("DataGridRequirementsRowMenu", "DataGridRequirementsInsertRowMenuItem");
            _dataGridRequirementsRemoveRowMenuItem = this.GetMenuItem("DataGridRequirementsRowMenu", "DataGridRequirementsRemoveRowMenuItem");
            _dataGridRequirementsEditRowMenuItem = this.GetMenuItem("DataGridRequirementsRowMenu", "DataGridRequirementsEditRowMenuItem");

        }

        public IActSelectionOfProbeViewModel ViewModel
        {
            get { return DataContext as IActSelectionOfProbeViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(this.Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IActSelectionOfProbeViewModel)value; }
        }

        public IObservable<Unit> LoadedNotification
        {
            get { return _loadedNotificationSubject; }
        }
        public IObservable<Unit> UnloadedNotification
        {
            get { return _unloadedNotificationSubject; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => Loaded += h, h => Loaded -= h)
               .Subscribe(_ => _loadedNotificationSubject.OnNext(Unit.Default));

            Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => Unloaded += h, h => Unloaded -= h)
                .Subscribe(_ => _unloadedNotificationSubject.OnNext(Unit.Default));

            yield return
                ViewModel.WhenAny(x => x.ActSelectionOfProbeFilter.IsBusy)
                    .Subscribe(isBusy => Root.IsEnabled = !isBusy);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.ActSelectionOfProbeFilter.IsBusy,
                    v => v.BusyControl.IsActive);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.ActSelectionOfProbeFilter,
                    v => v.ActSelectionOfProbeFilterView.ViewModel);

            yield return
                this.Bind(
                    ViewModel,
                    vm => vm.SelectedActSelectionOfProbe,
                    v => v.DataGridActSelectionOfProbe.SelectedItem);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.ActSelectionOfProbeFilter.Result,
                    v => v.DataGridActSelectionOfProbe.ItemsSource);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.SelectedActSelectionOfProbe,
                    v => v.GridInfo.DataContext);

            yield return
                this.OneWayBind(
                    ViewModel,
                    vm => vm.SelectedActSelectionOfProbe.ActSelectionOfProbeDepartments,
                    v => v.DataGridMakingSample.ItemsSource);


            yield return
                this.Bind(ViewModel, vm => vm.SelectedActSelectionOfProbeDepartment,
                    v => v.DataGridMakingSample.SelectedItem);




            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PreparingForEditActSelectionOfProbeCommand,
                    v => v._dataGridActSelectionOfProbeEditRowMenuItem,
                    () => EditState.Edit);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForAddActSelectionOfProbeDepartmentCommand,
                    v => v._dataGridMakingSampleInsertMenuItem,
                    () => EditState.Insert);
            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForAddActSelectionOfProbeDepartmentCommand,
                    v => v._dataGridMakingSampleInsertRowMenuItem,
                    () => EditState.Insert);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForEditActSelectionOfProbeDepartmentCommand,
                    v => v._dataGridMakingSampleEditRowMenuItem,
                    () => EditState.Edit);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForRemoveActSelectionOfProbeDepartmentCommand,
                    v => v._dataGridMakingSampleRemoveRowMenuItem);
            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PreparingForRemoveActSelectionOfProbeCommand,
                    v => v._dataGridActSelectionOfProbeRemoveRowMenuItem);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForAddActSelectionOfProbeDepartmentRequirementCommand,
                    v => v._dataGridRequirementsInsertMenuItem,
                    () => EditState.Insert);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForAddActSelectionOfProbeDepartmentRequirementCommand,
                    v => v._dataGridRequirementsInsertRowMenuItem,
                    () => EditState.Insert);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForEditActSelectionOfProbeDepartmentRequirementCommand,
                    v => v._dataGridRequirementsEditRowMenuItem,
                    () => EditState.Edit);

            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand,
                    v => v._dataGridRequirementsRemoveRowMenuItem);
            yield return
                this.BindCommand(
                    ViewModel,
                    vm => vm.PrinterLabelForActSelectionOfProbeDepartmentCommand,
                    v => v._dataGridMakingSamplePrintLabelRowMenuItem);
        }
    }
}
