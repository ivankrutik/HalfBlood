// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionMaterialExtensionValidator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PermissionMaterialExtensionValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.PermissionMaterialDomain;
    using UI.Resources;

    [ValidatorFor(typeof(PermissionMaterialExtension))]
    public class PermissionMaterialExtensionValidator : AbstractValidator<PermissionMaterialExtension>
    {
        public PermissionMaterialExtensionValidator()
        {

            this.RuleFor(x => x.AcceptToDate)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
         
            //RuleFor(x => x.PermissionMaterial).SetValidator(new CertificateQualityValidator());
        }
    }
}
