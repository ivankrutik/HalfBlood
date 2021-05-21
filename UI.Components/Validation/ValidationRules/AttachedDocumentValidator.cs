// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentValidator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the AttachedDocumentValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation.ValidationRules
{
    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Resources;

    /// <summary>
    /// The attached document validator.
    /// </summary>
    [ValidatorFor(typeof(AttachedDocument))]
    public class AttachedDocumentValidator : AbstractValidator<AttachedDocument>
    {
        public AttachedDocumentValidator()
        {
            RuleFor(x => x.Catalog).CatalogIsNull();
            RuleFor(x => x.Content).NotNull().WithMessage("Загрузите изображение");
            RuleFor(x => x.DocumentType).NotNull().WithMessage(CustomMessages.EmptyField);
            RuleFor(x => x.Parent).NotNull().WithMessage("Родительский документ должен быть задан");
            //RuleFor(x => x.Code).NotNullAndNotEmpty();
        }
    }
}
