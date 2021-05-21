// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoaderTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the LoaderTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.LoaderTests
{
    using System;

    using NUnit.Framework;

    using UI.ProcessComponents;

    public class LoaderTest : TestBase
    {
        [Test]
        public void RunTest()
        {
            string test = null;

            var runner = AsyncRunner<string>.Create(() => test = "HELLO WORLD!");
            runner.IsExecuting.Subscribe(isExecuting => { });
            runner.Load();
            runner.GetInvokedTask().Wait();

            Assert.That(test == "HELLO WORLD!");
        }

        [Test]
        public void RunTest2()
        {
            var runner = new AsyncRunner<string>();
            runner.RegisterFunction(() => "HELLO WORLD!");

            bool isSuccessfull = runner.Wait();

            Assert.That(isSuccessfull);
            Assert.That(runner.Result, Is.EqualTo("HELLO WORLD!"));
        }

        [Test]
        public void ThrowException()
        {
            byte countHandledException = 0;
            var runner = new AsyncRunner<string>();
            runner.ThrownExceptions.Subscribe(exc =>
            {
                countHandledException++;
                Assert.That(exc, Is.InstanceOf<Exception>());
                Assert.That(exc.Message, Is.EqualTo("SASAI LALKA!"));

                throw exc;
            });
            runner.RegisterFunction(() =>
            {
                throw new Exception("SASAI LALKA!");
            });

            if (runner.Wait())
            {
                Assert.Fail();
            }

            if (runner.Wait())
            {
                Assert.Fail();
            }

            if (runner.Wait())
            {
                Assert.Fail();
            }

            if (countHandledException != 3)
            {
                Assert.Fail("Должно быть обработано 3 исключения, а обработано: " + countHandledException);
            }
        }

        [Test]
        public void LoadNotificationComplete()
        {
            bool loadNotificationComplete = false;

            var runner = new AsyncRunner<string>();
            runner.RegisterFunction(() => "HELLO WORLD!");
            runner.LoadCompletedNotification.Subscribe(
                res =>
                {
                    loadNotificationComplete = true;
                    Assert.That(res, Is.EqualTo("HELLO WORLD!"));
                });

            runner.Wait();

            Assert.That(loadNotificationComplete == true);
        }
    }
}