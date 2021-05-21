// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberModification.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatureNumberModification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.NomeclatorDomain
{
    using Halfblood.Common.Helpers;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The nomenclature number modification.
    /// </summary>
    public class NomenclatureNumberModification
    {
        public NomenclatureNumberModification(long rn)
        {
            this.Rn = rn;
        }
        public NomenclatureNumberModification()
        {
        }

        public long Rn { get; private set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static NomenclatureNumberModification Default
        {
            get { return new NomenclatureNumberModification(); }
        }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public NomenclatureNumber NomenclatureNumber { get; set; }
        public User Agnlist { get; set; }

        public override string ToString()
        {
            return "{0} - {1}".StringFormat(Code, Name);
        }
    }
}
