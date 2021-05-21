// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The certificate quality test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.UIEntities
{
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using Halfblood.Common.Mappers;

    using NUnit.Framework;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The certificate quality test.
    /// </summary>
    public class CertificateQualityTest : TestBase
    {
        [Test]
        public void WithoutMapedCheckSetParent()
        {
            var certificateQuality = new CertificateQuality(100);
            this.CheckSetParent(certificateQuality);
        }

        [Test]
        public void WithMapedCheckSetParent()
        {
            var certificateQuality = new CertificateQualityDto().MapTo<CertificateQuality>();
            this.CheckSetParent(certificateQuality);
        }

        private void CheckSetParent(CertificateQuality certificateQuality)
        {
            Assert.That(certificateQuality.ChemicalIndicatorValues, Is.Not.Null);
            Assert.That(certificateQuality.Documents, Is.Not.Null);
            Assert.That(certificateQuality.Destinations, Is.Not.Null);
            Assert.That(certificateQuality.Passes, Is.Not.Null);
            Assert.That(certificateQuality.MechanicIndicatorValues, Is.Not.Null);

            certificateQuality.Documents.Add(new AttachedDocument(100));
            Assert.That(certificateQuality.Documents.Count, Is.EqualTo(1));
            Assert.That(certificateQuality.Documents[0].Parent, Is.EqualTo(certificateQuality));

            certificateQuality.ChemicalIndicatorValues.Add(new ChemicalIndicatorValue());
            Assert.That(certificateQuality.ChemicalIndicatorValues.Count, Is.EqualTo(1));
            Assert.That(certificateQuality.ChemicalIndicatorValues[0].CertificateQuality, Is.EqualTo(certificateQuality));

            certificateQuality.MechanicIndicatorValues.Add(new MechanicIndicatorValue());
            Assert.That(certificateQuality.MechanicIndicatorValues.Count, Is.EqualTo(1));
            Assert.That(certificateQuality.MechanicIndicatorValues[0].CertificateQuality, Is.EqualTo(certificateQuality));

            certificateQuality.Passes.Add(new Pass(100));
            Assert.That(certificateQuality.Passes.Count, Is.EqualTo(1));
            Assert.That(certificateQuality.Passes[0].CertificateQuality, Is.EqualTo(certificateQuality));

            certificateQuality.Destinations.Add(new Destination(100));
            Assert.That(certificateQuality.Destinations.Count, Is.EqualTo(1));
            Assert.That(certificateQuality.Destinations[0].CertificateQuality, Is.EqualTo(certificateQuality));
        }
    }
}
