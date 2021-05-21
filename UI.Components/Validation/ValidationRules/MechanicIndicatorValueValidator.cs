// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MechanicIndicatorValueValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MechanicIndicatorValueValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Resources;
   

    [ValidatorFor(typeof(MechanicIndicatorValue))]
    public class MechanicIndicatorValueValidator : AbstractValidator<MechanicIndicatorValue>
    {
        public MechanicIndicatorValueValidator()
        {
            this.RuleFor(x => x.MechanicalIndicator)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage(CustomMessages.EmptyField)
                 .Length(0, 4000)
                 .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }
    }
}
