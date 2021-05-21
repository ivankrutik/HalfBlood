// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ServiceBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Filtering.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;

    /// <summary>
    /// The service base.
    /// </summary>
    public abstract class ServiceBase
    {
        protected readonly IRepositoryFactory RepositoryFactory;

        protected ServiceBase(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
        {
            if (repositoryFactory == null)
            {
                throw new ArgumentNullException("repositoryFactory");
            }

            if (filterStrategyFactory == null)
            {
                throw new ArgumentNullException("filterStrategyFactory");
            }

            RepositoryFactory = repositoryFactory;
            QueryOverExtension.SetFilterStrategyFactory(filterStrategyFactory);
        }

        protected virtual TEntity GetEntity<TEntity>(long id)
            where TEntity : class, IHasUid
        {
            return RepositoryFactory.Create<TEntity>().Get(id);
        }

        protected virtual TDto GetEntity<TEntity, TDto>(long id)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            var d = RepositoryFactory.Create<TEntity>().Get(id);
            return d.MapTo<TDto>();
        }

        protected virtual IList<TDto> GetEntities<TFilter, TEntity, TDto>(
            TFilter filter,
            Action<IQueryOver<TEntity, TEntity>> action = null)
            where TEntity : class, IHasUid
            where TFilter : IUserFilter
        {
            IQueryOver<TEntity, TEntity> query = RepositoryFactory.Create<TEntity>()
                .Specify();

            if (action != null)
            {
                action(query);
            }

            return query.Filtering(filter).List<TEntity>().MapTo<TDto>();
        }

        protected virtual IList<TDto> GetEntities<TFilter, TDto>(
            TFilter filter,
            Action<IQueryOver<TDto, TDto>> action = null)
            where TFilter : IUserFilter
            where TDto : class, IHasUid
        {
            IQueryOver<TDto, TDto> query = RepositoryFactory.Create<TDto>().Specify();

            if (action != null)
            {
                action(query);
            }

            if (filter != null)
            {
                query.Filtering(filter);
            }

            return query.List<TDto>();
        }

        protected virtual IList<TDto> GetEntities<TEntity, TDto>(
            Action<IQueryOver<TEntity, TEntity>> action = null)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            IQueryOver<TEntity, TEntity> query = RepositoryFactory.Create<TEntity>().Specify();

            if (action != null)
            {
                action(query);
            }

            return query.List<TDto>();
        }

        protected virtual TDto AddEntity<TEntity, TDto>(TDto dto)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            var entity = Mapper.Map<TEntity>(dto);
            repository.Insert(entity);

            var result = entity.MapTo<TDto>();

            return result;
        }

        protected virtual TDto AddEntity<TEntity, TDto>(TEntity entity)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            repository.Insert(entity);

            var result = entity.MapTo<TDto>();

            return result;
        }

        protected virtual void RemoveEntity<TEntity>(TEntity entity)
            where TEntity : class, IHasUid
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            
            repository.Delete(entity);
        }
 
        protected virtual void RemoveEntity<TEntity, TDto>(TDto dto)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            repository.Delete(Mapper.Map<TEntity>(dto));
        }

        protected virtual void UpdateEntity<TEntity, TDto>(TDto dto)
            where TEntity : class, IHasUid
            where TDto : IDto
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            var entity = Mapper.Map<TEntity>(dto);

           
            repository.Update(entity);
        }

        protected virtual IList<TEntity> ExecuteStoreProcedure<TEntity>(IStoredProcedure sp)
            where TEntity : class, IHasUid
        {
            var repository = this.RepositoryFactory.Create<TEntity>();
            return repository.ExecuteSPResultList<TEntity>(sp);
        }

        protected virtual IList<IDto> GetEntities(Type type, IUserFilter filter)
        {
            return Enumerable.Empty<IDto>().ToList();
        }
    }
}