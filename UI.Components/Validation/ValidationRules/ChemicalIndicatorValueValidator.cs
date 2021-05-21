// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChemicalIndicatorValueValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ChemicalIndicatorValueValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Resources;

    [ValidatorFor(typeof(ChemicalIndicatorValue))]
    public class ChemicalIndicatorValueValidator : AbstractValidator<ChemicalIndicatorValue>
    {
        public ChemicalIndicatorValueValidator()
        {
            this.RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage(CustomMessages.EmptyField)
                .Length(0, 4000)
                .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            this.RuleFor(x => x.DictChemicalIndicator)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
        }
    }
}
