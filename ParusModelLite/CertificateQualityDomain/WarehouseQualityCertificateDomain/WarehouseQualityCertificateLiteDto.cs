namespace ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain
{
    using System;
    using Buisness.Entities;
    using Halfblood.Common;

    public class WarehouseQualityCertificateLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual CatalogDto Catalog { get; set; }
        public virtual string UserCreator { get; set; }
        public virtual long RnCreator { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual WarehouseQualityCertificateState State { get; set; }
        public virtual string Note { get; set; }
        public virtual string UserSetState { get; set; }
        public virtual long RnUserSetState { get; set; }
        public virtual DateTime? StateDate { get; set; }
        public virtual string Storekeeper { get; set; }
        public virtual long RnStorekeeper { get; set; }
        public virtual DateTime? StorekeeperDate { get; set; }
        public virtual string ControllerQuality { get; set; }
        public virtual long RnControllerQuality { get; set; }
        public virtual DateTime? ControllerQualityDate { get; set; }
        public virtual string Customer { get; set; }
        public virtual long RnCustomer { get; set; }
        public virtual DateTime? CustomerDate { get; set; }
        public virtual string ControllerQualityDepartment { get; set; }
        public virtual long RnControllerQualityDepartment { get; set; }
        public virtual DateTime? ControllerQualityDepartmentDate { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Cast { get; set; }
        public virtual string FullRepresentation { get; set; }
        public virtual string GostMix { get; set; }
        public virtual string GostCast { get; set; }
        public virtual string Mix { get; set; }
        public virtual string StandardSize { get; set; }
        public virtual string NomerCertificata { get; set; }
        public virtual string Pass { get; set; }
    }
}
