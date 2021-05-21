// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Relations.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the Relations type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Mappers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The relations.
    /// </summary>
    public class Relations
    {
#if !RELEASE
        public IDictionary<Type, Type> Dictionary
        {
            get { return _dictionary; }
        }
#endif
        private readonly Dictionary<Type, Type> _dictionary;

        public Relations()
        {
            _dictionary = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// The relation.
        /// </summary>
        /// <typeparam name="T1">
        /// Type type of DTO.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The type of entity.
        /// </typeparam>
        public void Relation<T1, T2>()
        {
            Relation(typeof(T1), typeof(T2));
        }

        /// <summary>
        /// The relation.
        /// </summary>
        /// <param name="t1">
        /// Type type of DTO.
        /// </param>
        /// <param name="t2">
        /// The type of entity.
        /// </param>
        public void Relation(Type t1, Type t2)
        {
            AddToDictionary(t1, t2);
            AddToDictionary(t2, t1);
        }

        /// <summary>
        /// The get relation.
        /// </summary>
        /// <typeparam name="T">
        /// The type of entity.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public Type GetRelation<T>()
        {
            return GetRelation(typeof(T));
        }

        /// <summary>
        /// The get relation.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public Type GetRelation(Type type)
        {
            return _dictionary[type];
        }

        /// <summary>
        /// The try get relation.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public Type TryGetRelation(Type type)
        {
            return _dictionary.ContainsKey(type) ? _dictionary[type] : null;
        }

        private void AddToDictionary(Type t1, Type t2)
        {
            if (!_dictionary.ContainsKey(t1))
            {
                _dictionary.Add(t1, t2);
            }
        }
    }
}
