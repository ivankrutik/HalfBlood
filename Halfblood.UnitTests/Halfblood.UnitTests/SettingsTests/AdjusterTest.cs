namespace Halfblood.UnitTests.SettingsTests
{
    using System.Collections.Generic;

    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;

    using NUnit.Framework;

    using Rhino.Mocks;

    using UI.Infrastructure.ViewModels;
    using UI.ProcessComponents.Settings;

    // Task
    // Применить настроки
    //      - при загрузке объекта
    //          - перехватывать создание объекта, 
    //            искать настройщика
    //            и попросить его инициализировать объект и дать ему настройки
    //      - при загрузке проекта
    //          - ищем настройщика и настройки и пусть он сделать хорошо
    public class AdjusterTest
    {
        [Test]
        public void CreateAndInitAdjuster()
        {
            var adjusterManager = new ObjctAdjusterManager(
                MockRepository.GenerateStub<IAdjusterProvider>(),
                MockRepository.GenerateStub<IGetSettingFactory>());
        }

        [Test]
        public void RegisterAdjusterAndAdjust()
        {
            var setting = MockRepository.GenerateStub<ISetting>();
            var provider = MockRepository.GenerateStub<IAdjusterProvider>();
            var getSettingFactory = MockRepository.GenerateMock<IGetSettingFactory>();
            var getSetting = MockRepository.GenerateMock<IGetSetting>();
            var adjuster = MockRepository.GenerateMock<IObjectAdjuster>();
            var obj = new object();

            getSettingFactory.Stub(x => x.Create()).Return(getSetting);
            adjuster.Stub(x => x.Name).Return("ColorSetting");
            getSetting.Stub(x => x.GetSetting("ColorSetting")).Return(setting);
            provider.Stub(x => x.GetAdjusters()).Return(new List<IObjectAdjuster> { adjuster });

            var adjusterManager = new ObjctAdjusterManager(provider, getSettingFactory);
            adjusterManager.TryAdjust(obj);

            adjuster.AssertWasCalled(x => x.Adjust(obj, setting));
        }
    }

    public class FakeLoginAdjuster : ObjectAdjusterBase<ILoginViewModel, LoginSetting>
    {
        public override string Name
        {
            get { return "LoginSetting"; }
        }

        public override bool Adjust(ILoginViewModel adjustable, LoginSetting setting)
        {
            return true;
        }
    }
}
