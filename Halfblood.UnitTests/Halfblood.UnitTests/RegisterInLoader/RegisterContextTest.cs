// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterContextTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The register test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.RegisterInLoader
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Halfblood.Common;
    using Halfblood.UnitTests.ServiceFactoryTest.Pears;

    using NUnit.Framework;

    /// <summary>
    /// The register test.
    /// </summary>
    [TestFixture]
    public class RegisterContextTest
    {
        [Test]
        public void RegisterAndResolve()
        {
            var dictionary = new Dictionary<Type, RegisterAttribute>();

            ReflectExtension.GetTypesMarkedAttribute<RegisterAttribute>(Assembly.Load("Halfblood.UnitTests"), dictionary.Add);

            Assert.That(dictionary.Count, Is.EqualTo(2));
            Assert.That(dictionary[typeof(Test_1)], Is.InstanceOf<RegisterAttribute>());
            Assert.That(dictionary[typeof(Test_1)].RegisterAsType, Is.EqualTo(typeof(ITest_1)));

            Assert.That(dictionary[typeof(Test_2)], Is.InstanceOf<RegisterAttribute>());
            Assert.That(dictionary[typeof(Test_2)].RegisterAsType, Is.EqualTo(typeof(ITest_2)));
        }
    }
}