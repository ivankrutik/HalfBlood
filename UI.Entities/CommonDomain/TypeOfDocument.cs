// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeOfDocument.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The type of document .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    /// <summary>
    /// The type of document .
    /// </summary>
    public class TypeOfDocument
    {
        public TypeOfDocument(long rn)
        {
            this.Rn = rn;
        }

        public TypeOfDocument()
        {
            
        }

        public long Rn { get; private set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.DocCode, this.DocName);
        }
    }
}
