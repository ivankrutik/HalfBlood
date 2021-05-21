// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfMeasureDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UnitOfMeasureDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    /// <summary>
    /// The unit of measure DTO.
    /// </summary>
    public class UnitOfMeasureDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rn.
        /// </summary>
        public long Rn { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} ({1})", Code, Name);
        }
    }
}