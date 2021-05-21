using System;
using Halfblood.Common;

namespace ParusModelLite.TestSheetsDomain
{
    public class TestSheetLiteDto : IDto<long>
    {
        public TestKinds TestCode { get; set; }
        public long Number { get; set; }
        public DateTime CreationDate { get; set; }
        public TestSheetState State { get; set; }
        public DateTime StateDate { get; set; }
        public string Note { get; set; }
        public long? FixingCardNumber { get; set; }
        public string Heater { get; set; }
        public DateTime? HeaterDate { get; set; }
        public string SampleMaker { get; set; }
        public DateTime? SampleMakerDate { get; set; }
        public string LabChief { get; set; }
        public DateTime? LabChiefDate { get; set; }
        public string OtkEmployee { get; set; }
        public DateTime? OtkEmployeeDate { get; set; }
        public string VpEmployee { get; set; }
        public DateTime? VpEmployeeDate { get; set; }

        // liteDto part -----------------------------
        public long RnActSelection { get; set; }
        public long ActSelectionNumber { get; set; }
        public DateTime ActSelectionDate { get; set; }
        public string Certificate { get; set; }
        public string Material { get; set; }
        public long Rn { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }
    }
}