// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCuttingOrder.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the GetCuttingOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    /// <summary>
    /// The get cutting order.
    /// </summary>
    public class GetCuttingOrder : IStoredProcedure
    {

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return "GetCuttingOrder"; }
        }
    }
}
