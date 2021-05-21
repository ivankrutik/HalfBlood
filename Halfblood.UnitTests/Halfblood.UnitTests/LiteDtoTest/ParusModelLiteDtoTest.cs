// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParusModelLiteDtoTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The parus model lite DTO test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.LiteDtoTest
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using ParusModel.Policy;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using UnitTestHelpers.CrudHelpers;

    /// <summary>
    /// The parus model lite DTO test.
    /// </summary>
    public class ParusModelLiteDtoTest : ReadEntityFromDb
    {
        /// <summary>
        /// The get all dtos.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<Type> GetAllDtos()
        {
            return Assembly.GetAssembly(typeof(CertificateQualityRestLiteDto)).GetTypes();
        }
    }

    public class ParusModelPolicyTest : ReadEntityFromDb
    {
        public override IEnumerable<Type> GetAllDtos()
        {
            return Assembly.GetAssembly(typeof(UserList)).GetTypes();
        }
    }
}
