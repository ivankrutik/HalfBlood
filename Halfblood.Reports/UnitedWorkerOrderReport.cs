namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class UnitedWorkerOrderReport : IReportMetadata
    {
        public long Uid { get { return 1007352903; } }
        public string ReportName { get { return "Единый рабочий наряд"; } }

        [Key("nRn")]
        public long NRn { get; set; }

        public UnitedWorkerOrderReport()
        {
            //session.CreateSQLQuery("AH_P_ORDERSPRINTDATE");
        }
    }
}