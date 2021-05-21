// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactory.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The service factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Buisness.Components;
    using Buisness.InternalEntity.Strategies;
    using Buisness.InternalService;

    using Halfblood.Common;

    using Buisness.Components.Strategies.CommonDomain;

    using NHibernate;
    using NHibernate.Helper.Filter;

    /// <summary>
    /// The service factory.
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        private static readonly IDictionary<Type, Type> _storage;

        static ServiceFactory()
        {
            _storage =
                ReflectExtension.GetTypesMarkedAttribute<RegisterAttribute>(
                    Assembly.GetAssembly(typeof(ServiceFactory)),
                    Assembly.GetAssembly(typeof(PolicyService)));

            FilterStrategyFactory.Assemblies = new[]
            {
                Assembly.GetAssembly(typeof(AgnlistFilteringStrategy)),
                Assembly.GetAssembly(typeof(AcatalogFilterStrategy))
            };
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        /// <typeparam name="T">
        /// The type of service.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Create<T>(ISession session)
        {
            System.Diagnostics.Contracts.Contract.Requires(session != null, "The session must be is not null");

            return
                (T)
                Activator.CreateInstance(
                    _storage[typeof(T)],
                    new RepositoryFactory(session),
                    new FilterStrategyFactory());
        }
    }
}