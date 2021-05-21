// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetMemoCode.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the GetMemoCode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    /// <summary>
    /// The get memo code.
    /// </summary>
    public class GetMemoCode : IStoredProcedure
    {
        /// <summary>
        /// Gets the table name.
        /// </summary>
        [StoredParameter("tableName")]
        public string TableName { get; private set; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        [StoredParameter("fieldName")]
        public string FieldName { get; private set; }

        /// <summary>
        /// Gets the input value.
        /// </summary>
        [StoredParameter("inputValue")]
        public int InputValue { get; private set; }

        /// <summary>
        /// Gets the output field.
        /// </summary>
        [StoredParameter("outputField")]
        public string OutputField { get; private set; }

        /// <summary>
        /// Gets the name stored procedure.
        /// </summary>
        public string Name
        {
            get { return "PKG_UDO_UTIL.F_GETMEMO"; }
        }

        public GetMemoCode(string tableName, string fieldName, int inputValue, string outputField)
        {
            TableName = tableName;
            FieldName = fieldName;
            InputValue = inputValue;
            OutputField = outputField;
        }
    }
}
