namespace Toolkit.Infrastructure.Rss
{
    public interface IRssManager
    {
        IResultAddNews SendRss(INews ch);
    }
}