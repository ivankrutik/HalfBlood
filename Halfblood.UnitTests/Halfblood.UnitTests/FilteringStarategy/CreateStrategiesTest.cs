// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateStrategiesTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CreateStrategiesTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Halfblood.UnitTests.FilteringStarategy
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Components.Strategies.CommonDomain;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate.Helper.Filter;

    using NUnit.Framework;

    public class CreateStrategiesTest
    {
        [Test, TestCaseSource("GetAFilteringStrategies")]
        public void CreateStrategyFromAssembly(Type entityType, Type strategyType)
        {
            FilterStrategyFactory.Assemblies = new[] { Assembly.GetAssembly(typeof(AgnlistFilteringStrategy)) };
            var factory = new FilterStrategyFactory();

            MethodInfo method =
                typeof(FilterStrategyFactory).GetMethod("Create").MakeGenericMethod(entityType);

            if (method == null)
            {
                throw new Exception("Отсутствут метод \"Create\", у фабрики стратегий");
            }

            Console.WriteLine("Try create strategy for entity - {0}".StringFormat(entityType));

            var filteringStrategy = method.Invoke(factory, null);
            Assert.That(filteringStrategy, Is.Not.Null);
            Assert.That(filteringStrategy, Is.InstanceOf(strategyType));
        }

        private IEnumerable<object[]> GetAFilteringStrategies()
        {
            var list = new List<object[]>();

            ReflectExtension.GetTypesMarkedAttribute<FilterForEntityAttribute>(
                Assembly.GetAssembly(typeof(CertificateQualityFilterStrategy)),
                (type, attribute) => list.Add(new object[] { attribute.RegisterAsType, type }));

            return list;
        }
    }
}
