// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterForEntityAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FilterForEntityAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using System;

    using Halfblood.Common;

    /// <summary>
    /// The filter for attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class FilterForEntityAttribute : Attribute, IRegisterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterForEntityAttribute"/> class.
        /// </summary>
        /// <param name="filterForEntityOfType">
        /// The filter for entity of type.
        /// </param>
        public FilterForEntityAttribute(Type filterForEntityOfType)
        {
            this.RegisterAsType = filterForEntityOfType;
        }

        public Type RegisterAsType { get; private set; }
    }
}