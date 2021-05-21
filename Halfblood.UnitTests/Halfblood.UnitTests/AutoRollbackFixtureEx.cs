namespace Halfblood.UnitTests
{
    using Halfblood.UnitTests.CrudTest;

    using UnitTestHelpers.CrudHelpers;

    public abstract class AutoRollbackFixtureEx : AutoRollbackFixture
    {
        static AutoRollbackFixtureEx()
        {
            InitializerTestData = new Initializer();
        }
    }
}
