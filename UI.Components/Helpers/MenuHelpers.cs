namespace UI.Components.Helpers
{
    using System.Linq;
    using System.Windows.Controls;

    public static class MenuHelpers
    {
        public static MenuItem GetMenuItem(this UserControl control, string resource, string menuItemName)
        {
            return ((ContextMenu)control.Resources[resource]).Items.Cast<MenuItem>()
                       .First(mItem => mItem.Name == menuItemName);
        }
    }
}
