namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class KindOfWarehouseOperationsDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string GSMWAYSMNEMO { get; set; }
        public virtual string GSMWAYSNAME { get; set; }
        public virtual CatalogDto Catalog { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }

    }
}
