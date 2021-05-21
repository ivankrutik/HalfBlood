// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterViewModelFactory.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FilterViewModelFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels
{
    using System;
    using System.ComponentModel.Composition;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    using ServiceContracts;

    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The filter view model factory.
    /// </summary>
    [Export(typeof(IFilterViewModelFactory))]
    public class FilterViewModelFactory : IFilterViewModelFactory
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterViewModelFactory"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">
        /// The unit of work factory.
        /// </param>
        [ImportingConstructor]
        public FilterViewModelFactory(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="observable">
        /// The observable.
        /// </param>
        /// <typeparam name="TFilter">
        /// The type of filter.
        /// </typeparam>
        /// <typeparam name="TEntity">
        /// The type of entity.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFilterViewModel"/>.
        /// </returns>
        public IFilterViewModel<TFilter, TEntity> Create<TFilter, TEntity>(IObservable<bool> observable = null, bool doRunning = false)
            where TEntity : IDto
            where TFilter : class, IUserFilter, new()
        {
            var viewModel = new GenericFilterViewModel<TFilter, TEntity>(_unitOfWorkFactory, observable);

            if (doRunning)
            {
                viewModel.InvokeCommand.Execute(null);
            }

            return viewModel;
        }
    }
}