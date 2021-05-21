// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeNhConnection.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeNhConnection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq.Expressions;

    using Halfblood.Common.Connection;

    using NhConnection.Infrasctructure;

    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Engine;
    using NHibernate.Impl;
    using NHibernate.Metadata;
    using NHibernate.Stat;
    using NHibernate.Transaction;
    using NHibernate.Type;

    using Rhino.Mocks;

    public class FakeNhConnection : INhConnection
    {
        public void Connecting(AuthorizationMetadata metadata)
        {
            Connecting(metadata.Login, metadata.Password, metadata.Database);
        }

        public ISessionFactory GetSessionFactory()
        {
            return new FakeSessionFactory();
        }

        public void Connecting(string login, string password, string database)
        {
            
        }

        public void Connecting()
        {
            throw new NotImplementedException();
        }
    }
    public class FakeSessionFactory : ISessionFactory
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession()
        {
            return new FakeSession();
        }

        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            throw new NotImplementedException();
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Evict(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public void Evict(Type persistentClass, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictQueries()
        {
            throw new NotImplementedException();
        }

        public void EvictQueries(string cacheRegion)
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession()
        {
            throw new NotImplementedException();
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            throw new NotImplementedException();
        }

        public ISession GetCurrentSession()
        {
            throw new NotImplementedException();
        }

        public IStatistics Statistics { get; private set; }

        public bool IsClosed { get; private set; }

        public ICollection<string> DefinedFilterNames { get; private set; }

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeSession : ISession
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public EntityMode ActiveEntityMode { get; private set; }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public FlushMode FlushMode { get; set; }

        public CacheMode CacheMode { get; set; }

        public ISessionFactory SessionFactory { get; private set; }

        public IDbConnection Connection { get; private set; }

        public IDbConnection Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Reconnect()
        {
            throw new NotImplementedException();
        }

        public void Reconnect(IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public IDbConnection Close()
        {
            throw new NotImplementedException();
        }

        public void CancelQuery()
        {
            throw new NotImplementedException();
        }

        public bool IsOpen { get; private set; }

        public bool IsConnected { get; private set; }

        public bool IsDirty()
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly(object entityOrProxy)
        {
            throw new NotImplementedException();
        }

        public void SetReadOnly(object entityOrProxy, bool readOnly)
        {
            throw new NotImplementedException();
        }

        public bool DefaultReadOnly { get; set; }

        public object GetIdentifier(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object obj)
        {
            throw new NotImplementedException();
        }

        public void Evict(object obj)
        {
            throw new NotImplementedException();
        }

        public object Load(Type theType, object id, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public object Load(string entityName, object id, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public object Load(Type theType, object id)
        {
            throw new NotImplementedException();
        }

        public T Load<T>(object id, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public T Load<T>(object id)
        {
            throw new NotImplementedException();
        }

        public object Load(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public void Load(object obj, object id)
        {
            throw new NotImplementedException();
        }

        public void Replicate(object obj, ReplicationMode replicationMode)
        {
            throw new NotImplementedException();
        }

        public void Replicate(string entityName, object obj, ReplicationMode replicationMode)
        {
            throw new NotImplementedException();
        }

        public object Save(object obj)
        {
            throw new NotImplementedException();
        }

        public void Save(object obj, object id)
        {
            throw new NotImplementedException();
        }

        public object Save(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public void Save(string entityName, object obj, object id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(string entityName, object obj, object id)
        {
            throw new NotImplementedException();
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }

        public void Update(object obj, object id)
        {
            throw new NotImplementedException();
        }

        public void Update(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public void Update(string entityName, object obj, object id)
        {
            throw new NotImplementedException();
        }

        public object Merge(object obj)
        {
            throw new NotImplementedException();
        }

        public object Merge(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public T Merge<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T Merge<T>(string entityName, T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Persist(object obj)
        {
            throw new NotImplementedException();
        }

        public void Persist(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entityName, object obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(string query)
        {
            throw new NotImplementedException();
        }

        public int Delete(string query, object value, IType type)
        {
            throw new NotImplementedException();
        }

        public int Delete(string query, object[] values, IType[] types)
        {
            throw new NotImplementedException();
        }

        public void Lock(object obj, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public void Lock(string entityName, object obj, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public void Refresh(object obj)
        {
            throw new NotImplementedException();
        }

        public void Refresh(object obj, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public LockMode GetCurrentLockMode(object obj)
        {
            throw new NotImplementedException();
        }

        public ITransaction BeginTransaction()
        {
            return new FakeTransaction();
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new FakeTransaction();
        }

        public ITransaction Transaction { get; private set; }

        public ICriteria CreateCriteria<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria<T>(string alias) where T : class
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(Type persistentClass, string alias)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string entityName)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string entityName, string alias)
        {
            throw new NotImplementedException();
        }

        public IQueryOver<T, T> QueryOver<T>() where T : class
        {
            return new FakeQueryOver<T, T>();
        }

        public IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryOver<T, T> QueryOver<T>(string entityName) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryOver<T, T> QueryOver<T>(string entityName, Expression<Func<T>> alias) where T : class
        {
            throw new NotImplementedException();
        }

        public IQuery CreateQuery(string queryString)
        {
            throw new NotImplementedException();
        }

        public IQuery CreateFilter(object collection, string queryString)
        {
            throw new NotImplementedException();
        }

        public IQuery GetNamedQuery(string queryName)
        {
            throw new NotImplementedException();
        }

        public ISQLQuery CreateSQLQuery(string queryString)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public object Get(Type clazz, object id)
        {
            throw new NotImplementedException();
        }

        public object Get(Type clazz, object id, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public object Get(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object id, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public string GetEntityName(object obj)
        {
            throw new NotImplementedException();
        }

        public IFilter EnableFilter(string filterName)
        {
            throw new NotImplementedException();
        }

        public IFilter GetEnabledFilter(string filterName)
        {
            throw new NotImplementedException();
        }

        public void DisableFilter(string filterName)
        {
            throw new NotImplementedException();
        }

        public IMultiQuery CreateMultiQuery()
        {
            throw new NotImplementedException();
        }

        public ISession SetBatchSize(int batchSize)
        {
            throw new NotImplementedException();
        }

        public ISessionImplementor GetSessionImplementation()
        {
            throw new NotImplementedException();
        }

        public IMultiCriteria CreateMultiCriteria()
        {
            throw new NotImplementedException();
        }

        public ISessionStatistics Statistics { get; private set; }

        public ISession GetSession(EntityMode entityMode)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeTransaction : ITransaction
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Begin(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public bool IsActive { get; private set; }

        public bool WasRolledBack { get; private set; }

        public bool WasCommitted { get; private set; }

        public void Enlist(IDbCommand command)
        {
            throw new NotImplementedException();
        }

        public void RegisterSynchronization(ISynchronization synchronization)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeQueryOver<T1, T2> : QueryOver<T1, T2>
    {
        public FakeQueryOver()
            : base(new CriteriaImpl(typeof(T1), null) { Session = MockRepository.GenerateStub<ISessionImplementor>() })
        {
        }
    }
}
