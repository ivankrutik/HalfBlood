namespace Buisness.Workflows.Services
{
    using System;
    using System.ComponentModel.Composition;

    using Halfblood.Common;
    using Halfblood.Common.Exceptions;
    using Halfblood.Common.Settings;

    using NhConnection.Infrasctructure;

    using NHibernate;

    using ParusModel.Entities.Common;
    using ParusModel.Policy;

    [Register(typeof(ISettingsService))]
    [Export(typeof(ISettingsService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SettingsService : ISettingsService
    {
        private readonly INhConnection _nhConnection;
        private ISessionFactory _sessionFactory;
        private UserList _currentUser;
        private readonly Func<UserList> _getCurrentUser;

        [ImportingConstructor]
        public SettingsService(INhConnection nhConnection)
        {
            _nhConnection = nhConnection;
            _getCurrentUser = () => {
                if (_currentUser != null) {
                    return _currentUser;
                }

                using (IStatelessSession session = OpenSession())
                {
                    var currentUser = GetUser(session);

                    if (currentUser == null) {
                        throw new InsufficientPrivileges("The user is not specified or insufficient privileges");
                    }

                    return (_currentUser = currentUser);
                }
            };
        }

        public void SaveSetting(ISettingsModel settingModel)
        {
            using (IStatelessSession session = OpenSession())
            using (ITransaction tr = session.BeginTransaction())
            {
                if (ExistSetting(settingModel.Application))
                {
                    Settings settings = GetSettings(session, settingModel.Application);
                    if (settings.User != _getCurrentUser().AUTHID)
                    {
                        throw new InvalidOperationException("The setting belong to another user");
                    }
                }

                if (settingModel.Id == 0)
                {
                    session.Insert(
                        new Settings
                            {
                                Application = settingModel.Application,
                                SettingsInJson = settingModel.SettingsInJson,
                                User = _getCurrentUser().AUTHID,
                                Rn = settingModel.Id
                            });
                }
                else
                {
                    session.Update(
                        new Settings
                        {
                            Application = settingModel.Application,
                            SettingsInJson = settingModel.SettingsInJson,
                            User = _getCurrentUser().AUTHID,
                            Rn = settingModel.Id
                        });
                }

                tr.Commit();
            }
        }
        public bool ExistSetting(string appName)
        {
            using (IStatelessSession session = OpenSession())
            {
                return
                    session.QueryOver<Settings>()
                        .Where(x => x.Application == appName && x.User == _getCurrentUser().AUTHID)
                        .RowCount() == 1;
            }
        }
        public ISettingsModel Get(string appName)
        {
            using (IStatelessSession session = OpenSession())
            {
                var settings = GetSettings(session, appName);

                return new SettingsModel
                {
                    Application = settings.Application,
                    Id = settings.Rn,
                    SettingsInJson = settings.SettingsInJson
                };
            }
        }

        private IStatelessSession OpenSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = _nhConnection.GetSessionFactory();
            }

            return _sessionFactory.OpenStatelessSession();
        }
        private Settings GetSettings(IStatelessSession session, string appName)
        {
            return
                session.QueryOver<Settings>()
                    .Where(x => x.Application == appName && x.User == _getCurrentUser().AUTHID)
                    .UnderlyingCriteria.UniqueResult<Settings>();
        }
        private UserList GetUser(IStatelessSession session)
        {
            var userLogin = session.CreateSQLQuery("SELECT USER FROM DUAL").UniqueResult<string>();
            return
                session.QueryOver<UserList>()
                    .Where(x => x.AUTHID == userLogin)
                    .UnderlyingCriteria.UniqueResult<UserList>();
        }
    }
}
