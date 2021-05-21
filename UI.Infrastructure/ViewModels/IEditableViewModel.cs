// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditableViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System.Windows.Input;

    /// <summary>
    /// The EditableViewModel interface.
    /// </summary>
    public interface IEditableViewModel
    {
        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        ICommand CancelCommand { get; }

        /// <summary>
        /// Gets the apply command.
        /// </summary>
        ICommand ApplyCommand { get; }

        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }
    }

    /// <summary>
    /// The EditableViewModel interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type of editable object
    /// </typeparam>
    public interface IEditableViewModel<T> : IEditableViewModel
    {
        /// <summary>
        /// Gets the edit state.
        /// </summary>
        EditState EditState { get; }

        /// <summary>
        /// Gets the editable object.
        /// </summary>
        T EditableObject { get; }


        /// <summary>
        /// The set editable object.
        /// </summary>
        /// <param name="obj">
        ///     The object for edit.
        /// </param>
        /// <param name="state">
        ///     The state.
        /// </param>
        void SetEditableObject(T obj, EditState state);
    }
}