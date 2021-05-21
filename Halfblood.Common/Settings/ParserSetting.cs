namespace Halfblood.Common.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reactive.Linq;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    using Newtonsoft.Json;

    [Export(typeof(IParserSetting))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ParserSetting : IParserSetting
    {
        private readonly IEnumerable<ISetting> _settings;

        [ImportingConstructor]
        public ParserSetting(
            IEmptySettingsProvider emptySettingsProvider,
            [Import("LOCAL")] IEmptySettingsProvider localeEmptySettingsProvider)
        {
            _settings = emptySettingsProvider.GetSettings().Concat(localeEmptySettingsProvider.GetSettings());
        }

        public IList<ISetting> Parse(ISettingsModel settingModel)
        {
            Contract.Requires(settingModel != null);
            Contract.Ensures(Contract.Result<IList<ISetting>>() != null);

            if (string.IsNullOrWhiteSpace(settingModel.SettingsInJson))
            {
                return Enumerable.Empty<ISetting>().ToList();
            }

            var settings = new Dictionary<string, ISetting>();

            try {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(settingModel.SettingsInJson);
                dict.DoForEach(x =>
                    settings.Add(
                        x.Key,
                        (ISetting)
                        JsonConvert.DeserializeObject(
                            x.Value,
                            _settings.First(setting => setting.Name == x.Key).GetType())));
            }
            catch (Exception e) {
                LogManager.Log.Debug(
                    new ParserSettingException("Invalidate json: {0}".StringFormat(settingModel.SettingsInJson), e));
                return Enumerable.Empty<ISetting>().ToList();
            }

            var settingsCollection = new List<ISetting>();
            settings.DoForEach(temp => settingsCollection.Add(temp.Value));

            return settingsCollection;
        }
        public string ToJson(IList<ISetting> settings)
        {
            var dict = new Dictionary<string, string>();
            settings.DoForEach(setting => dict.Add(setting.Name, JsonConvert.SerializeObject(setting)));

            return JsonConvert.SerializeObject(dict);
        }
    }
}