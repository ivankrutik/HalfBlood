// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DestinationValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DestinationValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Resources;
   

    [ValidatorFor(typeof(Destination))]
    public class DestinationValidator : AbstractValidator<Destination>
    {
        public DestinationValidator()
        {
            this.RuleFor(x => x.Note)
             .Length(0, 4000)
             .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }
    }
}
