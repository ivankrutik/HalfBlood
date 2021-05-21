// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentValidatorMixin.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FluentValidatorMixin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Validation
{
    using FluentValidation;
    using UI.Resources;


    /// <summary>
    /// The fluent validator mixin.
    /// </summary>
    public static class FluentValidatorMixin
    {
        /// <summary>
        /// The not null and not empty.
        /// </summary>
        /// <param name="ruleBuilder">
        /// The rule builder.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRuleBuilderOptions"/>.
        /// </returns>
        public static IRuleBuilderOptions<T, TProperty> NotNullAndNotEmpty<T, TProperty>(this IRuleBuilderInitial<T, TProperty> ruleBuilder)
        {
            return
                ruleBuilder.NotNull()
                    .WithMessage(CustomMessages.EmptyField)
                    .NotEmpty()
                    .WithMessage(CustomMessages.EmptyField);
        }

        /// <summary>
        /// The catalog is null.
        /// </summary>
        /// <param name="ruleBuilder">
        /// The rule builder.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRuleBuilderOptions"/>.
        /// </returns>
        public static IRuleBuilderOptions<T, TProperty> CatalogIsNull<T, TProperty>(this IRuleBuilderInitial<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.NotNull().WithMessage(CustomMessages.AcatalogIsNull);
        }

        /// <summary>
        /// The max lenght of string.
        /// </summary>
        /// <param name="ruleBuilder">
        /// The rule builder.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRuleBuilderOptions"/>.
        /// </returns>
        public static IRuleBuilderOptions<T, string> MaxLenghtOfString<T>(this IRuleBuilder<T, string> ruleBuilder, int max, string message)
        {
            return ruleBuilder.Length(0, max).WithMessage(message);
        }

        /// <summary>
        /// The max lenght of string is 4000.
        /// </summary>
        /// <param name="ruleBuilder">
        /// The rule builder.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRuleBuilderOptions"/>.
        /// </returns>
        public static IRuleBuilderOptions<T, string> MaxLenghtOfStringIs4000<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Length(0, 4000).WithMessage(CustomMessages.MaxLenghtOfStringIs4000);
        }

//        public static IRuleBuilderOptions<T, TProperty?> NotNullAndGreaterThanZero<T, TProperty>(this IRuleBuilder<T, TProperty?> ruleBuilder) 
//            where TProperty : struct, IComparable<TProperty>, IComparable
//        {
//            return
//                ruleBuilder.NotNull()
//                    .WithMessage(CustomMessages.EmptyField)
//                    .GreaterThan(0)
//                    .WithMessage(CustomMessages.MustBeGreaterThenZero);
//        }
    }
}