// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The login view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Halfblood.Common.Connection;
    using Halfblood.Common.Log;
    using Halfblood.Common.Navigations;

    using ReactiveUI;

    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels;

    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(ILoginViewModel))]
    [Export(typeof(IHasAuthentificationMetadata))]
    public class LoginViewModel : ReactiveObject, ILoginViewModel
    {
        #region private fields
        private readonly IConnection _connection;
        private readonly IMessageBus _messageBus;
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private ReactiveCommand _authorizeCommand;
        private bool _isConnecting;
        private Task _autorizationTask;
        private bool _isConnected;
        #endregion

        ~LoginViewModel()
        {
            LogManager.Log.Debug("LoginViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public LoginViewModel(
            IConnection connection,
            IOwnerHostScreen parentScreen,
            IMessageBus messageBus,
            IRoutableViewModelManager routableViewModelManager)
        {
            HostScreen = parentScreen;
            _connection = connection;
            _messageBus = messageBus;
            _routableViewModelManager = routableViewModelManager;
            AuthorizationMetadata = new AuthorizationMetadata();
        }

        public ICommand AuthorizeCommand
        {
            get
            {
                if (_authorizeCommand == null)
                {
                    var canExecuteAuth = this.AuthorizationMetadata.WhenAnyValue(
                        x => x.Login,
                        x => x.Database,
                        (l, d) =>
                        !string.IsNullOrWhiteSpace(l) && !string.IsNullOrWhiteSpace(d));

                    var canExecute =
                        canExecuteAuth.CombineLatest(
                            this.WhenAnyValue(x => x.IsConnecting).Select(isConnecting => !isConnecting),
                            (a, b) => a && b);

                    _authorizeCommand = new ReactiveCommand(canExecute);
                    _authorizeCommand.RegisterAsyncTask(_ =>
                    {
                        var task = GetAutorizeTask();
                        task.Start();
                        return task;
                    }).Subscribe(_ =>
                    {
                        LastUsersMetadata.Remove(AuthorizationMetadata.Login);
                        LastUsersMetadata.Add(AuthorizationMetadata.Login, AuthorizationMetadata.Database);

                        _messageBus.SendMessage(AuthentificationCompletedMessage.Create);
                        HostScreen.Router.NavigateAndReset.Execute(
                            _routableViewModelManager.Get<IMainPageViewModel>());
                    });

                    _authorizeCommand.ThrownExceptions.Subscribe(OnError);
                    _authorizeCommand.IsExecuting.Subscribe(isBusy => IsConnecting = isBusy);
                }

                return _authorizeCommand;
            }
        }
        public AuthorizationMetadata AuthorizationMetadata
        {
            get;
            private set;
        }

        public IDictionary<string, string> LastUsersMetadata { get; set; }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            private set { this.RaiseAndSetIfChanged(ref _isConnecting, value); }
        }
        public bool IsConnected
        {
            get { return this._isConnected; }
            private set { this.RaiseAndSetIfChanged(ref _isConnected, value); }
        }
        public string UrlPathSegment
        {
            get { return "LoginViewModel"; }
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }

        public void Wait()
        {
            if (_autorizationTask != null)
            {
                _autorizationTask.Wait();
            }
        }

        private Task GetAutorizeTask()
        {
            if (_autorizationTask == null || _autorizationTask.IsCompleted)
            {
                _autorizationTask = new Task(this.OnAuthorize);
            }

            return _autorizationTask;
        }
        private void OnAuthorize()
        {
            _connection.Connecting(
                AuthorizationMetadata.Login,
                AuthorizationMetadata.Password,
                AuthorizationMetadata.Database);

            IsConnected = true;
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Не удалось авторизироваться в системе", exception);
        }
    }
}
