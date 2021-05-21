using System;
using DataAccessLogic.Infrastructure;
using Learning.inheritance;
using Learning.inheritance.TablePerType;
using ParusModel.Entities.AttachedDocumentDomain;
using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
using ParusModel.Entities.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests
{
    using NHibernate;
    using NUnit.Framework;

    public class Inheritance
    {
        [Test]
        public void Test1()
        {
            var connection = new NhConnection.NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            //var dog=session.Get<Dog>(1);
            //var snake = session.Get<Snake>(1);
            var animal = session.Get<Animal>(1);
            var crocodile = session.Get<Crocodile>(2);

            session.Save(new Animal {FoodClassification = "21"});
            session.Flush();

            session.Save(new Crocodile {FoodClassification = "1111"});
            session.Flush();
            //var horse = session.Get<Horse>(1);
            //var snake = session.Get<Snake>(1);
            //var dog = session.Get<Dog>(1);
        }

        [Test]
        public void Test2()
        {
             var connection = new NhConnection.NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            var pco = session.Load<PlanCertificate>(1008334354L);
            var cer = pco.CertificateQuality;
            var d = cer.AttachedDocuments;


            cer.AttachedDocuments.Add(new CertificateQualityAttachedDocument { Catalog = new Catalog(7833001), AttachedDocumentType = new AttachedDocumentType { Rn = 784835058 } , Document = cer.Rn});

            session.Save(cer);
            session.Flush();
            d = d;
        }
        [Test]
        public void Test3()
        {
            var connection = new NhConnection.NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            var pco = session.Get<Crocodile>(1);

            session.Save(new Crocodile {FoodClassification = "!2"});
            session.Flush();

            var d = 1;
            var f = 3;
            d = d + f;


        }
    }
}
