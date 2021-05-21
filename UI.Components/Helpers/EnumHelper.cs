namespace UI.Components.Helpers
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public class EnumHelper : DependencyObject
    {
        public static Type GetEnum(DependencyObject obj)
        {
            return (Type)obj.GetValue(EnumProperty);
        }

        public static void SetEnum(DependencyObject obj, string value)
        {
            obj.SetValue(EnumProperty, value);
        }

        public static readonly DependencyProperty EnumProperty =
              DependencyProperty.RegisterAttached("Enum", typeof(Type), typeof(EnumHelper), new PropertyMetadata(null, OnEnumChanged));

        private static void OnEnumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as ItemsControl;

            if (control != null)
            {
                if (e.NewValue != null)
                {
                    var _enum = Enum.GetValues(e.NewValue as Type);
                    control.ItemsSource = _enum;
                }
            }
        }
    }
}
