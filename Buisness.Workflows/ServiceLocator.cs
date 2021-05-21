// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceLocator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ServiceLocator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using System.ComponentModel.Composition.Hosting;

    /// <summary>
    /// The service locator.
    /// </summary>
    internal static class ServiceLocator
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public static CompositionContainer Container { get; set; }
    }
}
