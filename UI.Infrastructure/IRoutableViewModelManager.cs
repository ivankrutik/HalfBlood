// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoutableViewModelManager.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The ViewModelManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    using System;
    using System.Reactive;

    using JetBrains.Annotations;

    using ReactiveUI;

    /// <summary>
    /// The ViewModelManager interface.
    /// </summary>
    public interface IRoutableViewModelManager
    {
        /// <summary>
        /// The get view for view model.
        /// </summary>
        /// <typeparam name="TViewModel">
        /// The type of view model.
        /// </typeparam>
        /// <param name="destroyObservable">
        /// The observable of destroy event.
        /// </param>
        /// <returns>
        /// The <see cref="TViewModel"/>.
        /// </returns>
        [NotNull]
        TViewModel Get<TViewModel>(IObservable<Unit> destroyObservable = null)
            where TViewModel : IRoutableViewModel;

        /// <summary>
        /// The get view for view model.
        /// </summary>
        /// <param name="viewModelType">
        /// The view model manager.
        /// </param>
        /// <param name="destroyObservable">
        /// The observable of destroy event.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        [NotNull]
        object Get([NotNull]Type viewModelType, IObservable<Unit> destroyObservable = null);
    }
}
