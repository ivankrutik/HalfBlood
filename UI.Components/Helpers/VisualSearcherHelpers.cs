using System.Windows;
using System.Windows.Media;

namespace UI.Components.Helpers
{
    public static class VisualSearcherHelpers
    {
        /// <summary>
        /// Gets the specified visual parent
        /// </summary>
        /// <typeparam name="T">type of parent</typeparam>
        /// <param name="child">child element</param>
        /// <returns>parent element</returns>
        public static T GetVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            try
            {
                var parent = default(T);

                var dep = (DependencyObject)child;

                while ((dep != null) && !(dep is T))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                parent = dep as T;
                return parent;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static T GetVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            var child = default(T);
            var numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < numVisuals; i++)
            {
                var v = (DependencyObject)VisualTreeHelper.GetChild(parent, i);
                child = v as T ?? GetVisualChild<T>(v);
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }
}
