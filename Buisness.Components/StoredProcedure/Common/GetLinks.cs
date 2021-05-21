// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetMemoCode.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the GetMemoCode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Halfblood.Common;

namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    /// <summary>
    /// The get memo code.
    /// </summary>
    public class GetLinks : IStoredProcedure
    {
        /// <summary>
        /// Gets the table name.
        /// </summary>
        [StoredParameter("RN")]
        public long Rn { get; private set; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        [StoredParameter("Direction")]
        public DirectionFind Direction { get; private set; }

       
        /// <summary>
        /// Gets the name stored procedure.
        /// </summary>
        public string Name
        {
            get { return "PKG_UDO_UTIL.Get_Links"; }
        }

        public GetLinks(long rn, DirectionFind direction)
        {
            Rn = rn;
            Direction = direction;
        }
    }
}
