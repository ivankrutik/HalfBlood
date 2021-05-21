// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterAttribute.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the RegisterAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    /// The register attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class RegisterAttribute : Attribute, IRegisterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterAttribute"/> class.
        /// </summary>
        /// <param name="registerAsType">
        /// The register as type.
        /// </param>
        public RegisterAttribute([NotNull] Type registerAsType)
        {
            RegisterAsType = registerAsType;
        }

        /// <summary>
        /// Gets the register as type.
        /// </summary>
        [NotNull]
        public Type RegisterAsType { get; private set; }
    }
}
