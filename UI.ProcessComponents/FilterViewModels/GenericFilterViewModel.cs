// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericFilterViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the GenericFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reactive.Linq;

    using Filtering.Infrastructure;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    public class GenericFilterViewModel<TFilter, TEntity> : FilterViewModelBase<TFilter, TEntity>
        where TFilter : class, IUserFilter, new()
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory;
        private readonly IObservable<bool> _canExecuteObservableToInvoke;

        public GenericFilterViewModel(
            IUnitOfWorkFactory unitOfWorkFactory)
            : this(unitOfWorkFactory, null)
        {
        }

        public GenericFilterViewModel(
            IUnitOfWorkFactory unitOfWorkFactory,
            IObservable<bool> canExecuteObservableToInvoke)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            _canExecuteObservableToInvoke = canExecuteObservableToInvoke;
            Filter = new TFilter();
            Result = new ReactiveList<TEntity>();
        }

        protected override IObservable<bool> CanExecuteToInvoke()
        {
            return _canExecuteObservableToInvoke ?? Observable.Return(true);
        }
        protected override IList<TEntity> DoLoad()
        {
            Contract.Ensures(Contract.Result<object>() != null);

            using (IUnitOfWork unitOfWork = this.UnitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IFilteringService>();
                var result = service.Filtering(typeof(TEntity), Filter);

                return result == null
                           ? Enumerable.Empty<TEntity>().ToList()
                           : (IList<TEntity>)new ReactiveList<TEntity>(result.Cast<TEntity>());
            }
        }
    }
}
