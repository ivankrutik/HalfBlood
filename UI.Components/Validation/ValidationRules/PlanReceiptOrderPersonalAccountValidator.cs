// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderPersonalAccountValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderPersonalAccountValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The plan receipt order personal account validator.
    /// </summary>
    [ValidatorFor(typeof(PlanReceiptOrderPersonalAccount))]
    public class PlanReceiptOrderPersonalAccountValidator : AbstractValidator<PlanReceiptOrderPersonalAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptOrderPersonalAccountValidator"/> class.
        /// </summary>
        public PlanReceiptOrderPersonalAccountValidator()
        {
            this.RuleFor(x => x.PersonalAccount)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .SetValidator(new PersonalAccountValidator());
            this.RuleFor(x => x.Note).MaxLenghtOfStringIs4000();
            this.RuleFor(x => x.CountByDocument)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .GreaterThanOrEqualTo(0)
                .WithMessage(CustomMessages.MustBeGreaterThenZero);
            this.RuleFor(x => x.CountFact)
               .NotNull()
               .WithMessage(CustomMessages.EmptyField)
               .GreaterThanOrEqualTo(0)
               .WithMessage(CustomMessages.MustBeGreaterThenZero);
        }
    }
}
