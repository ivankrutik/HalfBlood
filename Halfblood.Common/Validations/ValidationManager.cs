// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ValidationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Validations
{
    using FluentValidation;

    /// <summary>
    /// The validation manager.
    /// </summary>
    public static class ValidationManager
    {
        private static IValidatorFactory _factory;

        /// <summary>
        /// Gets the validation _factory.
        /// </summary>
        public static IValidatorFactory Factory
        {
            get
            {
                return _factory;
            }
        }
    }
}
