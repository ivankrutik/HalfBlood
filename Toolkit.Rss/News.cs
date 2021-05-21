using System.ComponentModel.Composition;
using Toolkit.Infrastructure;

namespace Toolkit.Rss
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(INews))]
    public class News : INews
    {
        public string Chanel { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Desc { get; set; }
        public string Creator { get; set; }
        public string Category { get; set; }
        public string Secutiry { get; set; }
    }
}
