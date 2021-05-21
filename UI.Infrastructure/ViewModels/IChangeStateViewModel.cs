// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChangeStateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The ChangeStateViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    /// <summary>
    /// The ChangeStateViewModel interface.
    /// </summary>
    /// <typeparam name="TActionObject">
    /// The type of action object.
    /// </typeparam>
    /// <typeparam name="TState">
    /// The type of setting state.
    /// </typeparam>
    public interface IChangeStateViewModel<in TActionObject, TState> : IInvokerViewModel
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        TState State { get; set; }

        /// <summary>
        /// The set action object.
        /// </summary>
        /// <param name="object">
        /// The object.
        /// </param>
        void SetActionObject(TActionObject @object);
    }
}
