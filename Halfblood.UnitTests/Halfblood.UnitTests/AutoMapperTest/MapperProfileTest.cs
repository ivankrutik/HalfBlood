// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperProfileTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The mapper profile test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.AutoMapperTest
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using AutoMapper;

    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NUnit.Framework;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The mapper profile test.
    /// </summary>
    [TestFixture]
    public class MapperProfileTest
    {
        [Test]
        public void Test()
        {
            var cq = new CertificateQuality(100);
            cq.Documents.Add(new AttachedDocument(102));
            cq.Documents[0].Parent = cq;

            var d = new AttachedDocumentType(100).MapTo<AttachedDocumentTypeDto>();
            var attachDto = cq.Documents[0].MapTo<AttachedDocumentDto>();

            var dto = cq.MapTo<CertificateQualityDto>();
        }

        [Test, TestCaseSource("GetAllAutoMapperProfile")]
        public void CreateBuisnessWorkflowsProfiles(Type profileType)
        {
            var profile = Activator.CreateInstance(profileType);

            Assert.That(profile, Is.Not.Null);
            Assert.That(profile, Is.InstanceOf<Profile>());
        }

        private IEnumerable<Type> GetAllAutoMapperProfile()
        {
            var profiles = new List<Type>();

            ReflectExtension.GetTypesMarkedAttribute<AutoMapperProfileAttribute>(
                Assembly.GetAssembly(typeof(Buisness.Workflows.ConfigureWorkflow)),
                (type, attribute) => profiles.Add(type));

            return profiles;
        }
    }
}
