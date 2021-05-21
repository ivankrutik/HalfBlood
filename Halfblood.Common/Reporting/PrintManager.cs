namespace Halfblood.Common.Reporting
{
    using System.ComponentModel.Composition;
    using System.Text;

    using Halfblood.Common.Connection;

    using Newtonsoft.Json;

    [Export(typeof(IPrintManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PrintManager : IPrintManager
    {
        private readonly IBuilderQuery _builderQuery;
        private readonly IOpenBrowserStrategy _openBrowserStrategy;
        [Import] private IHasAuthentificationMetadata _metadata;

        [ImportingConstructor]
        public PrintManager(IBuilderQuery builderQuery, IOpenBrowserStrategy openBrowserStrategy)
        {
            _builderQuery = builderQuery;
            _openBrowserStrategy = openBrowserStrategy;
        }

        public void OpenReportInBrowser(IReportMetadata reportMetadata)
        {
            var sendData = new SendData
            {
                AuthorizationMetadata =
                {
                    Login = _metadata.AuthorizationMetadata.Login,
                    Password = _metadata.AuthorizationMetadata.Password,
                    Database = _metadata.AuthorizationMetadata.Database
                },
                Rn = reportMetadata.Uid,
                Parameters = _builderQuery.GetParameters(reportMetadata)
            };

            // сериализуем
            var query = JsonConvert.SerializeObject(sendData);

            // проверяем
            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            // шифруем
            // encoding
            // отсылаем на сервер
            byte[] bytes = Encoding.UTF8.GetBytes("pr_data=" + query);

            _openBrowserStrategy.Open(bytes);
        }
    }
}