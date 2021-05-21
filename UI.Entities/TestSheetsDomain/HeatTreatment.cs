using Halfblood.Common;

namespace UI.Entities.TestSheetsDomain
{
    public class HeatTreatment : EntityBase<HeatTreatment>
    {
        public TestSheet TestSheet { get; set; }

        public long Rn { get; set; }
        public HeatTreatmentOperations Operation { get; set; }
        public long? PutTemperature { get; set; }
        public long? SetTemperature { get; set; }
        public long? HeatingTime { get; set; }
        public long? HoldingTime { get; set; }
        public HeatTreatmentCoolingAmbients Ambience { get; set; }
        public long? AmbientTemperature { get; set; }
    }
}