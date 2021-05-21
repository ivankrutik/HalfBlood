// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   AutoMapperExtension.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Mappers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    /// <summary>
    /// The auto mapper extension.
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// The ignore all non existing.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <typeparam name="TSource">
        /// the type of source object
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// the type of destination object
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> expression)
        {
            const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(Flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, Flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }

            return expression;
        }

        /// <summary>
        /// The to DTO.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <typeparam name="TDestination">
        /// the destination type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IList<TDestination> MapTo<TDestination>(this IEnumerable source)
        {
            return (from object item in source select Mapper.Map<TDestination>(item)).ToList();
        }

        /// <summary>
        /// The map to.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <typeparam name="TDestination">
        /// the type of destination
        /// </typeparam>
        /// <returns>
        /// The <see cref="TDestination"/>.
        /// </returns>
        public static TDestination MapTo<TDestination>(this object obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

        /// <summary>
        /// The map to.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="destination">
        /// The destination.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object MapTo(this object obj, Type destination)
        {
            return Mapper.Map(obj, obj.GetType(), destination);
        }

        /// <summary>
        /// The map to.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <typeparam name="TDto">
        /// The type of DTO.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public static IList<TDto> MapTo<TDto>(this IList obj, Action<TDto, object[]> action, int index = 0)
        {
            var result = new List<TDto>();

            foreach (object item in obj)
            {
                if (item is object[])
                {
                    var dto = ((object[])item)[index].MapTo<TDto>();
                    action(dto, ((object[])item));

                    result.Add(dto);
                }
                else
                {
                    result.Add(item.MapTo<TDto>());
                }
            }

            return result;
        }
    }
}