namespace UI.Components.Common
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    [Export(typeof(IViewFor<ITestViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TestView : UserControl, IViewFor<ITestViewModel>
    {
        public TestView()
        {
            InitializeComponent();
        }

        ~TestView()
        {
            LogManager.Log.Debug("TestView");
        }

        public ITestViewModel ViewModel
        {
            get { return DataContext as ITestViewModel; }
            set
            {
                DataContext = value;
                VMVH.ViewModel = new InnerViewModel(value.HostScreen);
            }
        }
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ITestViewModel)value; }
        }
    }

    [Export(typeof(ITestViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestViewModel : ReactiveObject, ITestViewModel
    {
        [ImportingConstructor]
        public TestViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        ~TestViewModel()
        {
            LogManager.Log.Debug("TestViewModel");
        }

        public string TestText
        {
            get
            {
                return "TEST";
            }
        }
        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
    }

    public interface ITestViewModel : IRoutableViewModel
    {
        string TestText { get; }
    }

    [Export(typeof(IViewFor<InnerViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InnerView : UserControl, IViewFor<InnerViewModel>
    {
        ~InnerView()
        {
            LogManager.Log.Debug("InnerView");
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (InnerViewModel)value; }
        }

        public InnerViewModel ViewModel { get; set; }
    }

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InnerViewModel : ReactiveObject, IRoutableViewModel
    {
        ~InnerViewModel()
        {
            LogManager.Log.Debug("InnerViewModel");
        }

        [ImportingConstructor]
        public InnerViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
    }
}
