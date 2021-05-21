using System.Collections.Generic;

namespace UI.Entities.TestSheetsDomain
{
    public class TestResult : EntityBase<TestResult>
    {
        public TestResult()
        {
            SampleResultSets = new List<SampleResultSet>();
        }

        public IList<SampleResultSet> SampleResultSets { get; set; }
        public TestSheet TestSheet { get; set; }

        public long Rn { get; set; }
        public string AnalysesRange { get; set; }
        public string IndicatorName { get; set; }
        public string Unit { get; set; }
        public string TestingMethod { get; set; }
        public string Requirements { get; set; }
        public string Equipment { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }
    }
}