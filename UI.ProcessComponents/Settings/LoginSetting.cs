namespace UI.ProcessComponents.Settings
{
    using Halfblood.Common.Settings;
    using System.Collections.Generic;

    [Setting(PersistSetting.Local)]
    public class LoginSetting : ISetting
    {
        public string Name
        {
            get { return "LoginSetting"; }
        }

        public LoginSetting()
        {
            LastUsersMetadata = new Dictionary<string, string>();
        }
        public  IDictionary<string,string> LastUsersMetadata { get; set; } 
        public  string  LastAuthentificationCompletedUser { get; set; }
    }
}
