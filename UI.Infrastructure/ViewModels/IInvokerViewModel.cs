// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvokerViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The LoaderViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using ReactiveUI;

    /// <summary>
    /// The LoaderViewModel interface.
    /// </summary>
    public interface IInvokerViewModel : IAyncRunner
    {
        /// <summary>
        /// Gets the invoke command.
        /// </summary>
        ICommand InvokeCommand { get; }

        /// <summary>
        /// Gets the abort command.
        /// </summary>
        ICommand AbortCommand { get; }
    }

    /// <summary>
    /// Объект фильтрации данных с сервера.
    /// </summary>
    /// <typeparam name="TFilter">
    /// Тип фильтра, с которым работает объект фильтрации.
    /// </typeparam>
    /// <typeparam name="TFilteringObject">
    /// Тип данных.
    /// </typeparam>
    public interface IFilterViewModel<TFilter, TFilteringObject> : IInvokerViewModel, IReactiveNotifyPropertyChanged, IAyncRunner<IList<TFilteringObject>>
    {
        /// <summary>
        /// The command, which clear the filter.
        /// </summary>
        ICommand ClearFilterCommand { get; }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        TFilter Filter { get; }

        /// <summary>
        /// The set filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IFilterViewModel"/>.
        /// </returns>
        IFilterViewModel<TFilter, TFilteringObject> SetFilter(TFilter filter);
    }
}