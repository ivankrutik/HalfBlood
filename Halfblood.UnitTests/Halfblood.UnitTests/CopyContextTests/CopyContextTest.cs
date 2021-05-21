// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyContextTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CopyContextTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Halfblood.Common.Helpers.FileManagers.Converters;

namespace Halfblood.UnitTests.CopyContextTests
{
    using System;
    using System.Drawing;

    using FizzWare.NBuilder;

    using Halfblood.Common.Helpers;
    using NUnit.Framework;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;

    using PlanReceiptOrder = UI.Entities.PlanReceiptOrderDomain.PlanReceiptOrder;

    /// <summary>
    /// The copy context test.
    /// </summary>
    [TestFixture]
    public class CopyContextTest : TestBase
    {
        private PlanReceiptOrder _instance;
        private CopyContext<PlanReceiptOrder> _copyContext;

        [SetUp]
        public void SetUp()
        {
            _instance = Builder<PlanReceiptOrder>.CreateNew()
                .WithConstructor(() => new PlanReceiptOrder(100))
                .With(x => x.PlanCertificates, Builder<PlanCertificate>.CreateListOfSize(1).Build())
                .Build();

            _instance.PlanCertificates[0].PlanReceiptOrder = _instance;

            _copyContext = new CopyContext<PlanReceiptOrder>();
            _copyContext.SetSourceValue(_instance);
        }

        [Test]
        public void Test2()
        {
            var cq = new CertificateQuality(100);
            var doc = new AttachedDocument(100);

            doc.Content = ImagesConverter.ToByteArray(new Bitmap(@"D:\Repositories\HalfbloodApp\Halfblood.UnitTests\Halfblood.UnitTests\36.jpg"));
            cq.Documents.Add(doc);

            var context = new CopyContext<CertificateQuality>(cq);
            context.Commit();
        }


        [Test]
        public void Commit()
        {
            Assert.That(_copyContext.Value, Is.Not.Null);
            Assert.That(_copyContext.Value, Is.EqualTo(_instance));

            _copyContext.Value.CreationDate = new DateTime(2000, 1, 1);
            _copyContext.Value.GroundTypeOfDocument = new TypeOfDocument();

            _copyContext.Commit();

            Assert.That(_instance.Rn, Is.EqualTo(_copyContext.Value.Rn));
            Assert.That(_instance.CreationDate, Is.EqualTo(_copyContext.Value.CreationDate));
            Assert.That(_instance.GroundReceiptTypeOfDocument, Is.EqualTo(_copyContext.Value.GroundReceiptTypeOfDocument));
            Assert.That(_instance, Is.EqualTo(_copyContext.Value));
        }
    }
}
