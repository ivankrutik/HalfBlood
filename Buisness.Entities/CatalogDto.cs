// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CatalogDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities
{
    using Halfblood.Common;

    public class CatalogDto : IDto<long>
    {
        public CatalogDto(long rn)
        {
            Rn = rn;
        }

        public CatalogDto()
        {
        }

        object IHasUid.Rn { get { return Rn; } }
        public string Name { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}