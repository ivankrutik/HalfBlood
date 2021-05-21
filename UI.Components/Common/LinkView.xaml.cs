namespace UI.Components.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Controls;

    using ReactiveUI;
    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels.Common;

    [Export(typeof(IViewFor<ILinkViewModel>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class LinkView : UserControl, IViewFor<ILinkViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public ILinkViewModel ViewModel
        {
            get { return DataContext as ILinkViewModel; }
            set
            {
                DataContext = value;
                Binding().DoForEach(x => { });
            }
        }

        private GraphHelper _graphHelper;

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ILinkViewModel)value; }
        }

        public LinkView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
            Initialize();
        }


        private void Initialize()
        {
            _graphHelper = new GraphHelper();

            CmbTypeLayout.ItemsSource = _graphHelper.LayoutAlgorithmTypes;
            this.GraphLayout.LayoutAlgorithmType = TypeAlgoritm.EfficientSugiyama.ToString();
            this.GraphLayout.HighlightAlgorithmType = "Simple";
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return ViewModel.WhenAny(x => x.LinksDtos, x => x.Value)
                .Where(x => x != null)
                .Subscribe(x => { _graphHelper.SetData(x); this.GraphLayout.Graph = _graphHelper.Graph; });
            yield return this.Bind(ViewModel, vm => vm.Direction, v => v.CmbTypeDirection.SelectedItem);
            yield return this.Bind(ViewModel, vm => vm.IsFrozen, v => v.ChbFrozen.IsChecked);
        }

        private void CmbTypeLayout_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.GraphLayout.LayoutAlgorithmType = CmbTypeLayout.SelectedItem.ToString();
        }

        private void CmbTypeDirection_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.Load();
        }
    }
}
