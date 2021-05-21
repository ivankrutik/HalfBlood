// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAgnlistWithDepartment.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The get agnlist with department.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    /// <summary>
    /// The get agnlist with department.
    /// </summary>
    public class GetAgnlistWithDepartment : IStoredProcedure
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return "GetAgnlistWithDepartment"; }
        }
    }
}