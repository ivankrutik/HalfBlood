namespace UnitTestHelpers.CrudHelpers
{
    using NHibernate;

    using NUnit.Framework;

    public abstract class AutoRollbackFixture : Fixture
    {
        protected ISession Session { get; private set; }
        protected ITransaction Transaction { get; private set; }

        [SetUp]
        public void SetUp()
        {
            this.BeforeSetUp();
            this.Session = SessionFactory.OpenSession();
            this.Transaction = this.Session.BeginTransaction();
            this.AfterSetUp();
        }

        protected virtual void BeforeSetUp() { }
        protected virtual void AfterSetUp() { }

        [TearDown]
        public void TearDown()
        {
            this.BeforeTearDown();
            if (this.Transaction != null) this.Transaction.Rollback();
            if (this.Session != null) this.Session.Dispose();
            this.AfterTearDown();
        }

        protected virtual void BeforeTearDown() { }
        protected virtual void AfterTearDown() { }

        /// <summary>
        /// Flushes all pending changes to the database.
        /// </summary>
        protected void Flush()
        {
            this.Session.Flush();
        }

        /// <summary>
        /// Removes all attached instances from the session, and also cancels all pending changes that haven't been flushed yet
        /// </summary>
        protected void Clear()
        {
            this.Session.Clear();
        }

        /// <summary>
        /// Flushes all pending changes to the database, and clears the session so no entities remain in the session cache.
        /// All entities that were attached to the session prior to calling this method will become detached instances
        /// </summary>
        protected void FlushAndClear()
        {
            this.Session.Flush();
            this.Session.Clear();
        }
    }
}
