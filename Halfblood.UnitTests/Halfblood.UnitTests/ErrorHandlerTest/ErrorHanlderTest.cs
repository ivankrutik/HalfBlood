// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorHanlderTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The error hanlder test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.ErrorHandlerTest
{
    using System;

    using Halfblood.Common.Exceptions;
    using Halfblood.ErrorHandler;

    using NUnit.Framework;

    /// <summary>
    /// The error hanlder test.
    /// </summary>
    [TestFixture]
    public class ErrorHanlderTest
    {
        [Test]
        public void Create()
        {
            var errorHandler = new ErrorHandlerContext();
            Assert.That(errorHandler, Is.Not.Null);
        }

        [Test]
        public void Handling()
        {
            var errorHandler = new ErrorHandlerContext();
            var handler = new FakeExceptionHandler();
            errorHandler.AddHandler(handler);

            errorHandler.Handling(new TestException());

            Assert.That(handler.Exception, Is.InstanceOf<TestException>());
        }
    }

    public class FakeExceptionHandler : IExceptionHandler
    {
        public Exception Exception { get; set; }

        public bool Handling(Exception exception)
        {
            Exception = exception;
            return true;
        }
    }
    public class TestException : Exception
    {
    }
}