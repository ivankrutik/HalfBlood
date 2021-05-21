// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TitleBarView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Логика взаимодействия для TitleBar.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Halfblood.Common.Connection;

    using ReactiveUI;
    using UI.Infrastructure;

    [Export(typeof(IViewFor<ITitleBarViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TitleBarView : UserControl, IViewFor<ITitleBarViewModel>, IPartImportsSatisfiedNotification
    {
        [Import] private IHasAuthentificationMetadata _hasAuthMetadata;

        public TitleBarView()
        {
            InitializeComponent();
        }

        public ITitleBarViewModel ViewModel
        {
            get { return DataContext as ITitleBarViewModel; }
            set { DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ITitleBarViewModel)value; }
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            TextBlock.Text = string.Format(
                "{0}@{1}",
                _hasAuthMetadata.AuthorizationMetadata.Login,
                _hasAuthMetadata.AuthorizationMetadata.Database);
        }
    }
}
