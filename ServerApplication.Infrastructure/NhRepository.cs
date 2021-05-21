// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NhRepository.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NhRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Halfblood.Common;

    using NHibernate;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;

    public class NhRepository<TEntity> : INhRepository<TEntity>
        where TEntity : class, IHasUid
    {
        protected readonly ISession Session;

        public NhRepository(ISession session)
        {
            this.Session = session;
        }

        public TEntity Get(object id)
        {
            return this.Session.Get<TEntity>(id);
        }
        public TEntity Load(object id)
        {
            return this.Session.Load<TEntity>(id);
        }
        public virtual IQueryOver<TEntity, TEntity> Specify()
        {
            return this.Session.QueryOver<TEntity>();
        }
        public virtual object Insert(TEntity entity)
        {
            var keyEntity = this.Session.Save(entity);
            return keyEntity;
        }
        public virtual void Update(TEntity entity)
        {
            var newEntity = Session.Merge(entity);
            Session.Update(newEntity);
        }
       
        public virtual void Delete(TEntity entity)
        {
            this.Session.Delete(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public IList<TRet> ExecuteSPResultList<TRet>(IStoredProcedure sp)
        {
            return Session.ExecuteSp(sp).SetFetchSize(100).List<TRet>();
        }
        public TRet ExecuteSPUniqueResult<TRet>(IStoredProcedure sp)
        {
            return Session.ExecuteSp(sp).UniqueResult<TRet>();
        }

        public void Evict(TEntity entity)
        {
           Session.Evict(entity);
        }
    }
}