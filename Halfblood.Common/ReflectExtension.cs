// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ReflectExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;

    /// <summary>
    /// The register context.
    /// </summary>
    public static class ReflectExtension
    {
        /// <summary>
        /// The get type mark register attribute.
        /// </summary>
        /// <param name="assembly">
        /// The get calling assembly.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="TAttribute">
        /// The type of attribute.
        /// </typeparam>
        public static void GetTypesMarkedAttribute<TAttribute>(Assembly assembly, Action<Type, TAttribute> action, Action complete = null)
            where TAttribute : Attribute
        {
            GetTypesMarkedAttribute(new[] { assembly }, action, complete);
        }

        /// <summary>
        /// The get type mark register attribute.
        /// </summary>
        /// <param name="getCallingAssemblies">
        /// The get calling assemblies.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="complete">
        /// The complete.
        /// </param>
        /// <typeparam name="TAttribute">
        /// The type of attribute.
        /// </typeparam>
        public static void GetTypesMarkedAttribute<TAttribute>(this Assembly[] getCallingAssemblies, Action<Type, TAttribute> action, Action complete = null)
            where TAttribute : Attribute
        {
            if (getCallingAssemblies == null)
            {
                throw new ArgumentNullException("getCallingAssemblies");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            foreach (Type type in getCallingAssemblies.SelectMany(x => x.GetTypes()))
            {
                var attributes = type.GetCustomAttributes(typeof(TAttribute), false);
                if (attributes.Any())
                {
                    var registerAttribute = (TAttribute)attributes[0];
                    action(type, registerAttribute);
                }
            }

            if (complete != null)
            {
                complete();
            }
        }

        /// <summary>
        /// Find properties mark attribute.
        /// </summary>
        /// <typeparam name="TAttribute">
        /// Attribute.
        /// </typeparam>
        /// <param name="object">
        /// Explore object.
        /// </param>
        /// <param name="action">
        /// (attribute, value of property mark the attribute) => { }.
        /// </param>
        public static void GetPropertiesMarkAttribute<TAttribute>(this object @object, Action<TAttribute, object> action)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            PropertyInfo[] pInfos = @object.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in pInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).Where(x => x.GetType() == typeof(TAttribute));

                if (attributes.Any())
                {
                    var attribute =
                        (TAttribute)
                        propertyInfo.GetCustomAttributes(typeof(TAttribute), false).First();
                    action(attribute, propertyInfo.GetValue(@object, null));
                }
            }
        }

        public static void GetPropertiesMarkAttribute<TAttribute>(this object @object, Action<TAttribute, PropertyInfo> action)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            PropertyInfo[] pInfos = @object.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in pInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true).Where(x => x.GetType() == typeof(TAttribute));

                if (attributes.Any())
                {
                    var attribute =
                        (TAttribute)
                        propertyInfo.GetCustomAttributes(typeof(TAttribute), false).First();
                    action(attribute, propertyInfo);
                }
            }
        }

        /// <summary>
        /// The invoke generic method.
        /// </summary>
        /// <param name="genericType">
        /// The type for the generic method.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="evokedObject">
        /// The evoked object object.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="TRet">
        /// The return type;
        /// </typeparam>
        /// <returns>
        /// The <see cref="TRet"/>.
        /// </returns>
        public static TRet InvokeGenericMethod<TRet>(
            this object evokedObject,
            Type genericType,
            string method,
            object[] parameters = null)
        {
            object returnType =
                evokedObject.GetType()
                    .GetMethod(method)
                    .MakeGenericMethod(genericType)
                    .Invoke(evokedObject, parameters);

            return (TRet)returnType;
        }

        /// <summary>
        /// The has attribute.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <typeparam name="TAttribute">
        /// The type of attribute.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this Type type)
        {
            return type.GetCustomAttributes(typeof(TAttribute), false).Any();
        }

        /// <summary>
        /// The has attribute.
        /// </summary>
        /// <param name="object">
        /// The object.
        /// </param>
        /// <typeparam name="TAttribute">
        /// The type of attribute.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this object @object)
        {
            return HasAttribute<TAttribute>(@object.GetType());
        }

        /// <summary>
        /// The has interface.
        /// </summary>
        /// <param name="object">
        /// The object.
        /// </param>
        /// <typeparam name="TInterface">
        /// The type of interface.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool HasInterface<TInterface>(this object @object)
        {
            return HasInterface<TInterface>(@object.GetType());
        }

        /// <summary>
        /// The has interface.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <typeparam name="TInterface">
        /// The type of interface;
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool HasInterface<TInterface>(this Type type)
        {
            return type.GetInterface(typeof(TInterface).Name) != null;
        }

        /// <summary>
        /// The create generic collection.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="typeOfGenericList">
        /// The type of generic list.
        /// </param>
        /// <param name="ctorParameter">
        /// The parameter of constructor.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object CreateGenericCollection(this IList collection, Type typeOfGenericList, object ctorParameter = null)
        {
            Type itemType = collection.GetType().GetProperty("Item").PropertyType;
            Type observableCollectionType = typeOfGenericList.MakeGenericType(itemType);
            return Activator.CreateInstance(observableCollectionType, ctorParameter);
        }

        /// <summary>
        /// The get types marked attribute.
        /// </summary>
        /// <param name="assemblies">
        /// The assemblies.
        /// </param>
        /// <typeparam name="TAttribute">
        /// The type of attribute.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public static IDictionary<Type, Type> GetTypesMarkedAttribute<TAttribute>(params Assembly[] assemblies)
            where TAttribute : Attribute, IRegisterAttribute
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            IDictionary<Type, Type> storage = new ConcurrentDictionary<Type, Type>();

            ReflectExtension.GetTypesMarkedAttribute<TAttribute>(
                assemblies,
                (type, attribute) =>
                {
                    if (storage.ContainsKey(attribute.RegisterAsType))
                    {
                        LogManager.Log.Debug("(RegisterBase) {0} already added".StringFormat(attribute.RegisterAsType));
                        return;
                    }

                    storage.Add(attribute.RegisterAsType, type);
                });

            return storage;
        }
    }
}