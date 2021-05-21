namespace UI.Components.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Drawing;

    using Halfblood.Common;
    using Halfblood.Common.Settings;
    using Halfblood.Common.Settings.Adjuster;
    using Halfblood.Common.Settings.Editors;

    using MahApps.Metro;

    using ReactiveUI;

    [SettingEditor]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ColorSettingEditorViewModel : ReactiveObject, ISettingEditor<ColorSetting>
    {
        private readonly IIndependencyAdjuster<ColorSetting> _colorAdjuster;
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private ColorSetting _colorSetting;
        private Theme _theme;
        private Color _color;

        public Color Color
        {
            get { return this._color; }
            set { this.RaiseAndSetIfChanged(ref this._color, value); }
        }
        public Theme Theme
        {
            get { return this._theme; }
            set { this.RaiseAndSetIfChanged(ref this._theme, value); }
        }
        public string Name
        {
            get { return "ColorSetting"; }
        }
        public string Title
        {
            get { return "Цвета"; }
        }
        public string Description
        {
            get { return "Редактирование цветовой гаммы"; }
        }

        [ImportingConstructor]
        public ColorSettingEditorViewModel(IIndependencyAdjuster<ColorSetting> colorAdjuster)
        {
            _colorAdjuster = colorAdjuster;
        }

        public void SetSetting(ColorSetting setting)
        {
            _colorSetting = setting;

            Color = setting.Accent;
            Theme = setting.Theme;
            _disposableObject.Dispose();
            _disposableObject.Add(this.Binding());
        }

        void ISettingEditor.SetSetting(ISetting setting)
        {
            this.SetSetting(setting as ColorSetting);
        }
        private IEnumerable<IDisposable> Binding()
        {
            yield return this.WhenAnyValue(x => x.Color).Subscribe(
                color =>
                {
                    _colorSetting.Accent = color;
                    // _colorAdjuster.Adjust(_colorSetting);
                });
            yield return this.WhenAnyValue(x => x.Theme).Subscribe(
                theme =>
                {
                    _colorSetting.Theme = theme;
                    // _colorAdjuster.Adjust(_colorSetting);
                });
        }
    }
}
