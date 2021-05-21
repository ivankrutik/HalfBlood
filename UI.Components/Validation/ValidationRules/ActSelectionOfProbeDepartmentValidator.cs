namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;
    using Halfblood.Common.Validations;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using UI.Resources;

    [ValidatorFor(typeof(ActSelectionOfProbeDepartment))]
    public class ActSelectionOfProbeDepartmentValidator : AbstractValidator<ActSelectionOfProbeDepartment>
    {
        public ActSelectionOfProbeDepartmentValidator()
        {
            RuleFor(x => x.Catalog).CatalogIsNull();
            RuleFor(x => x.DepartmentMakingSample).NotEmpty().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.Quantity).NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .GreaterThan(0)
                .WithMessage(CustomMessages.MustBeGreaterThenZero);
            RuleFor(x => x.DepartmentReceiver).NotNull().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.QuantityReceiver).NotNull().WithMessage(CustomMessages.EmptyField);
        }
    }
}
