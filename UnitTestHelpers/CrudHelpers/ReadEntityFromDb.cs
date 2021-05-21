// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadEntityFromDb.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The read entity from DB.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTestHelpers.CrudHelpers
{
    using System;
    using System.Collections.Generic;

    using Halfblood.Common.Helpers;

    using NUnit.Framework;

    /// <summary>
    /// The read entity from DB.
    /// </summary>
    public abstract class ReadEntityFromDb : FixtureBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEntityFromDb"/> class.
        /// </summary>
        protected ReadEntityFromDb()
        {
            Connecting();
        }

        /// <summary>
        /// The certificate quality rest lite DTO.
        /// </summary>
        [Test, TestCaseSource("GetAllDtos")]
        public void CertificateQualityRestLiteDto(Type type)
        {
            Console.WriteLine("Try get the entity: {0}".StringFormat(type.Name));
            CreateSession().CreateCriteria(type).SetMaxResults(1).List();
        }

        public abstract IEnumerable<Type> GetAllDtos();
    }
}
