using Halfblood.Common;

namespace UI.Components.Settings.Interceptors
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Disposables;
    using System.Windows;
    using System.Windows.Controls;

    using Halfblood.Common.Interceptors;
    using Halfblood.Common.Settings;

    using ReactiveUI.Xaml;

    using UI.Components.PlanReceipOrderDomain;

    [Interceptor]
    public class PostingOfInventoryAtTheWarehouseViewInterceptor 
        : InterceptorBase<PostingOfInventoryAtTheWarehouseView>
    {
        private readonly ISettingManagerFactory _settingManagerFactory;
        private PostingOfInventoryAtTheWarehouseViewSetting _setting;
        private DisposableObject _disposable = new DisposableObject();

        [ImportingConstructor]
        public PostingOfInventoryAtTheWarehouseViewInterceptor(ISettingManagerFactory settingManagerFactory)
        {
            _settingManagerFactory = settingManagerFactory;
        }

        public override void Intercept(PostingOfInventoryAtTheWarehouseView interceptableObject)
        {
            interceptableObject.Loaded += InterceptableObjectLoaded;
            interceptableObject.Unloaded += InterceptableObjectUnloaded;
        }
         
        private void InterceptableObjectUnloaded(object sender, RoutedEventArgs e)
        {
            ((PostingOfInventoryAtTheWarehouseView)sender).Unloaded -= InterceptableObjectUnloaded;
            _disposable.Dispose();
        }
        private void InterceptableObjectLoaded(object sender, RoutedEventArgs e)
        {
            var target = (PostingOfInventoryAtTheWarehouseView)sender;
            target.Loaded -= InterceptableObjectLoaded;
            InitSetting();
            RowDefinition rowDefinition = target.RootContentGrid.RowDefinitions[0];
            _disposable.Add(TrackRowDefinition(rowDefinition));
            _disposable.Add(IsExpanded(target.ExpanderFilter));
        }
        private IDisposable TrackRowDefinition(RowDefinition rowDefinition)
        {
            EventHandler ev = (s, x) => HeightChanged(rowDefinition);
            var notifier = new PropertyChangeNotifier(rowDefinition, RowDefinition.HeightProperty);
            notifier.ValueChanged += ev;
            return Disposable.Create(notifier.Dispose);
        }

        private IDisposable IsExpanded(Expander expander)
        {
            //создаю событие
            EventHandler ev = (s, x) => IsExpandedChanged(expander);
            var notifer = new PropertyChangeNotifier(expander, Expander.IsExpandedProperty);
            notifer.ValueChanged += ev;
            return Disposable.Create(notifer.Dispose);
        }

        private void IsExpandedChanged(Expander expander)
        {
            //Присваиваю настройкам открыт или закрыт Expander из свой  ства IsExpanded
            _setting.IsExpanded = expander.IsExpanded;
        }

        private void InitSetting()
        {
            ISettingsManager settingManager = _settingManagerFactory.Create(PersistSetting.Remote);
            _setting =
                settingManager.GetSetting(PostingOfInventoryAtTheWarehouseViewSetting.SETTING_NAME) as
                    PostingOfInventoryAtTheWarehouseViewSetting ?? new PostingOfInventoryAtTheWarehouseViewSetting();

            settingManager.RegisterChanges(_setting);
        }

        private void HeightChanged(RowDefinition rowDefinition)
        {
            _setting.HeightGrid = rowDefinition.ActualHeight;
        }
    }
}
