namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class LegalPersonDto : IDto<long>
    {
        public virtual long Rn { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual LegalPersonDto Parent { get; set; }
        public virtual UserDto Contractor { get; set; }
        public virtual CatalogDto Catalog { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        object IHasUid.Rn { get { return Rn; } }

    }
}
