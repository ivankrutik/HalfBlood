namespace UI.Components.Settings
{
    using Halfblood.Common.Settings;

    //[Setting(PersistSetting.Remote)]
    public class ActSelectionOfProbeViewSetting : ISetting
    {
        public const string SETTING_NAME = "ActSelectionOfProbeViewSetting";

        private DataGridSetting _dtg1;
        private DataGridSetting _dtg2;
        private DataGridSetting _dtg3;

        public DataGridSetting Dtg1 { get; set; }

        public DataGridSetting Dtg2 { get; set; }
        public DataGridSetting Dtg3 { get; set; }

        public double HeightGrid { get; set; }
        public bool IsExpanded { get; set; }

        public string Name
        {
            get { return SETTING_NAME; }
        }

        public ActSelectionOfProbeViewSetting()
        {
            HeightGrid = 200;
        }
    }
}
