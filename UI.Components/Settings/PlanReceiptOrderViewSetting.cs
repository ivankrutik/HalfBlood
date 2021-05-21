namespace UI.Components.Settings
{
    using System.Linq;

    using Halfblood.Common.Settings;

    [Setting(PersistSetting.Remote)]
    public class PlanReceiptOrderViewSetting : DataGridSetting
    {
        public const string SETTING_NAME = "PlanReceiptOrderViewSetting";

        public override string Name
        {
            get { return SETTING_NAME; }
        }

        public override bool IsEmpty()
        {
            return DataGridColumns == null || !DataGridColumns.Any();
        }
    }
}