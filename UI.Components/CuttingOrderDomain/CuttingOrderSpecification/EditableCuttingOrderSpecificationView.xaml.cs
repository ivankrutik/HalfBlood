namespace UI.Components.CuttingOrderDomain.CuttingOrderSpecification
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.CuttingOrderDomain;

    /// <summary>
    /// Логика взаимодействия для EditableCuttingOrderSpecificationView.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<IEditableCuttingOrderSpecificationViewModel>))]
    public partial class EditableCuttingOrderSpecificationView
        : UserControl, IViewFor<IEditableCuttingOrderSpecificationViewModel>
    {
        private readonly DisposableContext _disposableContext;
        
        public EditableCuttingOrderSpecificationView()
        {
            _disposableContext = new DisposableContext(this);
            InitializeComponent();
        }

        public IEditableCuttingOrderSpecificationViewModel ViewModel
        {
            get { return DataContext as IEditableCuttingOrderSpecificationViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                //_disposableContext.Add(Binding());
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IEditableCuttingOrderSpecificationViewModel)value; }
        }

        /// <summary>
        /// The binding.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        //private IEnumerable<IDisposable> Binding()
        //{
        //    //var cuttingOrderSpecificationViewModel = (IEditableCuttingOrderSpecificationViewModel)EditableCuttingOrderSpecificationView.ViewModel;

        //    //yield return
        //    //   this.OneWayBind(
        //    //       this.ViewModel, vm => vm.IsBusy, v => v.BusyIndicator.IsActive);

        //    //yield return
        //    //   ViewModel.WhenAny(x => x.IsBusy, x => x.Value)
        //    //            .Subscribe(isBusy => Root.IsEnabled = !isBusy);



        //    //foreach (IDisposable disposable in disposables)
        //    //{
        //    //    yield return disposable;
        //    //}

        //    //Title.Text = ViewModel.EditState == EditState.Insert ? "CustomMessages.Creation" : CustomMessages.ImageEditing;
        //}

    }
}
