// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Catalog.cs" company="VZ">
//   maraoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The catalog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLogic.Infrastructure
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
        /// The RN.
        /// </param>
        public Catalog(long rn)
        {
            Rn = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Catalog"/> class.
        /// </summary>
        public Catalog()
        {
        }

        /// <summary>
        /// Gets or sets the RN.
        /// </summary>
        public virtual long Rn { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Name;
        }
    }
}
