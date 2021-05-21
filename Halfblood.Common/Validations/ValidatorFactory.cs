// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The RegisterValidatorFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Validations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using FluentValidation;

    /// <summary>
    /// The validator factory.
    /// </summary>
    [Export(typeof(IValidatorFactory))]
    public class ValidatorFactory : MefValidatorFactoryBase
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="validator">
        /// The validator.
        /// </param>
        /// <typeparam name="TObject">
        /// The type of object.
        /// </typeparam>
        public void Register<TObject>(IValidator validator)
        {
            this.Register(typeof(TObject), () => validator);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object.
        /// </typeparam>
        /// <typeparam name="TValidator">
        /// The type of validator.
        /// </typeparam>
        public void Register<TObject, TValidator>()
            where TValidator : IValidator
        {
            this.Register(typeof(TObject), () => Activator.CreateInstance<TValidator>());
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
        public override IValidator CreateInstance(Type validatorType)
        {
            try
            {
                return this.GetContent(validatorType)();
            }
            catch (KeyNotFoundException e)
            {
                Log.LogManager.Log.Debug(e);
                return null;
            }
        }

        /// <summary>
        /// The imports.
        /// </summary>
        /// <param name="validator">
        /// The validator.
        /// </param>
        protected override void Imports(Lazy<IValidator, IValidatorMetadata> validator)
        {
            this.Register(validator.Metadata.ValidatorForEntity, () => validator.Value);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="validatorForEntity">
        /// The validator for entity.
        /// </param>
        /// <param name="func">
        /// The function.
        /// </param>
        private void Register(Type validatorForEntity, Func<IValidator> func)
        {
            this.Contents.Add(typeof(IValidator<>).MakeGenericType(validatorForEntity), func);
        }
    }
}
