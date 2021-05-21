// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The plan certificate validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The plan certificate validator.
    /// </summary>
    [ValidatorFor(typeof(PlanCertificate))]
    public class PlanCertificateValidator : AbstractValidator<PlanCertificate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanCertificateValidator"/> class.
        /// </summary>
        public PlanCertificateValidator()
        {
            RuleFor(x => x.CountByDocument)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .GreaterThan(0)
                .WithMessage(CustomMessages.MustBeGreaterThenZero);
            RuleFor(x => x.CountFact)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .GreaterThan(0)
                .WithMessage(CustomMessages.MustBeGreaterThenZero);
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .GreaterThan(0)
                .WithMessage(CustomMessages.MustBeGreaterThenZero);
            RuleFor(x => x.ModificationNomenclature).NotNull().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.NameOfCurrency).NotNull().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.Note).Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            RuleFor(x => x.CertificateQuality).SetValidator(new CertificateQualityValidator());
            RuleFor(x => x.Measure).NotNull().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.TaxBand).NotNull().WithMessage(CustomMessages.EmptyField);
        }
    }
}
