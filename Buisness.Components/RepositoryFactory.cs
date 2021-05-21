// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the RepositoryFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Halfblood.Common;

    using NHibernate;
    using NHibernate.Helper;
    using NHibernate.Helper.Repository;

    public class RepositoryFactory : IRepositoryFactory
    {
        private static readonly IDictionary<Type, Type> _storage;
        private readonly ISession _session;

        static RepositoryFactory()
        {
            _storage =
                ReflectExtension.GetTypesMarkedAttribute<RepositoryForEntityAttribute>(
                    Assembly.GetAssembly(typeof(PlanCertificateRepository)));
        }

        public RepositoryFactory(ISession session)
        {
            System.Diagnostics.Contracts.Contract.Requires(session != null, "The session must be is not null");
            System.Diagnostics.Contracts.Contract.Requires(session.IsOpen, "The session must be is opened");

            _session = session;
        }

        public INhRepository<TEntity> Create<TEntity>()
            where TEntity : class, IHasUid
        {
            if (_storage.ContainsKey(typeof(TEntity)))
            {
                return (INhRepository<TEntity>)
                    Activator.CreateInstance(_storage[typeof(TEntity)], _session);
            }

            return new NhRepository<TEntity>(_session);
        }
    }
}