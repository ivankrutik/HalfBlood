namespace UI.Components.Settings
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Controls;

    using MahApps.Metro;

    using ReactiveUI;

    [Export(typeof(IViewFor<ColorSettingEditorViewModel>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ColorSettingEditorView : UserControl, IViewFor<ColorSettingEditorViewModel>
    {
        public ColorSettingEditorView()
        {
            InitializeComponent();
        }

        public ColorSettingEditorViewModel ViewModel
        {
            get { return this.DataContext as ColorSettingEditorViewModel; }
            set { this.DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ColorSettingEditorViewModel)value; }
        }

        private void ChangeAccent(object sender, RoutedEventArgs e)
        {
            ViewModel.Color = Color.FromName((string)((MenuItem)sender).Tag);
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            ViewModel.Theme = (Theme)((MenuItem)sender).Tag;
        }
    }
}
