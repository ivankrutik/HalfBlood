using System.ComponentModel.Composition;
using System.Globalization;
using CookComputing.XmlRpc;
using Toolkit.Infrastructure;
using Toolkit.Infrastructure.Rss;

namespace Toolkit.Rss
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IRssManager))]
    public class RssManager : IRssManager
    {
        [XmlRpcUrl("http://site.vz/rssengine/index.php/xmlrpc_server")]
        public interface IXmlrpc
        {
            [XmlRpcMethod("addNews")]
            ResultAddNews AddNews(string idChannel, string title, string link, string description, string creator, string security, string category);
        }
        public IResultAddNews SendRss(INews ch)
        {
            var rss = (IXmlrpc)XmlRpcProxyGen.Create(typeof(IXmlrpc));
            try
            {
                var ran = rss.AddNews(ch.Chanel, ch.Title, ch.Link, ch.Desc, ch.Creator, ch.Secutiry, ch.Category);
                return ran;
            }
            catch (XmlRpcFaultException ex)
            {
                var rn = new ResultAddNews { AddNews = ex.FaultCode.ToString(CultureInfo.InvariantCulture), InsertId = ex.FaultString };
                return rn;
            }
        }
    }
}
