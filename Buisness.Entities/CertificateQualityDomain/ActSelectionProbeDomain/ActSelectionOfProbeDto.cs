// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDestinationDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection probe dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The act selection probe dto.
    /// </summary>
    /// 
    [RelationEntityToDto(NamesOfSectionSystem.ActSelectionOfProbe)]
    public class ActSelectionOfProbeDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public DateTime? CreationDate { get; set; }
        public StaffingDivisionDto DepartmentCreator { get; set; }
        public UserDto Creator { get; set; }
        public ActSelectionOfProbeState State { get; set; }
        public IList<ActSelectionOfProbeDepartmentDto> MakingSamples { get; set; }
        public CatalogDto Catalog { get; set; }
        public long Rn { get; set; }
        public DateTime? ControlerDate { get; set; }
        public string Sample { get; set; }
        public UserDto Controler { get; set; }
        public UserDto Customer { get; set; }
        public string Note { get; set; }


        public long RnCertificate { get; set; }
        public string NumbCertificate { get; set; }
        public string FullRepresentattion { get; set; }
        public string Cast { get; set; }




    }
}