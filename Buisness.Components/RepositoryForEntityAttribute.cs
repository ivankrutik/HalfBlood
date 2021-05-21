// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryForEntityAttribute.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The repository for entity attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components
{
    using System;

    using Halfblood.Common;

    /// <summary>
    /// The repository for entity attribute.
    /// </summary>
    public class RepositoryForEntityAttribute : Attribute, IRegisterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryForEntityAttribute"/> class.
        /// </summary>
        /// <param name="typeOfEntity">
        /// The type of entity.
        /// </param>
        public RepositoryForEntityAttribute(Type typeOfEntity)
        {
            this.RegisterAsType = typeOfEntity;
        }

        /// <summary>
        /// Gets the register as type.
        /// </summary>
        public Type RegisterAsType { get; private set; }
    }
}