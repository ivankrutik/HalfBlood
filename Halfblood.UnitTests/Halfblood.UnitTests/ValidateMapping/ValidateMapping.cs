// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidateMapping.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ValidateMapping type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.ValidateMapping
{
    using System;
    using System.Linq;
    using System.Reflection;

    using DataAccessLogic.Infrastructure;

    using NUnit.Framework;

    /// <summary>
    /// The validate mapping.
    /// </summary>
    public class ValidateMapping : AutoRollbackFixtureEx
    {
        [Test]
        public void TestNameSectionOfSystem()
        {
            var asm = Assembly.Load("ParusModel");
            var clazz = asm.GetExportedTypes().Where(x => x.GetInterface("IEntity") != null);

            var count = 0;

            foreach (var elem in clazz)
            {
                var cl = (IEntity)Activator.CreateInstance(elem);
                var query = Session.QueryOver<SectionOfSystem>().Where(x => x.Rn == cl.NameSectionOfSystem);
                if (query.RowCount() == 1)
                {
                    count++;
                }
            }
            Assert.That(clazz.Count(), Is.EqualTo(count));
        }
    }
}
