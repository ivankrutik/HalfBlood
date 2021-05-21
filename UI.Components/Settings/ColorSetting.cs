namespace UI.Components.Settings
{
    using System.Drawing;

    using Halfblood.Common.Settings;

    using MahApps.Metro;

    [Setting(PersistSetting.Remote)]
    public class ColorSetting : ISetting
    {
        public ColorSetting()
        {
            Accent = Color.Blue;
            Theme = Theme.Dark;
        }

        public Color Accent { get; set; }
        public Theme Theme { get; set; }
        public string Name { get { return "ColorSetting"; } }
    }
}