// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisposableContext.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DisposableContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Helpers
{
    using System;
    using System.Windows;

    using Halfblood.Common;

    public class DisposableContext : DisposableObject
    {
        private FrameworkElement _frameworkElement;

        public DisposableContext(FrameworkElement frameworkElement)
        {
            _frameworkElement = frameworkElement;
        }

        protected override void OnAdd()
        {
            if (_frameworkElement == null)
            {
                throw new ArgumentNullException(
                    "После вызова метода Dispose этот объект считается нерабочим. Создайте новый экземпляр");
            }

            _frameworkElement.Unloaded -= Unloaded;
            _frameworkElement.Unloaded += Unloaded;
        }
        protected override void OnDispose()
        {
            if (_frameworkElement == null)
            {
                throw new InvalidOperationException(
                    "После вызова метода Dispose этот объект считается нерабочим. Создайте новый экземпляр");
            }
        }

        private void Unloaded(object sender, RoutedEventArgs e)
        {
            Dispose(true);
        }
        private void Dispose(bool isUser)
        {
            Dispose();
            _frameworkElement.Unloaded -= Unloaded;
            _frameworkElement = null;
        }
    }
}
