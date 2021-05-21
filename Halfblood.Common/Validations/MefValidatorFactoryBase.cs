// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MefValidatorFactoryBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MefValidatorFactoryBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Validations
{
    using System;

    using FluentValidation;

    /// <summary>
    /// The MEF validator factory base.
    /// </summary>
    public abstract class MefValidatorFactoryBase : MefLoaderBase<IValidator, IValidatorMetadata, Type, Func<IValidator>>, IValidatorFactory
    {
        /// <summary>
        /// The get validator.
        /// </summary>
        /// <typeparam name="T">
        /// The type validate object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IValidator"/>.
        /// </returns>
        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)this.GetValidator(typeof(T));
        }

        /// <summary>
        /// The get validator.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IValidator"/>.
        /// </returns>
        public IValidator GetValidator(Type type)
        {
            return this.CreateInstance(typeof(IValidator<>).MakeGenericType(new Type[1]
                                                                                {
                                                                                    type
                                                                                }));
        }

        /// <summary>
        /// The create instance.
        /// </summary>
        /// <param name="validatorType">
        /// The validator type.
        /// </param>
        /// <returns>
        /// The <see cref="IValidator"/>.
        /// </returns>
        public abstract IValidator CreateInstance(Type validatorType);
    }
}