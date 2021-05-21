// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authorization.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Authorization type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.AcceptanceTests.Steps
{
    using System;

    using Halfblood.Common.Helpers;

    using TechTalk.SpecFlow;

    using UI.Infrastructure.ViewModels;

    [Binding]
    public class Authorization : StepBase
    {
        private readonly ILoginViewModel _loginViewModel;

        public Authorization()
        {
            _loginViewModel = Bootstrapper.IoC.GetExportedValue<ILoginViewModel>();
        }

        [Given]
        public void Допустим_Я_нахожусь_на_странице_авторизации()
        {
        }

        [Given]
        public void Допустим_я_ввёл_свой_логин()
        {
            _loginViewModel.AuthorizationMetadata.Login = "parus";
        }

        [Given]
        public void Допустим_я_ввёл_свой_пароль()
        {
            _loginViewModel.AuthorizationMetadata.Password = "q";
            _loginViewModel.AuthorizationMetadata.Database = "dupparus.ora.vz";
        }

        [When]
        public void Если_я_нажимаю_кнопку_Войти()
        {
            _loginViewModel.AuthorizeCommand.Execute(null);
            _loginViewModel.Wait();
        }

        [Then]
        public void То_я_вижу_окно_для_работы_с_ППО()
        {
            if (!_loginViewModel.IsConnected)
            {
                throw new Exception(
                    "Не удалось пройти авторизацию {0}".StringFormat(_loginViewModel.AuthorizationMetadata.ToString()));
            }
        }
    }
}
