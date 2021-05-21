// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartWindow.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StartWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Shell
{
    using System;
    using System.Windows;

    using Halfblood.Common.Navigations;

    using MahApps.Metro.Controls;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    public partial class StartWindow : MetroWindow
    {
        private readonly IRoutableViewModelManager _routableViewModelManager;

        public StartWindow(
            IOwnerHostScreen ownerScreen, 
            IRoutableViewModelManager routableViewModelManager,
            ITitleBarHostScreen titleBarScreen)
        {
            _routableViewModelManager = routableViewModelManager;
            TitleBarHostScreen = titleBarScreen;
            OwnerHostScreen = ownerScreen;
            DataContext = this;

            InitializeComponent();
            MouseRightButtonDown += StartWindowMouseRightButtonDown;
            Loaded += StartWindowLoaded;
        }

        public IScreen TitleBarHostScreen { get; private set; }
        public IScreen OwnerHostScreen { get; private set; }

        private void StartWindowMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        private void StartWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= StartWindowLoaded;
            OwnerHostScreen.Router.NavigateAndReset.Execute(_routableViewModelManager.Get<ILoginViewModel>());
        }
    }
}