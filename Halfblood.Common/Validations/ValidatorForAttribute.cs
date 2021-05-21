// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorForAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The validator attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Validations
{
    using System;
    using System.ComponentModel.Composition;

    using FluentValidation;

    /// <summary>
    /// The validator attribute.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ValidatorForAttribute : ExportAttribute
    {
        /// <summary>
        /// Gets the validator for entity.
        /// </summary>
        public Type ValidatorForEntity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorForAttribute"/> class.
        /// </summary>
        /// <param name="validatorForEntity">
        /// The validator for entity.
        /// </param>
        public ValidatorForAttribute(Type validatorForEntity)
            : base(typeof(IValidator))
        {
            this.ValidatorForEntity = validatorForEntity;
        }
    }
}
