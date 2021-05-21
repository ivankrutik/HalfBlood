using System.Windows;

namespace UI.Components.NotifyMessagWindows
{
    public static class Screen
    {
        public static double Width
        {
            get { return SystemParameters.WorkArea.Width; }
        }

        public static double Height
        {
            get { return SystemParameters.WorkArea.Height; }
        }
    }
}
