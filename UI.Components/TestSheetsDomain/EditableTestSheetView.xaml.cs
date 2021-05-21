using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using Buisness.Entities.TestSheetDomain;
using ReactiveUI;
using UI.Infrastructure.ViewModels.TestSheetsDomain;

namespace UI.Components.TestSheetsDomain
{
    /// <summary>
    ///     Логика взаимодействия для EditableTestSheetView.xaml
    /// </summary>
    [Export(typeof(IViewFor<IEditableTestSheetViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditableTestSheetView : UserControl, IViewFor<IEditableTestSheetViewModel>
    {
        public EditableTestSheetView()
        {
            InitializeComponent();
        }

        public IEditableTestSheetViewModel ViewModel
        {
            get { return DataContext as IEditableTestSheetViewModel; }
            set { DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IEditableTestSheetViewModel)value; }
        }

        #region Hide DataGrid empty columns

        private void DgTestResults_OnLoaded(object sender, RoutedEventArgs e)
        {
            HideEmptyDataGridColumns(ref sender);
        }

        private void DgTestResults_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideEmptyDataGridColumns(ref sender);
        }

        private void HideEmptyDataGridColumns(ref object dtGrid)
        {
            var dg = (DataGrid)dtGrid;
            List<bool> vl = VisibilityList((TestResultDto)dg.DataContext);
            for (int colNum = 1; colNum < dg.Columns.Count; colNum++)
                dg.Columns[colNum].Visibility = vl[colNum - 1] ? Visibility.Visible : Visibility.Collapsed;
        }

        private List<bool> VisibilityList(TestResultDto dto)
        {
            var counter = new int[10];
            foreach (SampleResultSetDto item in dto.SampleResultSets)
            {
                if (!string.IsNullOrEmpty(item.Value1)) counter[0]++;
                if (!string.IsNullOrEmpty(item.Value2)) counter[1]++;
                if (!string.IsNullOrEmpty(item.Value3)) counter[2]++;
                if (!string.IsNullOrEmpty(item.Value4)) counter[3]++;
                if (!string.IsNullOrEmpty(item.Value5)) counter[4]++;
                if (!string.IsNullOrEmpty(item.Value6)) counter[5]++;
                if (!string.IsNullOrEmpty(item.Value7)) counter[6]++;
                if (!string.IsNullOrEmpty(item.Value8)) counter[7]++;
                if (!string.IsNullOrEmpty(item.Value9)) counter[8]++;
                if (!string.IsNullOrEmpty(item.Value10)) counter[9]++;
            }
            return counter.Select(x => x > 0).ToList();
        }

        #endregion

        private void FrameworkElement_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            var dg = (sender as DataGrid);
            dg.CommitEdit();
            dg.CancelEdit();
        }
    }
}