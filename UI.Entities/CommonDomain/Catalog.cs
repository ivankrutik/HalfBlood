// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Catalog.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Catalog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    /// <summary>
    /// The catalog.
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Catalog"/> class.
        /// </summary>
        /// <param name="rn">
        /// The Rn.
        /// </param>
        public Catalog(long rn)
        {
            Rn = rn;
        }

        /// <summary>
        /// Gets or sets the Rn.
        /// </summary>
        public long Rn { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
