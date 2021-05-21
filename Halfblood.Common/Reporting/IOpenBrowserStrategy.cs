namespace Halfblood.Common.Reporting
{
    /// <summary>
    /// The strategy with open browser with the report.
    /// </summary>
    public interface IOpenBrowserStrategy
    {
        /// <summary>
        /// Open the report.
        /// </summary>
        /// <param name="postData"></param>
        void Open(byte[] postData);
    }
}