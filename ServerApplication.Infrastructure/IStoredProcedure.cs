// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoredProcedure.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The StoredProcedure interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper
{
    /// <summary>
    /// The StoredProcedure interface.
    /// </summary>
    public interface IStoredProcedure
    {
       /// <summary>
       /// Gets the name stored procedure.
       /// </summary>
       string Name { get; }
    }
}
