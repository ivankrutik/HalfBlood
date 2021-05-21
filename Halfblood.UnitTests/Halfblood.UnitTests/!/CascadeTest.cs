// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CascadeTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CascadeTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.__
{
    using System;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading;

    using Buisness.Components;
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using DataAccessLogic.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;
    using Halfblood.UnitTests.BuisnesWorkflow.Tests;

    using Learning;

    using NhConnection;

    using NHibernate;
    using NHibernate.Linq;

    using NUnit.Framework;

    using ParusModel.Entities.AttachedDocumentDomain;
    using ParusModel.Entities.CreditSlipDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    public class CascadeTest : TestBase
    {
        [Test]
        public void Test()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var cert = session.Query<Certificate>()
                .Fetch(x => x.Group)
                .ThenFetch(x => x.Students)
                .First();

            cert.Group.Students[0].TermPapers.DoForEach(x => { });

            session.Clear();
            session.Dispose();

            session = connection.GetSessionFactory().OpenSession();

            ITransaction transaction = session.BeginTransaction();

            var paper = new TermPaper { Name = "ALALA", Student = cert.Group.Students[0] };
            cert.Group.Students[0].TermPapers.Add(paper);

            var group = session.Merge(cert.Group);
            session.Update(group);
            session.Update(group.Certificate);

            transaction.Commit();
            transaction.Dispose();
            session.Dispose();
            return;


            var certificate = session.Query<Certificate>().Fetch(x => x.Group).ThenFetch(x => x.Students).ToList().First();

            session.Dispose();

            certificate.Group.Students.Clear();
            //var student = new Student { Name = "the new maratoss", Group = certificate.Group };
            //certificate.Group.Students.Add(student);

            session = connection.GetSessionFactory().OpenSession();
            session.Update(certificate);
            session.Flush();

            session.Dispose();
        }

        [Test]
        public void Test2()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var planCertificate =
                session.Query<PlanCertificate>()
                    .Fetch(x => x.CertificateQuality)
                    .Where(x => x.Rn == 1008161275L).ToList().First();

            var dto = planCertificate.MapTo<PlanCertificateDto>();
            planCertificate = dto.MapTo<PlanCertificate>();

            session.Clear();
            session.Dispose();

            session = connection.GetSessionFactory().OpenSession();

            ITransaction tr = session.BeginTransaction();

            var repository = new RepositoryFactory(session).Create<PlanCertificate>();
            var attachDoc = new CertificateQualityAttachedDocument
                                {
                                    BData = new byte[] { 1, 2, 3 },
                                    AttachedDocumentType = new AttachedDocumentType { Rn = 760351674 },
                                    Document = 437790479,
                                    Note = "ololo",
                                   // UnitCode = "QUALITY_CERTIFICATE",
                                    Catalog = new Catalog(465000873)
                                };
            planCertificate.CertificateQuality.AttachedDocuments.Add(attachDoc);

            string cqGuid = Guid.NewGuid().ToString();
            string pcGuid = Guid.NewGuid().ToString();

            planCertificate.CertificateQuality.Note = cqGuid;
            planCertificate.Note = pcGuid;

            var pc = session.Merge(planCertificate);
            var cq = session.Merge(planCertificate.CertificateQuality);

            session.Update(pc);
            session.Update(cq);

            tr.Commit();
            tr.Dispose();
            session.Dispose();
        }

        [Test]
        public void Test3()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();

            TestData.ActSelectionOfProbeGenerator(session);

            transaction.Commit();
            transaction.Dispose();
            session.Dispose();
        }

        [Test]
        public void Test4()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            //var wheelCube = new WheelCube { Code = "3" };
            //var st = session.Save(wheelCube);


            //session.Clear();
            //session.Dispose();
            //session = connection.GetSessionFactory().OpenSession();
            //var ss = session.QueryOver<WheelCube>().List();



            return;


            var certificate = session.Query<Certificate>().Fetch(x => x.Group).ThenFetch(x => x.Students).ToList().First();

            session.Dispose();

            certificate.Group.Students.Clear();
            //var student = new Student { Name = "the new maratoss", Group = certificate.Group };
            //certificate.Group.Students.Add(student);

            session = connection.GetSessionFactory().OpenSession();
            session.Update(certificate);
            session.Flush();

            session.Dispose();
        }

        [Test]
        public void Test5()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var doc = new AttachedDocument
            {
                AttachedDocumentType = new AttachedDocumentType { Rn = 813609324 },
                BData = new byte[] { 1, 2, 3 },
                Code = "Code",
                Catalog = new Catalog(465000873),
                Document = 437790479,
                Note = "1",
              //  UnitCode = "Contracts"
            };

            session.Save(doc);

            return;
            //            var planCertificate =
            //                session.Query<PlanCertificate>()
            //                    .Fetch(x => x.CertificateQuality)
            //                    .ThenFetchMany(x => x.ChemicalIndicatorValues)
            //                    .Where(x => x.Rn == 1008028460L).ToList().First();
            //
            //            var dto = planCertificate.MapTo<PlanCertificateDto>();
            //            planCertificate = dto.MapTo<PlanCertificate>();
            //
            //            session.Clear();
            //            session.Dispose();
            //
            //
            //            session = connection.GetSessionFactory().OpenSession();
            //
            //            planCertificate.Rn = 0;
            //            planCertificate.CertificateQuality.Rn = 0;
            //
            //
            //            planCertificate.CertificateQuality.AttachedDocuments.Add(doc);
            //
            //
            //            var repository = new RepositoryFactory(session).Create<PlanCertificate>();
            //            repository.Insert(planCertificate);
            //
            //            session.Flush();
            //            session.Dispose();
        }

        [Test]
        public void Test6()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var cq = session.Get<PlanReceiptOrder>(1008067627L);
            var dto = cq.MapTo<PlanReceiptOrderDto>();

            session.Dispose();
            session = connection.GetSessionFactory().OpenSession();

            cq = session.Get<PlanReceiptOrder>(1008067627L);
            var dto2s = cq.MapTo<PlanReceiptOrderWithoutPlanCertificateDto>();
        }

        [Test]
        public void Test7()
        {
            // Есть 2 последовательности.

            // Когда сработает первая последовательность - начать слушать вторую (одну секунду)
            // и когда сработает вторая, то выполнить действие.
            var first = new Subject<Unit>();
            var second = new Subject<string>();

            first.Select(x => second.TakeUntil(Observable.Interval(TimeSpan.FromSeconds(1))).Take(1))
                .Concat()
                .Subscribe(Console.WriteLine);

            first.OnNext(Unit.Default);
            Thread.Sleep(1500);
            second.OnNext(Counter());

            first.OnNext(Unit.Default);
            Thread.Sleep(1500);
            second.OnNext(Counter());

            first.OnNext(Unit.Default);
            second.OnNext(Counter());

            first.OnNext(Unit.Default);
            second.OnNext(Counter());

            first.OnNext(Unit.Default);
            second.OnNext(Counter());
        }

        [Test]
        public void Test8()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            // CreditSlip creditSlip = SampleEntity.CreateCreditSlip();

            var creditSlip =
                session.QueryOver<CreditSlip>()
                    .Where(x => x.State == CreditSlipState.NotFulfilled)
                    .Take(1)
                    .UnderlyingCriteria.UniqueResult<CreditSlip>();

            CreditSlipSpecification creditSlipSpec_1 = SampleEntity.CreateCreditSlipSpecification(creditSlip, session);
            CreditSlipSpecification creditSlipSpec_2 = SampleEntity.CreateCreditSlipSpecification(creditSlip, session);

            creditSlipSpec_1.SerNumb = "new ser numb qqq";
            creditSlipSpec_2.SerNumb = "new ser numb zzz 2";

            creditSlip.CreditSlipSpecifications.Add(creditSlipSpec_1);
            creditSlip.CreditSlipSpecifications.Add(creditSlipSpec_2);

            using (ITransaction tr = session.BeginTransaction())
            {
                session.Save(creditSlipSpec_1);
                tr.Commit();
            }

            using (ITransaction tr = session.BeginTransaction())
            {
                session.Delete(creditSlipSpec_1);
                session.Delete(creditSlipSpec_2);
                tr.Commit();
            }
        }

        [Test]
        public void Test9()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var user = new User { Name = "maratoss" };
            var user_2 = new User { Name = "maratoss 2" };

            using (ITransaction tr = session.BeginTransaction())
            {
                session.Save(user);
                session.Save(user_2);
                tr.Commit();
            }

            using (ITransaction tr = session.BeginTransaction())
            {
                session.Delete(user);
                session.Delete(user_2);
                tr.Commit();
            }
        }

        [Test]
        public void Test10()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting("112BAITULLIN", "1", "dupparus");
            ISession session = connection.GetSessionFactory().OpenSession();

            var pm = new UI.Entities.PermissionMaterialDomain.PermissionMaterial {Rn = 1008338040};

            var pmDto = pm.MapTo<PermissionMaterialDto>();
            var pmClient = pmDto.MapTo<UI.Entities.PermissionMaterialDomain.PermissionMaterial>();
            
            session.Dispose();
            


            var pmEx = new UI.Entities.PermissionMaterialDomain.PermissionMaterialExtension { PermissionMaterial = pmClient };
            pmEx.AcceptToDate = new DateTime(2013, 05, 05);
            var user = new UI.Entities.PermissionMaterialDomain.PermissionMaterialExtensionUser
            {
                RnUser = 484082568L,
                PermissionMaterialExtension = pmEx,
                Fullname = "fullname",
                UserPsdepName = "UserPsdepName",
                UserDept = "123",
            };
            pmEx.PmeUsers.Add(user);
            
            var pmeDto = pmEx.MapTo<PermissionMaterialExtensionDto>();
            var srvPM = pmeDto.MapTo<ParusModel.Entities.PermissionMaterialDomain.PermissionMaterialExtension>();


            session = connection.GetSessionFactory().OpenSession();
            session.Save(srvPM);
            session.Flush();
        }

        [Test]
        public void Test11()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();
            ITransaction tr = session.BeginTransaction();

            var user = new User { Name = "ALALALLA" };
            session.Save(user);
        }

        [Test]
        public void t()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            var cq = session.QueryOver<CertificateQuality>().Where(x => x.Rn == 1008334353L).UnderlyingCriteria.UniqueResult<CertificateQuality>();
            var map = cq.MapTo<CertificateQualityDto>();


            var usDto =
                map.MapTo<UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain.CertificateQuality>();

            var us =
                usDto.MapTo<CertificateQualityDto>();
            us = us;
        }


        private static int i;

        private string Counter()
        {
            return (++i).ToString();
        }
    }
}