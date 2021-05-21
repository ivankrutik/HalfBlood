// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuerySPExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the QuerySPExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter.Specification
{
    using System;

    using Halfblood.Common;

    /// <summary>
    /// The query stored procedure extension.
    /// </summary>
    public static class QuerySpExtension
    {
        /// <summary>
        /// The execute stored procedure.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="storedProcedure">
        /// The stored procedure.
        /// </param>
        /// <returns>
        /// The <see cref="IQuery"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The stored procedure is null.
        /// </exception>
        public static IQuery ExecuteSp(this ISession query, IStoredProcedure storedProcedure)
        {
            if (storedProcedure == null)
            {
                throw new ArgumentNullException("storedProcedure");
            }

            IQuery executeSp = query.GetNamedQuery(storedProcedure.Name);

            storedProcedure.GetPropertiesMarkAttribute(
                (StoredParameterAttribute attribute, object value) =>
                executeSp.SetParameter(attribute.ParameterName, value));

            return executeSp;
        }
    }
}