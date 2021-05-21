// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredParameterAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StoredParameterAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper
{
    using System;

    public enum TypeParameter
    {
        Input,
        Output
    }

    /// <summary>
    /// The stored parameter attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class StoredParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredParameterAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <param name="typeParameter">
        /// The type input/output parameter.
        /// </param>
        public StoredParameterAttribute(string parameterName, TypeParameter typeParameter = TypeParameter.Input)
        {
            ParameterName = parameterName;
            TypeParameter = typeParameter;
        }

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// The type of parameter.
        /// </summary>
        public TypeParameter TypeParameter { get; private set; }
    }
}
