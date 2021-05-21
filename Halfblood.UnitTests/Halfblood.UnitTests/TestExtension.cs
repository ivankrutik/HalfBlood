// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestExtension.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   TestExtension.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests
{
    using System;
    using System.Collections.Generic;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;

    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    namespace Extension
    {
        using ParusModel.Entities;
        using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
        using ParusModel.Entities.PlanReceiptOrderDomain;
        

        internal static class TestExtension
        {
            public static Configuration ExportSchema(this Configuration cfg)
            {
                var schema = new SchemaExport(cfg);
                //schema.Drop(false, true);
                schema.SetOutputFile("ParusModel.sql").Create(false, true);

                return cfg;
            }
            public static ISessionFactory InsertData(this ISessionFactory sessionFactory)
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    //Users
                    var users = new List<Contractor>
                    {
                        new Contractor { ClockNumber = "087229", Firstname = "Marat", Lastname = "Maratoss", Rn = 1},
                        new Contractor { ClockNumber = "200300", Firstname = "Djone", Lastname = "Markov", Rn = 2},
                        new Contractor { ClockNumber = "100500", Firstname = "Rafael", Lastname = "Turtle", Rn = 3},
                        new Contractor { ClockNumber = "000333", Firstname = "Leonardo", Lastname = "Turtle", Rn = 4}
                    };
                    users.ForEach(user => session.Save(user));
                    //CertificateQuality
                    var certificates = new List<CertificateQuality>
                    {
                        new CertificateQuality { UserCreator = users[0], Rn = 1 },
                        new CertificateQuality { UserCreator = users[1], Rn = 2 },
                        new CertificateQuality { UserCreator = users[2], Rn = 3 },
                        new CertificateQuality { UserCreator = users[3], Rn = 4 }
                    };
                    certificates.ForEach(x => session.Save(x));
                    //PlanReceiptOrderPersonalAccount
                    var personalAccounts = new List<PlanReceiptOrderPersonalAccount>
                    {
                        new PlanReceiptOrderPersonalAccount {Rn = 1},
                        new PlanReceiptOrderPersonalAccount {Rn = 2},
                        new PlanReceiptOrderPersonalAccount {Rn = 3},
                        new PlanReceiptOrderPersonalAccount {Rn = 4}
                    };
                    personalAccounts.ForEach(x => session.Save(x));
                    session.Flush();
                    //PlanCertificate
                    var plansCertificate = new List<PlanCertificate>
                    {
                        new PlanCertificate {Rn = 1},
                        new PlanCertificate {Rn = 2},
                        new PlanCertificate {Rn = 3},
                        new PlanCertificate {Rn = 4}
                    };
                    plansCertificate.ForEach(x => session.Save(x));
                    //StaffingDivision
                    var staffingsDivision = new List<StaffingDivision>
                    {
                        new StaffingDivision {Rn = 1},
                        new StaffingDivision {Rn = 2},
                        new StaffingDivision {Rn = 3},
                        new StaffingDivision {Rn = 4}
                    };
                    staffingsDivision.ForEach(x => session.Save(x));
                    //PlanReceiptOrder
                    var plansReceiptOrder = new List<PlanReceiptOrder>
                    {
                        new PlanReceiptOrder
                        {
                            CreationDate = new DateTime(2013, 10, 3),
                        //    GroundDocDate = new DateTime(2013, 2, 3),
                            GroundDocumentNumb = "555",
                            Note = "bla bla bla",
                            Numb = 10,
                            PlanCertificates = {plansCertificate[2], plansCertificate[3]},
                            Pref = "1 Pref",
                            Rn = 1,
                            StaffingDivision = staffingsDivision[0],
                            State  = PlanReceiptOrderState.NotÑonfirm, 
                            StateDate = new DateTime(2012,3,4),
                            UserContractor = users[2],
                            UserCreator = users[3]
                        },
                        new PlanReceiptOrder
                        {
                            CreationDate = new DateTime(2013, 12, 3),
                          //  GroundDocDate = new DateTime(2013, 12, 3),
                            GroundDocumentNumb = "123",
                            Note = "AHAHAHAHHA",
                            Numb = 20,
                            PlanCertificates = {plansCertificate[0], plansCertificate[1]},
                            Pref = "2 Pref",
                            Rn = 2,
                            StaffingDivision = staffingsDivision[1],
                            State = PlanReceiptOrderState.Confirm, 
                            StateDate = new DateTime(2012,3,24),
                            UserContractor = users[0],
                            UserCreator = users[1]
                        }
                    };
                    plansReceiptOrder.ForEach(x => session.Save(x));
                    session.Flush();
                }
                return sessionFactory;
            }
            public static ISessionFactory InsertDataParusModel(this ISessionFactory sessionFactory)
            {
                using (ISession session = sessionFactory.OpenSession())
                {
                    IList<Contractor> users = session.QueryOver<Contractor>().Take(10).List();
                    //CertificateQuality
                    var certificates = new List<CertificateQuality>
                    {
                        new CertificateQuality { UserCreator = users[0], Rn = 1 },
                        new CertificateQuality { UserCreator = users[1], Rn = 2 },
                        new CertificateQuality { UserCreator = users[2], Rn = 3 },
                        new CertificateQuality { UserCreator = users[3], Rn = 4 }
                    };
                    certificates.ForEach(x => session.Save(x));
                    //PlanReceiptOrderPersonalAccount
                    var personalAccounts = new List<PlanReceiptOrderPersonalAccount>
                    {
                        new PlanReceiptOrderPersonalAccount {Rn = 1},
                        new PlanReceiptOrderPersonalAccount {Rn = 2},
                        new PlanReceiptOrderPersonalAccount {Rn = 3},
                        new PlanReceiptOrderPersonalAccount {Rn = 4}
                    };
                    personalAccounts.ForEach(x => session.Save(x));
                    session.Flush();
                    //PlanCertificate
                    var plansCertificate = new List<PlanCertificate>
                    {
                        new PlanCertificate {Rn = 1},
                        new PlanCertificate {Rn = 2},
                        new PlanCertificate {Rn = 3},
                        new PlanCertificate {Rn = 4}
                    };
                    plansCertificate.ForEach(x => session.Save(x));
                    //StaffingDivision
                    IList<StaffingDivision> staffingsDivision = session.QueryOver<StaffingDivision>().Take(10).List();
                    //PlanReceiptOrder
                    var plansReceiptOrder = new List<PlanReceiptOrder>
                    {
                        new PlanReceiptOrder
                        {
                            CreationDate = new DateTime(2013, 10, 3),
                         //   GroundDocDate = new DateTime(2013, 2, 3),
                            GroundDocumentNumb = "555",
                            Note = "bla bla bla",
                            Numb = 10,
                            PlanCertificates = {plansCertificate[2], plansCertificate[3]},
                            Pref = "1 Pref",
                            Rn = 1,
                            StaffingDivision = staffingsDivision[0],
                            State = PlanReceiptOrderState.NotÑonfirm, 
                            StateDate = new DateTime(2012,3,4),
                            UserContractor = users[2],
                            UserCreator = users[3]
                        },
                        new PlanReceiptOrder
                        {
                            CreationDate = new DateTime(2013, 12, 3),
                        //    GroundDocDate = new DateTime(2013, 12, 3),
                            GroundDocumentNumb = "123",
                            Note = "AHAHAHAHHA",
                            Numb = 20,
                            PlanCertificates = {plansCertificate[0], plansCertificate[1]},
                            Pref = "2 Pref",
                            Rn = 2,
                            StaffingDivision = staffingsDivision[1],
                            State = PlanReceiptOrderState.Confirm, 
                            StateDate = new DateTime(2012,3,24),
                            UserContractor = users[0],
                            UserCreator = users[1]
                        }
                    };
                    plansReceiptOrder.ForEach(x => session.Save(x));
                    session.Flush();
                }
                return sessionFactory;
            }
            public static void CleanUpTable<T>(ISessionFactory sessionFactory)
            {
                var metadata = sessionFactory.GetClassMetadata(typeof(T)) as NHibernate.Persister.Entity.AbstractEntityPersister;
                var table = metadata.TableName;
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var deleteAll = string.Format("DELETE FROM {0}".StringFormat(table));
                        session.CreateSQLQuery(deleteAll).ExecuteUpdate();
                        transaction.Commit();
                    }
                }
            }
        }
    }
}