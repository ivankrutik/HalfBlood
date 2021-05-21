// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the AttachedDocTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace Halfblood.ViewModels.Test
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Reactive.Subjects;
    using System.Threading;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceContracts.Facades;

    using UI.Entities.AttachedDocumentDomain;
    using UI.ProcessComponents;
    using UI.ProcessComponents.Helpers;

    /// <summary>
    /// The attached doc test.
    /// </summary>
    public class AttachedDocTest : TestBase
    {
        private const string IMAGE_PATH =
            @"D:\Repositories\HalfbloodApp\Halfblood.ViewModels.Test\PlanReceiptOrderDomain\36.jpg";

        [Test]
        public void SetDocumentTest()
        {
            var manager = new DocumentManager();

            Assert.That(manager.HasDocument, Is.Null);
            manager.SetHasDocument(MockRepository.GenerateStub<IHasDocument>());
            Assert.That(manager.HasDocument, Is.Not.Null);
        }

        [Test]
        public void BeginAddTest()
        {
            var manager = new DocumentManager();

            Assert.That(manager.IsInserting, Is.False);
            manager.BeginInsert();
            Assert.That(manager.IsInserting, Is.True);
        }

        [Test]
        public void ApplyTest()
        {
            var manager = new DocumentManager();
            var havedDocument = MockRepository.GenerateMock<IHasDocument>();
            var observable = new Subject<Image>();

            var collection = new List<CertificateQualityAttachedDocument>();
            havedDocument.Stub(x => x.Documents).Return(collection);

            manager.SetHasDocument(havedDocument);
            manager.BeginInsert();
            bool isApply = manager.ApplyInsert();

            Assert.That(isApply, Is.False);
            Assert.That(havedDocument.Documents.Count, Is.EqualTo(0));

            var content = new Bitmap(1, 1);
            observable.OnNext(content);

            isApply = manager.ApplyInsert();
            Assert.That(isApply, Is.True);
            Assert.That(havedDocument.Documents.Count, Is.EqualTo(1));
            Assert.That(havedDocument.Documents[0].Content, Is.EqualTo(content));
        }

        [Test]
        public void CancelTest()
        {
            var manager = new DocumentManager();
            var havedDocument = MockRepository.GenerateStub<IHasDocument>();
            var observable = new Subject<Image>();

            var collection = new List<CertificateQualityAttachedDocument>();
            havedDocument.Stub(x => x.Documents).Return(collection);

            manager.SetHasDocument(havedDocument);
            manager.BeginInsert();
            manager.CancelInsert();

            Assert.That(havedDocument.Documents.Count, Is.EqualTo(0));

            manager.BeginInsert();
            var content = new Bitmap(1, 1);
            observable.OnNext(content);

            manager.CancelInsert();

            Assert.That(havedDocument.Documents.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeletingDocumentTest()
        {
            var manager = new DocumentManager();
            var havedDocument = MockRepository.GenerateStub<IHasDocument>();
            var document = new CertificateQualityAttachedDocument();

            var collection = new List<CertificateQualityAttachedDocument>();
            havedDocument.Stub(x => x.Documents).Return(collection);

            havedDocument.Documents.Add(document);

            manager.SetHasDocument(havedDocument);
            manager.DeletingDocument(document);

            Assert.That(havedDocument.Documents.Count, Is.EqualTo(0));
        }
    }
}
