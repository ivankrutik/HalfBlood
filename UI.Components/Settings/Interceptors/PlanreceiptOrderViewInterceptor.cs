namespace UI.Components.Settings.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Windows.Controls;

    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Settings;

    using ReactiveUI.Xaml;

    using UI.Components.PlanReceipOrderDomain.PlanReceiptOrder;

    [Interceptor]
    public class PlanReceiptOrderViewInterceptor : InterceptorBase<IPlanReceiptOrderView>
    {
        private readonly ISettingManagerFactory _settingManagerFactory;
        private static PlanReceiptOrderViewSetting _setting;

        [ImportingConstructor]
        public PlanReceiptOrderViewInterceptor(ISettingManagerFactory settingManagerFactory)
        {
            _settingManagerFactory = settingManagerFactory;
        }

        public override void Intercept(IPlanReceiptOrderView interceptableObject)
        {
            IDisposable disposableLoaded = Disposable.Empty;
            disposableLoaded = interceptableObject.LoadedNotification.Subscribe(_ => {
                disposableLoaded.Dispose();

                InitSetting(interceptableObject.DataGrid);
                IDisposable disposableTrack = interceptableObject.DataGrid.Track(_setting);

                IDisposable disposable = Disposable.Empty;
                disposable = interceptableObject.UnloadedNotification.Subscribe(__ => {
                    disposableTrack.Dispose();
                    disposable.Dispose();
                });
            });
        }

        private void InitSetting(DataGrid dataGrid)
        {
            if (_setting == null)
            {
                ISettingsManager settingsManager = _settingManagerFactory.Create(PersistSetting.Remote);
                _setting =
                    settingsManager.GetSetting(PlanReceiptOrderViewSetting.SETTING_NAME) as PlanReceiptOrderViewSetting;
                if (_setting == null || _setting.IsEmpty())
                {
                    _setting = new PlanReceiptOrderViewSetting();
                    IEnumerable<DataGridColumnMetadata> columnMetadatas = GetColumns(dataGrid);
                    columnMetadatas.DoForEach(column => _setting.DataGridColumns.Add(column));
                }

                settingsManager.RegisterChanges(_setting);
            }
        }
        private IEnumerable<DataGridColumnMetadata> GetColumns(DataGrid dataGrid)
        {
            return
                dataGrid.Columns.Select(
                    dataGridColumn =>
                    new DataGridColumnMetadata {
                            DisplayIndex = dataGridColumn.DisplayIndex,
                            SortDirection = dataGridColumn.SortDirection,
                            Width = dataGridColumn.ActualWidth,
                            Name = dataGridColumn.Header.ToString()
                    });
        }
    }

    public static class TrackerDataGrid
    {
        public static IDisposable Track(this DataGrid dataGrid, DataGridSetting dataGridSetting)
        {
            EventHandler<DataGridColumnEventArgs> columnDisplayIndexChanged =
                (sender, args) => DataGridColumnDisplayIndexChanged(dataGridSetting, args);
            DataGridSortingEventHandler dataGridSortingChanged =
                (sender, args) => DataGridSorting(dataGridSetting, args);

            dataGrid.ColumnDisplayIndexChanged += columnDisplayIndexChanged;
            dataGrid.Sorting += dataGridSortingChanged;

            var notifiers = new List<PropertyChangeNotifier>();

            foreach (var column in dataGrid.Columns)
            {
                EventHandler ev = (sender, x) => WidthChanged(column, dataGridSetting);
                var notifier = new PropertyChangeNotifier(column, DataGridColumn.ActualWidthProperty);
                notifier.ValueChanged += ev;
                notifiers.Add(notifier);
            }

            return Disposable.Create(() => {
                dataGrid.ColumnDisplayIndexChanged -= columnDisplayIndexChanged;
                dataGrid.Sorting -= dataGridSortingChanged;
                notifiers.DoForEach(
                    notifier => notifier.Dispose());
            });
        }

        private static void WidthChanged(DataGridColumn dataGridColumn, DataGridSetting dataGridSetting)
        {
            DataGridColumnMetadata column =
                dataGridSetting.DataGridColumns.FirstOrDefault(x => x.Name == dataGridColumn.Header.ToString());

            if (column != null)
            {
                column.Width = dataGridColumn.ActualWidth;
            }
        }
        private static void DataGridSorting(DataGridSetting dataGridSetting, DataGridColumnEventArgs e)
        {
            DataGridColumnMetadata column =
                dataGridSetting.DataGridColumns.FirstOrDefault(x => x.Name == e.Column.Header.ToString());

            if (column != null)
            {
                column.SortDirection = e.Column.SortDirection;
            }
        }
        private static void DataGridColumnDisplayIndexChanged(DataGridSetting dataGridSetting, DataGridColumnEventArgs e)
        {
            DataGridColumnMetadata column =
                dataGridSetting.DataGridColumns.FirstOrDefault(x => x.Name == e.Column.Header.ToString());

            if (column != null)
            {
                column.DisplayIndex = e.Column.DisplayIndex;
            }
        }
    }
}
