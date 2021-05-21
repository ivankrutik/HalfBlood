// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultSetDataTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DefaultSetDataTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.DefaultSetDataTests
{
    using System.Threading.Tasks;

    using Halfblood.Common.Helpers;

    using NUnit.Framework;

    /// <summary>
    /// The default set data test.
    /// </summary>
    public class DefaultSetDataTest
    {
        [Test]
        public void Test()
        {
            var testClass = new TestClass();
            IInitializationStrategy strategy = new InitStrategy();
            var initializationManager = new InitializationManager();
            initializationManager.AddStrategy<TestClass>(strategy);

            var task = initializationManager.InitViewModel(testClass);
            task.Wait();

            Assert.That(testClass.TestOne, Is.EqualTo(777));
            Assert.That(testClass.TestTwo, Is.EqualTo("777"));
            Assert.That(testClass.TestThree, Is.Not.Null);
        }
    }

    class InitStrategy : IInitializationStrategy<TestClass>
    {
        public Task InitViewModel(TestClass viewModel)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        viewModel.TestOne = 777;
                        viewModel.TestTwo = "777";
                        viewModel.TestThree = new TestClass();
                    });
        }

        public Task InitViewModel(object viewModel)
        {
            return this.InitViewModel((TestClass)viewModel);
        }
    }

    internal class TestClass
    {
        public int TestOne { get; set; }
        public string TestTwo { get; set; }
        public TestClass TestThree { get; set; }
    }
}
