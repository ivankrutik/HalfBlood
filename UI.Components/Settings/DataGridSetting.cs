namespace UI.Components.Settings
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Halfblood.Common.Settings;

    public abstract class DataGridSetting : ISetting
    {
        protected DataGridSetting()
        {
            DataGridColumns = new List<DataGridColumnMetadata>();
        }

        public abstract string Name { get; }
        public abstract bool IsEmpty();
        public IList<DataGridColumnMetadata> DataGridColumns { get; private set; }
    }

    public interface IDataGridColumnMetadata
    {
        int DisplayIndex { get; set; }
        string Name { get; set; }
        double Width { get; set; }
        ListSortDirection? SortDirection { get; set; }
    }
    public class DataGridColumnMetadata : IDataGridColumnMetadata
    {
        public int DisplayIndex { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public ListSortDirection? SortDirection { get; set; }
    }
}
