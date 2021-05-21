// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessRelation.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ProcessRelation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents
{
    using Halfblood.Common.Mappers;

    /// <summary>
    /// The process relation.
    /// </summary>
    internal class ProcessRelation : Relations
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