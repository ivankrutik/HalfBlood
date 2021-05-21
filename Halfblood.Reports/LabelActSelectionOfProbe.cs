namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class LabelActSelectionOfProbe : IReportMetadata
    {
        public LabelActSelectionOfProbe(long actSelOfProbeDepartment)
        {
            ActSelOfProbeDepartment = actSelOfProbeDepartment;
        }

        public long Uid
        {
            get { return 1008534550; }
            
        }

        public string ReportName
        {
            get { return ""; } 
            
        }

        [Key("rn")]
        public long ActSelOfProbeDepartment
        {
            get;
            private set;
        }
    }
}
