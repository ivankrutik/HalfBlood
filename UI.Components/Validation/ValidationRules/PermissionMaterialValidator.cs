// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionMaterialValidator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PermissionMaterialValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.PermissionMaterialDomain;
    using UI.Resources;

    [ValidatorFor(typeof(PermissionMaterial))]
    public class PermissionMaterialValidator : AbstractValidator<PermissionMaterial>
    {
        public PermissionMaterialValidator()
        {
            this.RuleFor(x => x.AcceptToDate)
               .NotNull()
               .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.Count)
               .NotNull()
               .WithMessage(CustomMessages.EmptyField)
                .GreaterThanOrEqualTo(0)
               .WithMessage(CustomMessages.MustBeGreaterThenZero);
            this.RuleFor(x => x.Catalog).NotNull().WithMessage(CustomMessages.AcatalogIsNull);
            this.RuleFor(x => x.Note).Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            this.RuleFor(x => x.Justification)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .Length(0, 4000)
                .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            this.RuleFor(x => x.Obj)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField)
                .Length(0, 4000)
                .WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }
    }
}
