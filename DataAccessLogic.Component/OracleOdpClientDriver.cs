// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OracleOdpClientDriver.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the OracleOdpClientDriver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLogic.Component
{
    using NHibernate.Driver;

    using Oracle.DataAccess.Client;

    /// <summary>
    /// The oracle odp client driver.
    /// </summary>
    public class OracleOdpClientDriver : OracleDataClientDriver
    {
        /// <summary>
        /// The initialize parameter.
        /// </summary>
        /// <param name="dbParam">
        /// The db param.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="sqlType">
        /// The sql type.
        /// </param>
        protected override void InitializeParameter(System.Data.IDbDataParameter dbParam, string name,
                                                    NHibernate.SqlTypes.SqlType sqlType)
        {
            base.InitializeParameter(dbParam, name, sqlType);
            var oraParam = dbParam as OracleParameter;
            if (oraParam != null)
            {
                if (sqlType.DbType == System.Data.DbType.Binary)
                {
                    oraParam.OracleDbType = OracleDbType.Blob;
                }
                else if (sqlType.DbType == System.Data.DbType.String && sqlType.LengthDefined && sqlType.Length >= 32768)
                {
                    oraParam.OracleDbType = OracleDbType.Clob;
                }
            }
        }
    }
}
