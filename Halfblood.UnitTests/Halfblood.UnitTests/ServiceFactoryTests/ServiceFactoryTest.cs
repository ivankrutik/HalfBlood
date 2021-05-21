// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactoryTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ServiceFactoryTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.ServiceFactoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Workflows;
    using Buisness.Workflows.Services;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate;
    using NUnit.Framework;
    using Rhino.Mocks;

    public class ServiceFactoryTest
    {
        [Test, TestCaseSource("GetService")]
        public void CreateServices(Type valueType, Type keyType)
        {
            Console.Write("Try create service : {0}".StringFormat(valueType));

            var session = MockRepository.GenerateMock<ISession>();
            session.Stub(x => x.IsOpen).Return(true);
            var serviceFactory = new ServiceFactory();
            var service =
                typeof(ServiceFactory).GetMethod("Create")
                                      .MakeGenericMethod(valueType)
                                      .Invoke(serviceFactory, new[] { session });

            Assert.That(service, Is.Not.Null);
            Assert.That(service, Is.InstanceOf(keyType));

            Console.Write(" --> created {0}\n".StringFormat(keyType));
        }

        private IEnumerable<object[]> GetService()
        {
            var dictionary = new Dictionary<Type, Type>();

            ReflectExtension.GetTypesMarkedAttribute<RegisterAttribute>(
                typeof(CommonService).Assembly,
                (type, attribute) => dictionary.Add(type, attribute.RegisterAsType));

            return dictionary.Select(keyValuePair => new object[] { keyValuePair.Value, keyValuePair.Key });
        }
    }
}