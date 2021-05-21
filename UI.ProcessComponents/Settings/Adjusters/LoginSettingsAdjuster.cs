namespace UI.ProcessComponents.Settings.Adjusters
{
    using Halfblood.Common.Settings.Adjuster;

    using UI.Infrastructure.ViewModels;

    [Adjuster(AdjustableType = typeof(ILoginViewModel), SettingType = typeof(LoginSetting))]
    public class LoginSettingsAdjuster : ObjectAdjusterBase<ILoginViewModel, LoginSetting>
    {
        public override string Name
        {
            get { return "LoginSetting"; }
        }

        public override bool Adjust(ILoginViewModel adjustable, LoginSetting setting)
        {
            adjustable.LastUsersMetadata = setting.LastUsersMetadata;
            adjustable.AuthorizationMetadata.Login = setting.LastAuthentificationCompletedUser;
            adjustable.AuthorizationMetadata.Database = setting.LastUsersMetadata[setting.LastAuthentificationCompletedUser];
            return true;
        }
    }
}
