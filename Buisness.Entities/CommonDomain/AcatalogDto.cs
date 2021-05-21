// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcatalogDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AcatalogDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using System.Collections.Generic;

    using Halfblood.Common;

    /// <summary>
    /// The acatalog dto.
    /// </summary>
    public class AcatalogDto : IDto
    {
        public AcatalogDto(long rn)
        {
            Rn = rn;
        }

        public AcatalogDto()
        {
        }

        public long Rn { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public AcatalogDto AcatalogCrn { get; set; }
        public IList<UserPrivilegeDto> UserPrivileges { get; set; } 
        public override string ToString()
        {
            return Name;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is AcatalogDto == false)
        //    {
        //        return false;
        //    }

        //    if (Object.ReferenceEquals(this, obj))
        //    {
        //        return true;
        //    }

        //    if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
        //    {
        //        return false;
        //    }

        //    var catalog = obj as AcatalogDto;

        //    return Rn == catalog.Rn;
        //}
        //public override int GetHashCode()
        //{
        //    return Rn.GetHashCode();
        //}
    }
}