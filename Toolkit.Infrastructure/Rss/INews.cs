namespace Toolkit.Infrastructure
{
    public interface INews
    {
        string Category { get; set; }
        string Chanel { get; set; }
        string Creator { get; set; }
        string Desc { get; set; }
        string Link { get; set; }
        string Secutiry { get; set; }
        string Title { get; set; }
    }
}