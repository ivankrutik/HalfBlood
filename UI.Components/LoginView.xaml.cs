// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginView.xaml.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the LoginView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common.Log;

    using ReactiveUI;

    using UI.Components.Helpers;
    using UI.Infrastructure.ViewModels;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IViewFor<ILoginViewModel>))]
    public partial class LoginView : UserControl, IViewFor<ILoginViewModel>
    {
        private readonly DisposableContext _disposableContext;

        public LoginView()
        {
            InitializeComponent();
            _disposableContext = new DisposableContext(this);
            Loaded += LoginViewLoaded;
        }

        ~LoginView()
        {
            LogManager.Log.Debug("LoginView IS DESTROYED");
        }

        public ILoginViewModel ViewModel
        {
            get { return DataContext as ILoginViewModel; }
            set
            {
                DataContext = value;
                _disposableContext.Dispose();
                _disposableContext.Add(Binding());
                _disposableContext.Add(() => DataContext = null);
            }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (ILoginViewModel)value; }
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return this.OneWayBind(ViewModel, vm => vm.IsConnecting, v => v.ProgressRing.IsActive);
            yield return this.OneWayBind(ViewModel, vm => vm.IsConnecting, v => v.Root.IsEnabled, isConnecting => !isConnecting);
            
            yield return this.Bind(ViewModel, vm => vm.AuthorizationMetadata.Password, v => v.PasswordBox.Password);
            yield return this.Bind(ViewModel, vm => vm.AuthorizationMetadata.Login, v => v.Login.Text);
            yield return this.Bind(ViewModel, vm => vm.AuthorizationMetadata.Database, v => v.Database.Text);
            yield return this.OneWayBind(ViewModel, vm => vm.LastUsersMetadata, v => v.Login.ItemsSource);

            yield return this.BindCommand(ViewModel, vm => vm.AuthorizeCommand, v => v.DoConnect);
            yield return
                Observable.FromEventPattern<KeyEventHandler, KeyEventArgs>(
                    h => Root.KeyDown += h,
                    h => Root.KeyDown -= h)
                    .Where(args => args.EventArgs.Key == Key.Enter)
                    .Where(_ => ViewModel.AuthorizeCommand != null && ViewModel.AuthorizeCommand.CanExecute(null))
                    .Subscribe(_ => {
                        FillPassword();
                        ViewModel.AuthorizeCommand.Execute(null);
                    });
        }
        private void DoConnect_OnClick(object sender, RoutedEventArgs e)
        {
            FillPassword();
        }
        private void FillPassword()
        {
            ViewModel.AuthorizationMetadata.Password = PasswordBox.Password;
        }
        private void LoginViewLoaded(object sender, RoutedEventArgs e)
        {
            PasswordBox.Focus();
            Keyboard.Focus(PasswordBox);
        }

        private void Login_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Database.Text = ViewModel.LastUsersMetadata.ContainsKey(ViewModel.AuthorizationMetadata.Login)
                ? ViewModel.LastUsersMetadata[ViewModel.AuthorizationMetadata.Login]
                : String.Empty;
        }
    }
}