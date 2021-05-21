namespace UI.Components.Settings.Adjusters
{
    using Halfblood.Common.Settings.Adjuster;
    using UI.Components.CertificateQualityDomain.ActSelectionProbeDomain;
    using System.Windows.Controls;
    using System.Linq;
    using System.Windows;

    //[Adjuster(AdjustableType = typeof(ActSelectionOfProbeView), SettingType = typeof(ActSelectionOfProbeViewSetting))]
    public class ActSelectionOfProbeViewAdjuster : ObjectAdjusterBase<ActSelectionOfProbeView, ActSelectionOfProbeViewSetting>
    {
        public override string Name
        {
            get { return "ActSelectionOfProbeViewSetting"; }
        }

        public override bool Adjust(ActSelectionOfProbeView adjustable, ActSelectionOfProbeViewSetting setting)
        {
            foreach (DataGridColumnMetadata columnMetadata in setting.Dtg1.DataGridColumns)
            {
                DataGridColumn column =
                    adjustable.DataGridActSelectionOfProbe.Columns.FirstOrDefault(x => x.Header.ToString() == columnMetadata.Name);

                if (column != null)
                {
                    column.SortDirection = columnMetadata.SortDirection;
                    column.Width = new DataGridLength(columnMetadata.Width);
                    column.DisplayIndex = columnMetadata.DisplayIndex;
                }
            }

            adjustable.RootContentGrid.RowDefinitions[0].Height = new GridLength(setting.HeightGrid);
            adjustable.ExpanderFilter.IsExpanded = setting.IsExpanded;
            return true;
        }
    }
}
