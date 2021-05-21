using NHibernate.Mapping;

namespace Halfblood.UnitTests.SettingsTests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using Halfblood.Common.Settings;

    using MahApps.Metro;

    using NUnit.Framework;

    using Rhino.Mocks;

    using UI.Components.Settings;
    using UI.ProcessComponents.Settings;

    using Is = NUnit.Framework.Is;

    public class SettingsTest
    {
        private ISettingsManager _settingManager;
        private SettingsModel _settingModel;
        private ISettingsService _service;
        private IParserSetting _parseSetting;
        private IEmptySettingsProvider _emptySettingProvider;
        private const string J_S_O_N =
            "{\"ColorSetting\":\"{\"Accent\":\"Fuchsia\",\"Theme\":1,\"Name\":\"ColorSetting\"}\",\"LoginSetting\":\"{\"Login\":\"Login\",\"Database\":\"Databasse\",\"Name\":\"LoginSetting\"}\"}";

        [SetUp]
        public void SetUp()
        {
            this._emptySettingProvider = MockRepository.GenerateMock<IEmptySettingsProvider>();
            this._emptySettingProvider.Stub(x => x.GetSettings())
                .Return(
                    new List<ISetting>
                        {
                            new FakeColorSetting { Accent = Color.Fuchsia, Theme = Theme.Dark },
                            new FakeLoginSetting { Database = "Databasse", Login = "Login" }
                        });
            _settingModel = new SettingsModel { Application = "Halfblood", SettingsInJson = J_S_O_N };
            _service = MockRepository.GenerateMock<ISettingsService>();
            _parseSetting = MockRepository.GenerateMock<IParserSetting>();
            _service.Stub(x => x.Get("Halfblood")).Return(_settingModel);
            _parseSetting.Stub(x => x.Parse(_settingModel)).Return(new List<ISetting> { new ColorSetting() });

            _settingManager = SettingsManager.Create(
                _service,
                "Halfblood",
                _parseSetting,
                this._emptySettingProvider);
        }

        [Test]
        public void CreateAndInit()
        {
            ISettingsManager settingManager = SettingsManager.Create(
                MockRepository.GenerateStub<ISettingsService>(),
                "Halfblood",
                MockRepository.GenerateStub<IParserSetting>(),
                MockRepository.GenerateStub<IEmptySettingsProvider>());

            Assert.That(settingManager, Is.Not.Null);
        }

        [Test]
        public void GetAndParseSettings()
        {
            _service.AssertWasCalled(x => x.Get("Halfblood"));
            _parseSetting.AssertWasCalled(x => x.Parse(_settingModel));

            Assert.That(_settingManager.GetSettings(), Is.Not.Null);
            Assert.IsTrue(_settingManager.GetSettings().Any());
            Assert.That(_settingManager.GetSettings().First(), Is.InstanceOf<ColorSetting>());
        }

        [Test]
        public void ParseSetting()
        {
            var settingModel = MockRepository.GenerateMock<ISettingsModel>();
            var parser = new ParserSetting(this._emptySettingProvider, this._emptySettingProvider);

            settingModel.Stub(x => x.SettingsInJson).Return(J_S_O_N);

            IList<ISetting> setting = parser.Parse(settingModel);
            Assert.That(setting, Is.Not.Null);
            Assert.IsTrue(setting.Any());
            Assert.That(setting.First(), Is.InstanceOf<FakeColorSetting>());

            string json = parser.ToJson(setting);
            Assert.That(json, Is.EqualTo(settingModel.SettingsInJson));
        }

        [Test]
        public void SaveSettings()
        {
            ColorSetting setting = _settingManager.GetSettings().OfType<ColorSetting>().First();
            setting.Accent = Color.Gold;
            setting.Theme = Theme.Dark;

            _settingManager.Flush();
        }

        public void RegisterSetting()
        {
            var setting = new LoginSetting ();
            setting.LastUsersMetadata.Add("140muhamadiev", "dupparus");
            setting.LastAuthentificationCompletedUser = "140muhamadiev";
            _settingManager.RegisterChanges(setting);
            _settingManager.Flush();

            _service.AssertWasCalled(x => x.SaveSetting(null));
        }
        public void RegisterAsModify()
        {
            var colorSetting = (ColorSetting)this._settingManager.GetSetting("ColorSetting");
            colorSetting.Accent = Color.Gold;
            colorSetting.Theme = Theme.Light;

            _settingManager.RegisterChanges(colorSetting);
            _settingManager.Flush();

            _service.AssertWasCalled(x => x.SaveSetting(null));
        }
    }

    public class FakeColorSetting : ISetting
    {
        public Color Accent { get; set; }
        public Theme Theme { get; set; }

        public string Name
        {
            get
            {
                return "ColorSetting";
            }
        }
    }
    public class FakeLoginSetting : ISetting
    {
        public string Login { get; set; }
        public string Database { get; set; }

        public string Name
        {
            get
            {
                return "LoginSetting";
            }
        }
    }
}
