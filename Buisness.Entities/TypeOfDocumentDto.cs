// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeOfDocumentDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TypeOfDocumentDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities
{
    using Halfblood.Common;

    /// <summary>
    ///     The type of document dto.
    /// </summary>
    public class TypeOfDocumentDto : IDto<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }

        object IHasUid.Rn { get { return Rn; } }

        public override string ToString()
        {
            return string.Format("{1} ({0})", Name, Code);
        }
    }
}