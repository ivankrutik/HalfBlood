// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Interaction logic for MainPageView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Infrastructure;

    /// <summary>
    /// The navigation view.
    /// </summary>
    [Export(typeof(IViewFor<IMainPageViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MainPageView : UserControl, IViewFor<IMainPageViewModel>
    {
        ~MainPageView()
        {
            LogManager.Log.Debug("MainPageView IS DESTROYED");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageView"/> class.
        /// </summary>
        public MainPageView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IMainPageViewModel ViewModel
        {
            get { return DataContext as IMainPageViewModel; }
            set { DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (IMainPageViewModel)value; }
        }
    }
}