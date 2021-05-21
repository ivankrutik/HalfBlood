// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Resources;

    /// <summary>
    /// The certificate quality validator.
    /// </summary>
    [ValidatorFor(typeof(CertificateQuality))]
    public class CertificateQualityValidator : AbstractValidator<CertificateQuality>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateQualityValidator"/> class.
        /// </summary>
        public CertificateQualityValidator()
        {
            RuleFor(x => x.Catalog).CatalogIsNull();
            RuleFor(x => x.Note).MaxLenghtOfStringIs4000();
            RuleFor(x => x.Cast).MaxLenghtOfStringIs4000();
            RuleFor(x => x.FullRepresentation).MaxLenghtOfStringIs4000();
            RuleFor(x => x.GostCast).MaxLenghtOfStringIs4000();
            RuleFor(x => x.GostMix).MaxLenghtOfStringIs4000();
            RuleFor(x => x.Marka).MaxLenghtOfStringIs4000();
            RuleFor(x => x.Mix).MaxLenghtOfStringIs4000();
            RuleFor(x => x.Sizes).MaxLenghtOfStringIs4000();
            RuleFor(x => x.Sizes).MaxLenghtOfString(100, CustomMessages.MaxStringLenght100);

            When(x => 
                !string.IsNullOrWhiteSpace(x.Cast) ||
                !string.IsNullOrWhiteSpace(x.GostCast) ||
                !string.IsNullOrWhiteSpace(x.GostMix) ||
                !string.IsNullOrWhiteSpace(x.Marka) ||
                !string.IsNullOrWhiteSpace(x.Mix) ||
                !string.IsNullOrWhiteSpace(x.Sizes), () => { });
        }
    }
}