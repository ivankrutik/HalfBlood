// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PassValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Resources;


    [ValidatorFor(typeof(Pass))]
    public class PassValidator : AbstractValidator<Pass>
    {
        public PassValidator()
        {
            this.RuleFor(x => x.Note)
              .Length(0, 4000)
              .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }
    }

}
