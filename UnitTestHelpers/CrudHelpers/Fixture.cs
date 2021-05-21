// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fixture.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Fixture type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTestHelpers.CrudHelpers
{
    using System;

    /// <summary>
    /// The fixture.
    /// </summary>
    public abstract class Fixture : FixtureBase, IDisposable
    {
        public static IInitializerTestData InitializerTestData { get; set; }

        /// <summary>
        /// Finalizes an instance of the <see cref="Fixture"/> class. 
        /// </summary>
        ~Fixture()
        {
            this.Dispose();
        }

        /// <summary>
        /// Initializes static members of the <see cref="Fixture"/> class.
        /// </summary>
        static Fixture()
        {

            Connecting();
            using (
                var session = CreateSession())
            using (var transaction = session.BeginTransaction())
            {
                if (InitializerTestData != null)
                {
                    InitializerTestData.Create(session);
                }

                transaction.Commit();
            }


        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {

        }
    }
}
