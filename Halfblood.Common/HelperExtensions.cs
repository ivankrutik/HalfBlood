// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelperExtensions.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the HelperExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Halfblood.Common.Log;

    /// <summary>
    /// The helper extensions.
    /// </summary>
    public static class HelperExtensions
    {
        /// <summary>
        /// The get name.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <typeparam name="T">
        /// The type of object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetName<T>(Expression<Func<T, object>> property)
        {
            return ((MemberExpression)property.Body).Member.Name;
        }
        public static string GetName<T>(this T target, Expression<Func<T, object>> property)
        {
            return GetName(property);
        }

        /// <summary>
        /// The get relation ui entity to dto entity attribute.
        /// </summary>
        /// <param name="entityType">
        /// The entity type.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static Type GetRelationUiEntityToDtoEntityAttribute(this Type entityType)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException("TEntity is null. Use the method 'LoadForEntity<TEntity>'");
            }

            var attributes = entityType.GetCustomAttributes(typeof(RelationUiEntityToDtoEntityAttribute), false);
            if (attributes.Any())
            {
                return ((RelationUiEntityToDtoEntityAttribute)attributes[0]).TypeOfDto;
            }

            LogManager.Log.Debug(
                string.Format(
                    "not found the attribute '{0}' for the entity '{1}'",
                    typeof(RelationUiEntityToDtoEntityAttribute),
                    entityType));

            return null;
        }

        /// <summary>
        /// Convert exception to message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static string ToMessage(this Exception exception)
        {
            if (exception == null)
            {
                return string.Empty;
            }

            var message = exception.Message + ToMessage(exception.InnerException);
            return message;
        }
        
        /// <summary>
        /// Get the exception of concrete type from hierarchy of exceptions.
        /// </summary>
        /// <typeparam name="TException">
        /// The type of exception.
        /// </typeparam>
        /// <param name="exception"></param>
        /// <returns>
        /// The instance exception finded from hierarchy of exceptions.
        /// </returns>
        public static Exception GetExceptionFromHierarchy<TException>(this Exception exception)
            where TException : Exception
        {
            if (exception == null)
            {
                return null;
            }

            if (exception is TException)
            {
                return exception;
            }

            return GetExceptionFromHierarchy<TException>(exception.InnerException);
        }
    }
}