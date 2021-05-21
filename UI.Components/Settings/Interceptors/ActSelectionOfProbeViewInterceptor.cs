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
    using UI.Components.CertificateQualityDomain.ActSelectionProbeDomain;

    //[Interceptor]
    public class ActSelectionOfProbeViewInterceptor : InterceptorBase<ActSelectionOfProbeView>
    {
        private readonly ISettingManagerFactory _settingManagerFactory;
        private static ActSelectionOfProbeViewSetting _setting;
        [ImportingConstructor]
        public ActSelectionOfProbeViewInterceptor(ISettingManagerFactory settingManagerFactory)
        {
            _settingManagerFactory = settingManagerFactory;
        }

        public override void Intercept(ActSelectionOfProbeView interceptableObject)
        {
            IDisposable disposableLoaded = Disposable.Empty;
            disposableLoaded = interceptableObject.LoadedNotification.Subscribe(_ =>
            {
                disposableLoaded.Dispose();

                InitSetting(interceptableObject.DataGridActSelectionOfProbe);
                IDisposable disposableTrack2 = TrackRowDefinition(interceptableObject.RootContentGrid.RowDefinitions[0]);
                IDisposable disposableTrack1 = IsExpanded(interceptableObject.ExpanderFilter);

                IDisposable disposableTrack = TrackDataGrid(interceptableObject.DataGridActSelectionOfProbe);

                IDisposable disposable = Disposable.Empty;
                disposable = interceptableObject.UnloadedNotification.Subscribe(__ =>
                {
                    disposableTrack.Dispose();
                    disposableTrack1.Dispose();
                    disposableTrack2.Dispose();
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
                    settingsManager.GetSetting(ActSelectionOfProbeViewSetting.SETTING_NAME) as ActSelectionOfProbeViewSetting;
                if (_setting == null)
                {
                    _setting = new ActSelectionOfProbeViewSetting();
                    IEnumerable<DataGridColumnMetadata> columnMetadatas = GetColumns(dataGrid);
                    columnMetadatas.DoForEach(column => _setting.Dtg1.DataGridColumns.Add(column));
                }

                settingsManager.RegisterChanges(_setting);
            }
        }
        private IDisposable TrackDataGrid(DataGrid dataGrid)
        {
            dataGrid.ColumnDisplayIndexChanged += DataGridColumnDisplayIndexChanged;
            dataGrid.Sorting += DataGridSorting;

            var notifiers = new List<PropertyChangeNotifier>();

            foreach (var column in dataGrid.Columns)
            {
                EventHandler ev = (sender, x) => WidthChanged(column);
                var notifier = new PropertyChangeNotifier(column, DataGridColumn.ActualWidthProperty);
                notifier.ValueChanged += ev;
                notifiers.Add(notifier);
            }

            return Disposable.Create(() =>
            {
                dataGrid.ColumnDisplayIndexChanged -= DataGridColumnDisplayIndexChanged;
                dataGrid.Sorting -= DataGridSorting;
                notifiers.DoForEach(
                    notifier => notifier.Dispose());
            });
        }
        private IEnumerable<DataGridColumnMetadata> GetColumns(DataGrid dataGrid)
        {
            return
                dataGrid.Columns.Select(
                    dataGridColumn =>
                    new DataGridColumnMetadata
                    {
                        DisplayIndex = dataGridColumn.DisplayIndex,
                        SortDirection = dataGridColumn.SortDirection,
                        Width = dataGridColumn.ActualWidth,
                        Name = dataGridColumn.Header.ToString()
                    });
        }
        private IDisposable IsExpanded(Expander expander)
        {
            EventHandler ev = (s, x) => IsExpandedChanged(expander);
            var notifer = new PropertyChangeNotifier(expander, Expander.IsExpandedProperty);
            notifer.ValueChanged += ev;
            return Disposable.Create(notifer.Dispose);
        }
        private IDisposable TrackRowDefinition(RowDefinition rowDefinition)
        {
            EventHandler ev = (s, x) => HeightChanged(rowDefinition);
            var notifier = new PropertyChangeNotifier(rowDefinition, RowDefinition.HeightProperty);
            notifier.ValueChanged += ev;
            return Disposable.Create(notifier.Dispose);
        }
        private void IsExpandedChanged(Expander expander)
        {
            _setting.IsExpanded = expander.IsExpanded;
        }
        private void HeightChanged(RowDefinition rowDefinition)
        {
            _setting.HeightGrid = rowDefinition.ActualHeight;
        }

        private void WidthChanged(DataGridColumn dataGridColumn)
        {
            DataGridColumnMetadata column =
                _setting.Dtg1.DataGridColumns.FirstOrDefault(x => x.Name == dataGridColumn.Header.ToString());

            if (column != null)
            {
                column.Width = dataGridColumn.ActualWidth;
            }
        }
        private void DataGridSorting(object sender, DataGridSortingEventArgs e)
        {
            DataGridColumnMetadata column =
                _setting.Dtg1.DataGridColumns.FirstOrDefault(x => x.Name == e.Column.Header.ToString());

            if (column != null)
            {
                column.SortDirection = e.Column.SortDirection;
            }
        }
        private void DataGridColumnDisplayIndexChanged(object sender, DataGridColumnEventArgs e)
        {
            DataGridColumnMetadata column =
                _setting.Dtg1.DataGridColumns.FirstOrDefault(x => x.Name == e.Column.Header.ToString());

            if (column != null)
            {
                column.DisplayIndex = e.Column.DisplayIndex;
            }
        }
    }
}
