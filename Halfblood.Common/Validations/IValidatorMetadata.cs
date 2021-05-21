// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidatorMetadata.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IValidatorMetadata type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Validations
{
    using System;

    /// <summary>
    /// The ValidatorMetadata interface.
    /// </summary>
    public interface IValidatorMetadata
    {
        /// <summary>
        /// Gets the validator for entity.
        /// </summary>
        Type ValidatorForEntity { get; }
    }
}
