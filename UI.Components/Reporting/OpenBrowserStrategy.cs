namespace UI.Components.Reporting
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;
    using Halfblood.Common.Reporting;

    [Export(typeof(IOpenBrowserStrategy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OpenBrowserStrategy : IOpenBrowserStrategy
    {
        public void Open(byte[] postData)
        {
          Application.Current.Dispatcher.Invoke(() =>
            {
                var reportWindow = new Window {WindowState = WindowState.Maximized};

                // отправка POST`ом
                // готовим данные для отправки
                const string ServerUrl = @"http://worksite.vz/Halfblood.Reporting/GetReport.aspx";
                var additionalHeaders = "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine;

                var webBrowser = new WebBrowser();
                reportWindow.Content = webBrowser;
                webBrowser.Navigate(ServerUrl, string.Empty, postData, additionalHeaders);
                reportWindow.ShowDialog();

                EventHandler handler = delegate { };
                handler = (sender, args) =>
                {
                    reportWindow.Closed -= handler;
                    webBrowser.Dispose();
                };
                reportWindow.Closed += handler;
            });

        }
    }
}