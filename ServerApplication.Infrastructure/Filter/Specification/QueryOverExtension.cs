// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryOverExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the QueryOverExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter.Specification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    using NHibernate.Criterion;

    public static class QueryOverExtension
    {
        private static IFilterStrategyFactory _filterStrategyFactory;

        public static IQueryOver<TEntity, TEntity> FindByRn<TEntity>(
            this IQueryOver<TEntity, TEntity> query, object rn)
            where TEntity : IHasUid
        {
            if (rn is string && string.IsNullOrWhiteSpace((string)rn))
            {
                return query;
            }

            if (rn is long && (long)rn <= 0)
            {
                return query;
            }

            if (rn is int && (int)rn <= 0)
            {
                return query;
            }

            return query.Where(x => x.Rn == rn);
        }

        public static IQueryOver<TEntity, TEntity> TotalOut<TEntity>(
            this IQueryOver<TEntity, TEntity> query, out int total)
        {
            total = query.RowCount();
            return query;
        }

        public static IQueryOver<TEntity, TEntity> SkipTake<TEntity>(
            this IQueryOver<TEntity, TEntity> query, int skip, int take)
        {
            if (skip > 0)
            {
                query.Skip(skip);
            }

            if (skip > 0)
            {
                query.Take(take);
            }

            return query;
        }

        public static IQueryOver<TEntity, TEntity> FetchEager<TEntity>(
            this IQueryOver<TEntity, TEntity> query, Expression<Func<TEntity, object>> property)
        {
            return query.Fetch(property).Eager;
        }

        public static IQueryOver<TEntity, TEntity> Filtering<TEntity>(
            this IQueryOver<TEntity, TEntity> query, IUserFilter filter)
            where TEntity : IHasUid
        {
            if (_filterStrategyFactory == null)
            {
                throw new ArgumentNullException("FilterStrategyFactory is not initialize");
            }

            IFilteringStrategy<TEntity> strategy = _filterStrategyFactory.Create<TEntity>();

            if (strategy == null)
            {
                throw new ArgumentNullException(
                    string.Format("filter strategy for entity of type '{0}' is not found", typeof(TEntity).FullName));
            }

            return strategy.Filtering(query, filter);
        }

        public static IQueryOver<TEntity, TEntity> IsBetween<TEntity, U>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            Between<U> between)
        {
            if (between == null)
            {
                return query;
            }

            if (object.Equals(between.From, null) || object.Equals(between.To, null))
            {
                return query;
            }

            return query.WhereRestrictionOn(property)
                .IsBetween(between.From)
                .And(between.To);
        }

        public static IQueryOver<TEntity, TEntity> IsLike<TEntity>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            string value,
            MatchMode matchMode)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return query;
            }

            return query.WhereRestrictionOn(property).IsLike(value, matchMode);
        }

        public static IQueryOver<TEntity, TEntity> IsLike<TEntity>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return query;
            }

            return IsLike(query, property, value, MatchMode.Start);
        }

        public static IQueryOver<TEntity, TEntity> IsInEmpty<TEntity>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            object[] parameters)
        {
            return
                query.WhereRestrictionOn(property)
                    .IsIn(parameters.ToArray());
        }

        public static IQueryOver<TEntity, TEntity> IsInEmpty<TEntity, U>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            IList<U> parameters)
        {
                return
                    query.WhereRestrictionOn(property)
                        .IsIn(parameters.ToArray());
        }

        public static IQueryOver<TEntity, TEntity> IsIn<TEntity>(
          this IQueryOver<TEntity, TEntity> query,
          Expression<Func<TEntity, object>> property,
          object[] parameters)
        {
            if (parameters != null && parameters.Any())
            {
                query.IsInEmpty(property, parameters);
            }

            return query;
        }

        public static IQueryOver<TEntity, TEntity> IsIn<TEntity, U>(
            this IQueryOver<TEntity, TEntity> query,
            Expression<Func<TEntity, object>> property,
            IList<U> parameters)
        {
            if (parameters != null && parameters.Any())
            {
                query.IsInEmpty(property,parameters);
            }

            return query;
        }

        public static void SetFilterStrategyFactory(IFilterStrategyFactory filterStrategyFactory)
        {
            _filterStrategyFactory = filterStrategyFactory;
        }

        public static IQueryOver<TEntity, TSubEntity> EqualsUser<TEntity, TSubEntity>(
            this IQueryOver<TEntity, TSubEntity> query,
            Expression<Func<TSubEntity, object>> property)
        {
            return
                query.Where(
                    Restrictions.EqProperty(
                        Projections.SqlFunction("User", NHibernateUtil.String),
                        Projections.Property(property)));
        }
    }
}