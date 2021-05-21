using System.ComponentModel.Composition;
using Toolkit.Infrastructure;

namespace Toolkit.Rss
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IResultAddNews))]
    public class ResultAddNews : IResultAddNews
    {
        public string AddNews { get; set; }
        public string InsertId { get; set; }
    }
}
