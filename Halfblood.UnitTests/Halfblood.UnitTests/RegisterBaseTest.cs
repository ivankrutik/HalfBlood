// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterBaseTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the RegisterBaseTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Halfblood.Common;

    using NUnit.Framework;

    public class RegisterBaseTest
    {
        [Test]
        public void Test()
        {
            IDictionary<Type, Type> storage =
                ReflectExtension.GetTypesMarkedAttribute<TesticAttribute>(Assembly.GetAssembly(this.GetType()));

            Assert.That(storage, Is.Not.Null);
            Assert.That(storage.Count, Is.EqualTo(2));
            Assert.That(storage[typeof(MyClass1)] == typeof(MyClass2));
            Assert.That(storage[typeof(MyClass2)] == typeof(MyClass1));
        }


        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
        internal sealed class TesticAttribute : Attribute, IRegisterAttribute
        {
            public TesticAttribute(Type type)
            {
                RegisterAsType = type;
            }

            public Type RegisterAsType { get; set; }
        }

        [TesticAttribute(typeof(MyClass2))]
        internal class MyClass1{}
        [TesticAttribute(typeof(MyClass1))]
        internal class MyClass2 { }
    }
}
