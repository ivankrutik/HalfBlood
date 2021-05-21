namespace Halfblood.UnitTests.SettingsTests
{
    using System.Collections.Generic;
    using System.Linq;

    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;
    using Halfblood.Common.Settings.Editors;

    using MahApps.Metro;

    using NUnit.Framework;

    using ReactiveUI;

    using Rhino.Mocks;

    using UI.Components.Settings;
    using UI.Infrastructure;
    using UI.ProcessComponents.Settings;

    using Color = System.Drawing.Color;

    // - Нужно показать все настройки, для которых есть визуальный редактор;
    // - при выборе конкретной настройки, отображать для нее вьюху;
    // - выбранную настройку можно отредактить
    //   и затем нажать сохранить для сохранение всех измененных настроек в БД;

    // редактируем настройки.
    // на вход дают нам настройки.
    // выдаем на ружу API для редактирования свойств настроек
    // и редактим
    public class SettingViewModelTest
    {
        [Test]
        public void CreateAndInitVm()
        {
            var settingManager = MockRepository.GenerateMock<ISettingsManager>();
            settingManager.Stub(x => x.GetSettings())
                .Return(new ISetting[] { new ColorSetting { Accent = Color.Gold, Theme = Theme.Dark } });

            var settingManagerFactory = MockRepository.GenerateMock<ISettingManagerFactory>();
            settingManagerFactory.Stub(x => x.Create(PersistSetting.Remote)).Return(settingManager);

            var settingViewModel = new EditorSettingViewModel(
                MockRepository.GenerateStub<IScreen>(),
                MockRepository.GenerateStub<IMessenger>(),
                MockRepository.GenerateStub<ISettingEditorsProvider>(),
                settingManagerFactory,
                MockRepository.GenerateMock<IIndependencyAdjustManager>());
        }

        [Test]
        public void EditorProvider()
        {
            var provider = new SettingEditorsProvider();
            provider.Register(
                new ColorSettingEditorViewModel(MockRepository.GenerateStub<IIndependencyAdjuster<ColorSetting>>()));
            IEnumerable<ISettingEditor> settingEditors = provider.GetEditors();

            Assert.That(settingEditors, Is.Not.Null);
            Assert.IsTrue(settingEditors.Any());
            Assert.That(settingEditors.First(), Is.InstanceOf<ColorSettingEditorViewModel>());
        }

        [Test]
        public void SelectedSetting()
        {
            var editorsProvider = MockRepository.GenerateMock<ISettingEditorsProvider>();
            editorsProvider.Stub(x => x.GetEditors())
                .Return(
                    new List<ISettingEditor>
                        {
                            new ColorSettingEditorViewModel(
                                MockRepository.GenerateStub<IIndependencyAdjuster<ColorSetting>>())
                        });

            var settingManager = MockRepository.GenerateMock<ISettingsManager>();
            settingManager.Stub(x => x.GetSetting("ColorSetting"))
                .Return(new ColorSetting { Accent = Color.Gold, Theme = Theme.Dark });
            settingManager.Stub(x => x.GetSettings())
                .Return(new List<ISetting> { new ColorSetting { Accent = Color.Gold, Theme = Theme.Dark } });

            var settingManagerFactory = MockRepository.GenerateMock<ISettingManagerFactory>();
            settingManagerFactory.Stub(x => x.Create(PersistSetting.Remote)).Return(settingManager);

            var settingViewModel = new EditorSettingViewModel(
                MockRepository.GenerateStub<IScreen>(),
                MockRepository.GenerateStub<IMessenger>(),
                editorsProvider,
                settingManagerFactory,
                MockRepository.GenerateMock<IIndependencyAdjustManager>());

            settingViewModel.SelectedSettingsEditor = settingViewModel.SettingEditors.First();

            Assert.That(settingViewModel.SelectedSettingsEditor, Is.Not.Null);
            Assert.That(settingViewModel.SelectedSettingsEditor, Is.InstanceOf<ColorSettingEditorViewModel>());
        }

        [Test]
        public void ColorSettingEditor()
        {
            var colorSetting = new ColorSetting { Accent = Color.Gold, Theme = Theme.Dark };
            var colorSettingEditor =
                new ColorSettingEditorViewModel(MockRepository.GenerateStub<IIndependencyAdjuster<ColorSetting>>());

            colorSettingEditor.SetSetting(colorSetting);

            Assert.That(colorSettingEditor.Color, Is.EqualTo(Color.Red));
            Assert.That(colorSettingEditor.Theme, Is.EqualTo(Theme.Light));

            colorSettingEditor.Color = Color.DarkOrange;
            colorSettingEditor.Theme = Theme.Dark;

            Assert.That(colorSetting.Accent, Is.EqualTo("DarkOrange"));
            Assert.That(colorSetting.Theme, Is.EqualTo("Dark"));
        }

        [Test]
        public void FlushSetting()
        {
            var editorsProvider = MockRepository.GenerateMock<ISettingEditorsProvider>();
            editorsProvider.Stub(x => x.GetEditors())
                .Return(
                    new List<ISettingEditor>
                        {
                            new ColorSettingEditorViewModel(
                                MockRepository.GenerateStub<IIndependencyAdjuster<ColorSetting>>())
                        });

            var settingManager = MockRepository.GenerateMock<ISettingsManager>();
            var settingManagerFactory = MockRepository.GenerateMock<ISettingManagerFactory>();
            settingManagerFactory.Stub(x => x.Create(PersistSetting.Remote)).Return(settingManager);

            var manager = new EditorSettingViewModel(
                MockRepository.GenerateStub<IScreen>(),
                MockRepository.GenerateStub<IMessenger>(),
                editorsProvider,
                settingManagerFactory,
                MockRepository.GenerateMock<IIndependencyAdjustManager>());

            manager.Flush();

            settingManager.AssertWasCalled(x => x.Flush());
        }
    }
}