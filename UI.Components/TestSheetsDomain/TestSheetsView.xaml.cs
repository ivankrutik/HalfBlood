using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;
using UI.Components.Helpers;
using UI.Infrastructure.ViewModels.TestSheetsDomain;

namespace UI.Components.TestSheetsDomain
{
    /// <summary>
    ///     Логика взаимодействия для TestSheetsView.xaml
    /// </summary>
    [Export(typeof (IViewFor<ITestSheetsViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TestSheetsView : UserControl, IViewFor<ITestSheetsViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public TestSheetsView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public ITestSheetsViewModel ViewModel
        {
            get { return DataContext as ITestSheetsViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
                _disposableContext.Add(this.BindCommand(ViewModel, vm => vm.UpdateTestSheetCommand, v => v.DgTestSheets,
                    "MouseDoubleClick"));
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ITestSheetsViewModel) value; }
        }
    }
}