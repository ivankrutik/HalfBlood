namespace UI.Components.Settings.Adjusters
{
    using System.Windows;

    using Halfblood.Common.Settings.Adjuster;

    using UI.Components.PlanReceipOrderDomain;

    [Adjuster(AdjustableType = typeof(PostingOfInventoryAtTheWarehouseView), SettingType = typeof(PostingOfInventoryAtTheWarehouseViewSetting))]
    public class PostingOfInventoryAtTheWarehouseViewAdjuster :
        ObjectAdjusterBase<PostingOfInventoryAtTheWarehouseView, PostingOfInventoryAtTheWarehouseViewSetting>
    {
        public override string Name
        {
            get { return "PostingOfInventoryAtTheWarehouseViewSetting"; }
        }

        public override bool Adjust(
            PostingOfInventoryAtTheWarehouseView adjustable,
            PostingOfInventoryAtTheWarehouseViewSetting setting)
        {
            adjustable.RootContentGrid.RowDefinitions[0].Height = new GridLength(setting.HeightGrid);
            adjustable.ExpanderFilter.IsExpanded = setting.IsExpanded;
            return true;
        }
    }
}
