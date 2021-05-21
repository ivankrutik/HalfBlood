// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilterViewModelFactory.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The FilterViewModelFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.Filters
{
    using System;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    /// <summary>
    /// Создает объект,
    /// который просит сервер отфильтровать данные по фильтру
    /// и возвращает эти данные в свойство Result.
    /// </summary>
    public interface IFilterViewModelFactory
    {
        /// <summary>
        /// Создать объект для фильтрации.
        /// </summary>
        /// <param name="observable">
        /// Последовательность, которая уведомляет - можно ли запустить фильтрацию данных.
        /// </param>
        /// <typeparam name="TFilter">
        /// Тип фильтра, с которым работает объект фильтрации
        /// </typeparam>
        /// <typeparam name="TDto">
        /// Тип возвращаемой DTO
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFilterViewModel"/>.
        /// </returns>
        IFilterViewModel<TFilter, TDto> Create<TFilter, TDto>(IObservable<bool> observable = null, bool doRunning = false)
            where TDto : IDto
            where TFilter : class, IUserFilter, new();
    }
}