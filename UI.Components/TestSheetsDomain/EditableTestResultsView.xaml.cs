using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;
using UI.Components.Helpers;
using UI.Infrastructure.ViewModels.TestSheetsDomain;

namespace UI.Components.TestSheetsDomain
{
    /// <summary>
    ///     Логика взаимодействия для EditableTestResultsView.xaml
    /// </summary>
    [Export(typeof (IViewFor<IEditableTestResultViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableTestResultsView : UserControl, IViewFor<IEditableTestResultViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public EditableTestResultsView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
        }

        public IEditableTestResultViewModel ViewModel
        {
            get { return DataContext as IEditableTestResultViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Disposable.Create(() => DataContext = null));
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IEditableTestResultViewModel) value; }
        }
    }
}