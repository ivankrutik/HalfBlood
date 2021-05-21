// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditState.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The edit state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    /// <summary>
    /// The edit state.
    /// </summary>
    public enum EditState : byte
    {
        /// <summary>
        /// The update.
        /// </summary>
        Edit,

        /// <summary>
        /// The save.
        /// </summary>
        Insert,

        /// <summary>
        /// The update.
        /// </summary>
        Delete,

        Clone
    }
}
