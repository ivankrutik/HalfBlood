// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitcherView.xaml.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Логика взаимодействия для SwitcherView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// Логика взаимодействия для SwitcherView.xaml
    /// </summary>
    [Export(typeof(IViewFor<ISwitcherViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SwitcherView : UserControl, IViewFor<ISwitcherViewModel>
    {
        ~SwitcherView()
        {
            LogManager.Log.Debug("SwitcherView IS DESTROYED");
        }

        public SwitcherView()
        {
            InitializeComponent();
        }

        public ISwitcherViewModel ViewModel
        {
            get { return this.DataContext as ISwitcherViewModel; }
            set
            {
                this.DataContext = value;
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ISwitcherViewModel)value; }
        }

        private void TileClick(object sender, RoutedEventArgs e)
        {
            var tile = sender as MahApps.Metro.Controls.Tile;
            Type resolveType = null;
            if (tile != null)
            {
                resolveType = tile.Tag as Type;
            }

            if (resolveType != null)
            {
                ViewModel.GoToPageCommand.Execute(resolveType);
            }
        }
    }
}
