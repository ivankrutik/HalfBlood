// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterViewModelBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The filter view model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Infrastructure.ViewModels;
    using ReactiveUI;

    /// <summary>
    /// The filter view model base.
    /// </summary>
    /// <typeparam name="TFilter">
    /// The type of the filter
    /// </typeparam>
    /// <typeparam name="TFilteringObject">
    /// The type of the filtering object
    /// </typeparam>
    public abstract class FilterViewModelBase<TFilter, TFilteringObject>
        : AsyncLoaderViewModelBase<IList<TFilteringObject>>, IFilterViewModel<TFilter, TFilteringObject>
        where TFilter : class, new()
    {
        private TFilter _filter;
        private ReactiveCommand _clearFilterCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterViewModelBase{TFilter,TFilteringObject}"/> class.
        /// </summary>
        protected FilterViewModelBase()
        {
            Result = new ReactiveList<TFilteringObject>();
        }

        /// <summary>
        /// The command, which clear the filter.
        /// </summary>
        public ICommand ClearFilterCommand
        {
            get
            {
                if (_clearFilterCommand == null)
                {
                    _clearFilterCommand = new ReactiveCommand(Observable.Return(true));
                    _clearFilterCommand.Subscribe(_ => Filter = new TFilter());
                }

                return _clearFilterCommand;
            }
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        public TFilter Filter
        {
            get { return _filter; }
            protected set { this.RaiseAndSetIfChanged(ref _filter, value); }
        }

        /// <summary>
        /// The set filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IFilterViewModel"/>.
        /// </returns>
        public IFilterViewModel<TFilter, TFilteringObject> SetFilter(TFilter filter)
        {
            Filter = filter;
            return this;
        }
    }
}