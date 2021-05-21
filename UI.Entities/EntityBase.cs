// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The entity base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using FluentValidation;
    using FluentValidation.Results;

    using Halfblood.Common;
    using Halfblood.Common.Validations;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The entity base.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entity.
    /// </typeparam>
    public abstract class EntityBase<T> : IUiEntity, IDataErrorInfo
        where T : IUiEntity
    {
        object IHasUid.Rn { get { return Rn; } }
        private IValidator<T> _validator;
        private Catalog catalog;
        private long rn;

        /// <summary>
        /// The property changed.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string Error
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets or sets the RN.
        /// </summary>
        public long Rn
        {
            get
            {
                return this.rn;
            }
            set
            {
                this.rn = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the catalog.
        /// </summary>
        public Catalog Catalog
        {
            get
            {
                return this.catalog;
            }
            set
            {
                this.catalog = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string this[string columnName]
        {
            get
            {
                if (this._validator == null)
                {
                    this._validator = ValidationManager.Factory.GetValidator<T>();
                    if (_validator == null)
                    {
                        return string.Empty;
                    }
                }

                ValidationResult validationResult = this._validator.Validate(this);
                ValidationFailure validationFailure =
                    validationResult.Errors.FirstOrDefault(error => error.PropertyName == columnName);

                return validationFailure != null ? validationFailure.ErrorMessage : string.Empty;
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}