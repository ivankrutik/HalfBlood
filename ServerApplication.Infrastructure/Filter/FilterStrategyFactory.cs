// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterStrategyFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FilterStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NHibernate.Helper.Filter
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Halfblood.Common;

    /// <summary>
    /// The filter strategy factory.
    /// </summary>
    public class FilterStrategyFactory : IFilterStrategyFactory
    {
        private static IDictionary<Type, Type> _storage;

        /// <summary>
        /// Sets the assemblies.
        /// </summary>
        public static Assembly[] Assemblies
        {
            set
            {
                _storage = ReflectExtension.GetTypesMarkedAttribute<FilterForEntityAttribute>(value);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <typeparam name="TEntity">
        /// The type of entity.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFilteringStrategy"/>.
        /// </returns>
        public IFilteringStrategy<TEntity> Create<TEntity>()
            where TEntity : IHasUid
        {
            if (_storage == null || _storage.ContainsKey(typeof(TEntity)))
            {
                return (IFilteringStrategy<TEntity>)Activator.CreateInstance(_storage[typeof(TEntity)]);
            }

            return new DefaultFilteringStrategy<TEntity>();
        }
    }
}