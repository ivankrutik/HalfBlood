// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessRelation.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The buisness relation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using Halfblood.Common.Mappers;

    /// <summary>
    /// The business relation.
    /// </summary>
    public class BusinessRelation : Relations
    {
        private static Relations _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Relations Instance
        {
            get
            {
                return _instance ?? (_instance = new Relations());
            }
        }
    }
}
