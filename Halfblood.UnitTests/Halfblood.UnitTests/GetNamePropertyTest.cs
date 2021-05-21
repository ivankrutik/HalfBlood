namespace Halfblood.UnitTests
{
    using Halfblood.Common;

    using NUnit.Framework;

    using UI.Entities.CommonDomain;

    public class GetNamePropertyTest
    {
        [Test]
        public void GetNameProperty()
        {
            string name = HelperExtensions.GetName<User>(x => x.Firstname);
            Assert.That(name, Is.EqualTo("Firstname"));
        }
    }
}
