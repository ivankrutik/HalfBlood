namespace UI.Components.Settings
{
    using Halfblood.Common.Settings;

    [Setting(PersistSetting.Remote)]
    public class PostingOfInventoryAtTheWarehouseViewSetting : ISetting
    {
        public PostingOfInventoryAtTheWarehouseViewSetting()
        {
            HeightGrid = 200;
        }

        public const string SETTING_NAME = "PostingOfInventoryAtTheWarehouseViewSetting";
        public double HeightGrid { get; set; }
        public bool IsExpanded { get; set; }

        public string Name
        {
            get { return SETTING_NAME; }
        }
    }
}
