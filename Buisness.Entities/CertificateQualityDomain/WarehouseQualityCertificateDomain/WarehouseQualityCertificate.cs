namespace Buisness.Entities.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;

    public class WarehouseQualityCertificateDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public CatalogDto Catalog { get; set; }
        public UserDto UserCreator { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public WarehouseQualityCertificateState State { get; set; }
        public DateTime? StateDate { get; set; }
        public string Note { get; set; }
        public UserDto Storekeeper { get; set; }
        public DateTime? StorekeeperDate { get; set; }
        public string Marka { get; set; }
        public string Cast { get; set; }
        public string FullRepresentation { get; set; }
        public string GostCast { get; set; }
        public string GostMix { get; set; }
        public string Mix { get; set; }
        public long Rn { get; set; }

        public UserDto ControllerQualityDepartment { get; set; }
        public DateTime? ControllerQualityDepartmentDate { get; set; }
        public UserDto ControllerQuality { get; set; }
        public DateTime? ControllerQualityDate { get; set; }
        public UserDto Customer { get; set; }
        public DateTime? CustomerDate { get; set; }
    }
}
