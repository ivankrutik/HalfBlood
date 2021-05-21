// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationUIEntityToDtoEntityAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the RelationUIEntityToDtoEntityAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;

    /// <summary>
    /// The relation UI entity to DTO entity attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RelationUiEntityToDtoEntityAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationUiEntityToDtoEntityAttribute"/> class.
        /// </summary>
        /// <param name="typeOfDto">
        /// The type of DTO.
        /// </param>
        public RelationUiEntityToDtoEntityAttribute(Type typeOfDto)
        {
            TypeOfDto = typeOfDto;
        }

        /// <summary>
        /// Gets the type of DTO.
        /// </summary>
        public Type TypeOfDto { get; private set; }
    }
}
