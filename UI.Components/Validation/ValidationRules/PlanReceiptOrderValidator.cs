// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderValidator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The plan receipt order validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.Components.Validation.ValidationRules
{
    using System;

    using FluentValidation;

    using Halfblood.Common.Validations;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The plan receipt order validator.
    /// </summary>
    [ValidatorFor(typeof(PlanReceiptOrder))]
    public class PlanReceiptOrderValidator : AbstractValidator<PlanReceiptOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptOrderValidator"/> class.
        /// </summary>
        public PlanReceiptOrderValidator()
        {
            this.RuleFor(x => x.Catalog).CatalogIsNull();
            this.RuleFor(x => x.Note).Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
            this.RuleFor(x => x.UserContractor).NotNull().WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.StoreGasStationOilDepot).NotNull().WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundDocumentNumb)
                .NotEmpty()
                .WithMessage(CustomMessages.EmptyField)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundDocumentDate)
                .GreaterThan(new DateTime(2012, 1, 1))
                .WithMessage("Дата должна быть больше 2012г")
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundReceiptDocumentDate)
                .GreaterThan(new DateTime(2012, 1, 1))
                .WithMessage("Дата должна быть больше 2012г")
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundReceiptDocumentNumb)
                .NotEmpty()
                .WithMessage(CustomMessages.EmptyField)
                .NotNull()
                .WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundReceiptTypeOfDocument).NotNull().WithMessage(CustomMessages.EmptyField);
            this.RuleFor(x => x.GroundTypeOfDocument).NotNull().WithMessage(CustomMessages.EmptyField);
        }
    }
}
