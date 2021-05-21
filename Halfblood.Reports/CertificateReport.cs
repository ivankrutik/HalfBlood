namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class CertificateReport : IReportMetadata
    {
        public long Uid
        {
            get { return 1008326741; }
        }
        public string ReportName { get; private set; }
        [Key("Rn")]
        public long Rn { get; set; }
    }
}