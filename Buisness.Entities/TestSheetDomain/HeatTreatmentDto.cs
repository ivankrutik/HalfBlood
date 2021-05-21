using System;
using Buisness.Entities.CommonDomain;
using Halfblood.Common;

namespace Buisness.Entities.TestSheetDomain
{
    public class HeatTreatmentDto : IDto<long>, IHasRowNumber
    {
        // связь с предком
        public TestSheetDto TestSheet { get; set; }

        public long Number { get; set; }

        public HeatTreatmentOperations Operation { get; set; }
        public long? PutTemperature { get; set; }
        public long? SetTemperature { get; set; }
        public long? HeatingTime { get; set; }
        public long? HoldingTime { get; set; }
        public HeatTreatmentCoolingAmbients Ambience { get; set; }
        public long? AmbientTemperature { get; set; }
        public UserDto Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public long Rn { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }
    }
}