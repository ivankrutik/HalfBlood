namespace Halfblood.Reports
{
    using Halfblood.Common.Reporting;

    public class TheDemandReport : IReportMetadata
    {
        public long Uid
        {
            get { return 1008327787; }
        }

        public string ReportName
        {
            get { return "Предъявительская"; }
        }

        [Key("Shop")]
        public string Shop { get; set; }
        [Key("DSE")]
        public string DSE { get; set; }
        [Key("Nomination")]
        public string Nomination { get; set; }
        [Key("EmpOtk")]
        public string EmployeeOTK { get; set; }
        [Key("Receiver")]
        public string EmployeeReceiver { get; set; }
        [Key("Giver")]
        public string EmployeeGiver { get; set; }
        [Key("CountDSE")]
        public long CountDSE { get; set; }
        [Key("NRN")]
        public long KeyRn { get; set; }
        
        public string MaterialUseOnBase { get; set; }

        public string UnitOfMeasure { get; set; }
        public string QuantityOfMaterial { get; set; }
        public string NumberBatchOfPreparation { get; set; }
        public string QuantityOfPreparations { get; set; }
        public string QuantityOfDetails { get; set; }
        public string Mark { get; set; }
        public string GOST_TU { get; set; }
        public string NumberCertificateOfMakerShop { get; set; }
        public string NumberOfFusion { get; set; }
        public string GageSize { get; set; }
        public string NumberOfSSH { get; set; }
        public string CardOfAccess { get; set; }
        public string CardOfAccessVMZ { get; set; }
    }
}