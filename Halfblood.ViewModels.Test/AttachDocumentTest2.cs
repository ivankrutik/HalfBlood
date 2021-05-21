// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachDocumentTest2.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the AttachDocumentTest2 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test
{
    using NUnit.Framework;

    using Rhino.Mocks;

    using UI.Entities.AttachedDocumentDomain;

    public class AttachDocumentTest2
    {
        public void BeginInsertTest()
        {
            var documentManager = MockRepository.GenerateStub<ITheDocumentManager>();
            Assert.That(documentManager.AddingDocument, Is.Null);
            documentManager.BeginInsert();
            
            Assert.That(documentManager.AddingDocument, Is.Not.Null);
        }

        public void ApplyInsertTest()
        {
            var documentManager = MockRepository.GenerateStub<ITheDocumentManager>();
            Assert.That(documentManager.AddingDocument, Is.Null);
            documentManager.BeginInsert();

            Assert.That(documentManager.AddingDocument, Is.Not.Null);
        }
    }

    public interface ITheDocumentManager
    {
        AttachedDocument AddingDocument { get; set; }
        void BeginInsert();
    }
}
