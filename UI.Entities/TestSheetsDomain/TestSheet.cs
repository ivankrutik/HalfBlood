using System;
using System.Collections.Generic;
using Halfblood.Common;
using UI.Entities.CommonDomain;

namespace UI.Entities.TestSheetsDomain
{
    public class TestSheet : EntityBase<TestSheet>
    {
        public TestSheet()
        {
            State = TestSheetState.Not—onfirm;
            StateDate = DateTime.Today;
            CreationDate = DateTime.Today;
            HeatTreatments = new List<HeatTreatment>();
            TestResults = new List<TestResult>();
        }

        public IList<HeatTreatment> HeatTreatments { get; set; }
        public IList<TestResult> TestResults { get; set; }

        public long Rn { get; set; }
        public TestKinds TestCode { get; set; }
        public long Number { get; set; }
        public TestSheetState State { get; set; }
        public DateTime StateDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Note { get; set; }
        public long? FixingCardNumber { get; set; }
        public User Heater { get; set; }
        public DateTime? HeaterDate { get; set; }
        public User SampleMaker { get; set; }
        public DateTime? SampleMakerDate { get; set; }
        public User LabChief { get; set; }
        public DateTime? LabChiefDate { get; set; }
        public User OtkEmployee { get; set; }
        public DateTime? OtkEmployeeDate { get; set; }
        public User VpEmployee { get; set; }
        public DateTime? VpEmployeeDate { get; set; }

        // liteDto part ------------------------------
        public long ActSelectionNumber { get; set; }
        public DateTime ActSelectionDate { get; set; }
        public string Certificate { get; set; }
        public string Material { get; set; }
    }
}