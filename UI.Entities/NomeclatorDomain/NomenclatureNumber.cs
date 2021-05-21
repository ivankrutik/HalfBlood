// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumber.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The nomenclature number.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.NomeclatorDomain
{
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The nomenclature number.
    /// </summary>
    public class NomenclatureNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NomenclatureNumber"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public NomenclatureNumber(long rn)
        {
            this.RN = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NomenclatureNumber"/> class.
        /// </summary>
        public NomenclatureNumber()
        {
            
        }

        public long RN { get; private set; }
        public string Nomencode { get; set; }
        public string Nomenname { get; set; }
 
        public UnitOfMeasure DicmuntUmeasMain { get; set; }
        public UnitOfMeasure DicmuntUmeasAlt { get; set; }

        public override string ToString()
        {
            return Nomenname + " " + Nomencode;
        }
    }
}
