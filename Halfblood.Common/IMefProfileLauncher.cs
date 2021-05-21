// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMefProfileLauncher.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The MefProfileLoader interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System.ComponentModel.Composition.Hosting;

    /// <summary>
    /// The MEF profile loader interface.
    /// </summary>
    public interface IMefProfileLauncher
    {
        /// <summary>
        /// The load map profiles.
        /// </summary>
        void LoadProfiles(CompositionContainer container);
    }
}