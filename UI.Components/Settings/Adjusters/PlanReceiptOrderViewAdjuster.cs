namespace UI.Components.Settings.Adjusters
{
    using System.Linq;
    using System.Windows.Controls;

    using Halfblood.Common.Settings.Adjuster;

    using UI.Components.PlanReceipOrderDomain.PlanReceiptOrder;

    [Adjuster(AdjustableType = typeof(IPlanReceiptOrderView), SettingType = typeof(PlanReceiptOrderViewSetting))]
    public class PlanReceiptOrderViewAdjuster : ObjectAdjusterBase<IPlanReceiptOrderView, PlanReceiptOrderViewSetting>
    {
        public override string Name
        {
            get { return "PlanReceiptOrderViewSetting"; }
        }

        public override bool Adjust(IPlanReceiptOrderView adjustable, PlanReceiptOrderViewSetting setting)
        {
            foreach (DataGridColumnMetadata columnMetadata in setting.DataGridColumns)
            {
                DataGridColumn column =
                    adjustable.DataGrid.Columns.FirstOrDefault(x => x.Header.ToString() == columnMetadata.Name);

                if (column != null)
                {
                    column.SortDirection = columnMetadata.SortDirection;
                    column.Width = new DataGridLength(columnMetadata.Width);
                    column.DisplayIndex = columnMetadata.DisplayIndex;
                }
            }

            return true;
        }
    }
}