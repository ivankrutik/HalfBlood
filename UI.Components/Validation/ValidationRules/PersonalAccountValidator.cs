// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountValidator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PersonalAccountValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The personal account validator.
    /// </summary>
    [ValidatorFor(typeof(PersonalAccount))]
    public class PersonalAccountValidator : AbstractValidator<PersonalAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalAccountValidator"/> class.
        /// </summary>
        public PersonalAccountValidator()
        {
            RuleFor(x => x.Numb).NotNullAndNotEmpty();
        }
    }
}
