namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class SalesReport : IReportMetadata
    {
        public long Uid { get; set; }
        public string ReportName { get; set; }

        [Key("name")]
        public string PrintReportName { get; set; }
    }
}
