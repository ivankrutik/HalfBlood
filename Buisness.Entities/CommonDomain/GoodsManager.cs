namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class GoodsManagerDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public UserDto Contractor { get; set; }
    }
}
