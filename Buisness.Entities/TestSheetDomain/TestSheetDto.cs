// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSheetDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TestSheetDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Buisness.Entities.CommonDomain;
using Halfblood.Common;

namespace Buisness.Entities.TestSheetDomain
{
    public class TestSheetDto : IDto<long>
    {
        public TestSheetDto()
        {
            HeatTreatments = new List<HeatTreatmentDto>();
            TestResults = new List<TestResultDto>();
        }

        public IList<HeatTreatmentDto> HeatTreatments { get; set; }
        public IList<TestResultDto> TestResults { get; set; }

        public TestKinds TestCode { get; set; }
        public long Number { get; set; }
        public DateTime CreationDate { get; set; }
        public TestSheetState State { get; set; }
        public DateTime StateDate { get; set; }
        public string Note { get; set; }
        public long? FixingCardNumber { get; set; }
        public UserDto Heater { get; set; }
        public DateTime? HeaterDate { get; set; }
        public UserDto SampleMaker { get; set; }
        public DateTime? SampleMakerDate { get; set; }
        public UserDto LabChief { get; set; }
        public DateTime? LabChiefDate { get; set; }
        public UserDto OtkEmployee { get; set; }
        public DateTime? OtkEmployeeDate { get; set; }
        public UserDto VpEmployee { get; set; }
        public DateTime? VpEmployeeDate { get; set; }

        public CatalogDto Catalog
        {
            get { return new CatalogDto(1008015757); }
        }

        public long Rn { get; set; }

        object IHasUid.Rn
        {
            get { return Rn; }
        }
    }
}