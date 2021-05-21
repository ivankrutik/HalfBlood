namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class CertificateSSHReport : IReportMetadata
    {
        public CertificateSSHReport(long certificateUid, decimal quantity)
        {
            CertificateUid = certificateUid;
            Quantity = quantity;
        }

        public long Uid
        {
            get { return 1008326741; }
        }
        public string ReportName
        {
            get { return "Сертификат складского хозяйства"; }
        }
        [Key("Rn")]
        public long CertificateUid { get; private set; }
        
        [Key("Quantity")]
        public decimal Quantity { get; private set; }
    }
}