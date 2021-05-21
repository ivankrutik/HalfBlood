namespace UI.ProcessComponents.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Halfblood.Common;
    using Halfblood.Common.Interceptors;
    using UI.Infrastructure.ViewModels;
    using Halfblood.Common.Settings;
    using ReactiveUI;
    using UI.Infrastructure.Messages;
    using UI.ProcessComponents.Settings;

    [Interceptor]
    public class LoginViewModelInterceptor : InterceptorBase<ILoginViewModel>
    {
        private readonly IMessageBus _messageBus;
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly object _locker = new object();
        private readonly ISettingManagerFactory _settingManagerFactory;
        private WeakReference _weakReference;

        [ImportingConstructor]
        public LoginViewModelInterceptor(IMessageBus messageBus,
            ISettingManagerFactory settingManagerFactory)
        {
            _messageBus = messageBus;
            _settingManagerFactory = settingManagerFactory;

        }

        public override void Intercept(ILoginViewModel interceptableObject)
        {
            lock (_locker)
            {
                _weakReference = new WeakReference(interceptableObject);

                _disposableObject.Dispose();
                _disposableObject.Add(Listen());
            }
        }

        private IEnumerable<IDisposable> Listen()
        {
            yield return _messageBus.Listen<AuthentificationCompletedMessage>().Subscribe(SaveSetting);
        }

        private void SaveSetting(AuthentificationCompletedMessage authentificationCompletedMessage)
        {
            var target = GetTarget();

            var setting = new LoginSetting { LastUsersMetadata = target.LastUsersMetadata, LastAuthentificationCompletedUser = target.AuthorizationMetadata.Login };
            var settingManager = _settingManagerFactory.Create(PersistSetting.Local);
            settingManager.RegisterChanges(setting);
        }


        private ILoginViewModel GetTarget()
        {
            lock (_locker)
            {
                if (_weakReference != null && _weakReference.IsAlive)
                {
                    return (ILoginViewModel)_weakReference.Target;
                }
            }

            return null;
        }
    }
}
