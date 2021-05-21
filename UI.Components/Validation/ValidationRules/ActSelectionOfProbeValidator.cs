using FluentValidation;
using Halfblood.Common.Validations;
using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
using UI.Resources;

namespace UI.Components.Validation.ValidationRules
{
    [ValidatorFor(typeof(ActSelectionOfProbe))]
    public class ActSelectionOfProbeValidator : AbstractValidator<ActSelectionOfProbe>
    {
        public ActSelectionOfProbeValidator()
        {
            RuleFor(x => x.Catalog).CatalogIsNull();
            RuleFor(x => x.Note).Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            RuleFor(x => x.Sample).NotEmpty().WithMessage(CustomMessages.EmptyField).Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }
    }
}
