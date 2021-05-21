// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagerTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MessagerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.CommonDomain
{
    using NUnit.Framework;

    using UI.ProcessComponents;

    /// <summary>
    /// The Messenger test.
    /// </summary>
    [TestFixture]
    public class MessagerTest
    {
        private Messenger messenger;

        [SetUp]
        public void SetUp()
        {
            this.messenger = new Messenger();
        }

        /// <summary>
        /// The create.
        /// </summary>
        [Test]
        public void Create()
        {
            Assert.That(this.messenger, Is.Not.Null);
        }
    }
}
