// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasState.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The HasState interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities
{
    /// <summary>
    /// The HasState interface.
    /// </summary>
    public interface IHasState
    {
    }

    /// <summary>
    /// The HasState interface.
    /// </summary>
    /// <typeparam name="TState">
    /// The type of state.
    /// </typeparam>
    public interface IHasState<TState> : IHasState
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        TState State { get; set; }
    }
}
