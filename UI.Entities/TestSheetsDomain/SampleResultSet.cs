namespace UI.Entities.TestSheetsDomain
{
    public class SampleResultSet : EntityBase<SampleResultSet>
    {
        // связь с предком
        public TestResult TestResult { get; set; }

        public long Rn { get; set; }
        public bool IsRow { get; set; }
        public string Title { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public string Value10 { get; set; }
    }
}