namespace UI.Components.Hook
{
    using System.Diagnostics.Contracts;
    using System.Windows.Controls;

    using mshtml;

    public static class WebBrowserHook
    {
        public const string DisableScriptError =
            @"function noError() { return true; }
            window.onerror = noError;";

        public static void InjectDisableScript(WebBrowser webBrowser)
        {
            Contract.Requires(webBrowser != null, "The web browser must be not null");

            var doc = webBrowser.Document as HTMLDocumentClass;
            var doc2 = webBrowser.Document as HTMLDocument;

            var scriptErrorSuppressed = (IHTMLScriptElement)doc2.createElement("SCRIPT");
            scriptErrorSuppressed.type = "text/javascript";
            scriptErrorSuppressed.text = DisableScriptError;

            IHTMLElementCollection nodes = doc.getElementsByTagName("head");

            foreach (IHTMLElement elem in nodes)
            {
                var head = (HTMLHeadElementClass)elem;
                head.appendChild((IHTMLDOMNode)scriptErrorSuppressed);
            }
        }
    }
}
