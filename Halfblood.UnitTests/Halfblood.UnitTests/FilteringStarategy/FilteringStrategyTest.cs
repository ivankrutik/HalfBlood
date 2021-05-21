// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilteringStrategyTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FilteringStrategyTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.FilteringStarategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Components.Strategies;
    using Buisness.Components.Strategies.CertificateQualityDomain;
    using Buisness.Components.Strategies.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using Buisness.Components.Strategies.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Components.Strategies.CommonDomain;
    using Buisness.Components.Strategies.CuttingOrderDomain;
    using Buisness.Components.Strategies.DepartmentOrderDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using Buisness.InternalEntity.Filters;
    using Buisness.InternalEntity.Strategies;

    using Filtering.Infrastructure;

    using Halfblood.Common;
    using Halfblood.UnitTests.BuisnesWorkflow.Tests;

    using NHibernate;
    using NHibernate.Helper.Filter;

    using NUnit.Framework;

    public class FilteringStrategyTest : AutoRollbackFixtureEx
    {
        [Test]
        public void TestAgnlistFilterStrategy()
        {
            var query = GetFilterStrategy(
                new AgnlistFilteringStrategy(),
                new UserFilter { Rn = SampleEntityDto.GetUserMaratoss().Rn });

            Assert.That(query.RowCount(), Is.EqualTo(1));
            Assert.That(query.List().First().ClockNumber, Is.EqualTo("087220"));
        }
        [Test]
        public void TestPlanReceiptOrderFilterStrategy()
        {
            var filter = new PlanReceiptOrderFilter
            {
                CreationDate = new Between<DateTime?>(new DateTime(1990, 1, 1), DateTime.Now),
                GroundDocumentDate = new Between<DateTime?>(new DateTime(1990, 1, 1), DateTime.Now),
                GroundDocumentNumb = "GroundDocNumb1",
                Note = "Note1",
                Numb = null,
                Pref = "Pref1",
                States = new List<PlanReceiptOrderState> { PlanReceiptOrderState.NotСonfirm },
                StateDate = new Between<DateTime?>(new DateTime(1990, 1, 1), DateTime.Now),
            };

            var query = GetFilterStrategy(
                new PlanReceiptOrderFilterStrategy(), filter);

            var result = query.List();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().GroundDocumentNumb, Is.EqualTo(filter.GroundDocumentNumb));
            Assert.That(result.First().Note, Is.EqualTo(filter.Note));
            Assert.That(result.First().Pref, Is.EqualTo(filter.Pref));
            Assert.That(filter.States.Contains(result.First().State));
        }
        [Test]
        public void TestActinputControlFilterStrategy()
        {
            var query = GetFilterStrategy(
                           new ActInputControlFilterStrategy(), new ActInputControlFilter
                           {
                               Rn = 4564,
                               State = new List<ActInputControlState> { ActInputControlState.Close, ActInputControlState.New },
                               TheMoveActs = new List<TheMoveActDto> { 
                                   new TheMoveActDto { Rn = 123 , DepartmentCreator= new StaffingDivisionDto {Code="005"}, UserCreator= new UserDto{Rn=34}},
                                   new TheMoveActDto{ Rn=213,DepartmentCreator=new StaffingDivisionDto {Code="005"} ,UserCreator= new UserDto{ Rn=12}}
                                                                  }
                           });
            Assert.That(query.RowCount(), Is.EqualTo(0));
        }
        [Test]
        public void TestCertificateQualityFilterStrategy()
        {
            var query = GetFilterStrategy(
                new CertificateQualityFilterStrategy(),
                new CertificateQualityFilter
                {
                    CreationDate = new Between<DateTime> { From = DateTime.Now, To = DateTime.Now },
                    Cast = "asd",
                    GostMarka = "sd",
                    GostMix = "sddf",
                    Marka = "sd",
                    Mix = "xc",
                    Note = "sd",
                    MakingDate = new Between<DateTime> { From = DateTime.Now, To = DateTime.Now },
                    StorageDate = new Between<DateTime> { From = DateTime.Now, To = DateTime.Now },
                    CreatorFactory = new UserFilter { Rn = 12 },
                    UserCreator = new UserFilter { Rn = 13 }
                });
            Assert.That(query.RowCount(), Is.EqualTo(0));
        }
        [Test]
        public void TestContractFilterStrategy()
        {
            var query = GetFilterStrategy(new ContractFilterStrategy(), new ContractFilter
                {
                    Contaractor = SampleEntityDto.GetUserMaratoss(),
                    StagesOfTheContract = new StagesOfTheContractFilter
                        {
                            Numb = "1",
                            PersonalAccount = new PersonalAccountFilter
                                {
                                    Numb = "2"
                                }
                        }
                });
            Assert.That(query.RowCount(), Is.EqualTo(0));
        }
        [Test]
        public void TestPersonalAccountFilterStrategy()
        {
            var query = GetFilterStrategy(new PersonalAccountFilterStrategy(), new PersonalAccountFilter
            {
                Numb = "ds"
            });
            Assert.That(query.RowCount(), Is.GreaterThan(0));
        }
        [Test]
        public void TestAcatalogFilterStrategy()
        {
            var query = GetFilterStrategy(new AcatalogFilterStrategy(), new AcatalogFilter
                {
                    UserPrivilege = new UserPrivilegeFilter
                    {
                        Role = new RoleFilter { Rn = 1647001 },
                        UnitFunction = new UnitFunctionFilter { SectionOfSystemUnitcode = new SectionOfSystemFilter { UnitCode = "UDO_PCO" } }
                    }
                });
            Assert.That(query.RowCount(), Is.Not.EqualTo(1));
        }
        [Test]
        public void TestTypeOfDocumentFilterStrategy()
        {
            var query = GetFilterStrategy(new TypeOfDocumentFilterStrategy(), new TypeOfDocumentFilter { DocCode = "ТТН" });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestPlanCertificateFilterStrategy()
        {
            var query = GetFilterStrategy(new PlanCertificateFilterStrategy(), new PlanCertificateFilter
            {
                RnPlanReceiptOrder = SampleEntityDto.CreatePlanReceiptOrder().Rn
            });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestlanReceiptOrderPersonalAccountFilterStrategy()
        {
            var query = GetFilterStrategy(new PlanReceiptOrderPersonalAccountFilterStrategy(), new PlanReceiptOrderPersonalAccountFilter()
            {
                PlanCertificate = new PlanCertificateFilter { Rn = SampleEntityDto.CreatePlanCertificate().Rn }
            });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestMechanicIndicatorValueFilterStrategy()
        {
            var query = GetFilterStrategy(new MechanicIndicatorValueFilterStrategy(), new MechanicIndicatorValueFilter()
                {
                    CertificateQuality =
                        new CertificateQualityFilter { Rn = SampleEntity.CreateCertificateQuality().Rn }
                });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestDictionaryChemicalIndicatorFilterStrategy()
        {
            var query = GetFilterStrategy(new DictionaryChemicalIndicatorFilterStrategy(),
                                          new DictionaryChemicalIndicatorFilter()
                                              {
                                                  Code = "1"
                                              });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestDictionaryMechanicalIndicatorFilterStrategy()
        {
            var query = GetFilterStrategy(new DictionaryMechanicalIndicatorFilterStrategy(),
                                          new DictionaryMechanicalIndicatorFilter()
                                              {
                                                  Code = "1"
                                              });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestStoreGasStationOilDepotFilterStrategy()
        {
            var query = GetFilterStrategy(new StoreGasStationOilDepotFilterStrategy(),
                                          new StoreGasStationOilDepotFilter()
                                          {
                                              AzsNumber = "1"
                                          });
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void ActSelectionOfProbeDestinationFilterStrategy()
        {
            var filter = ActSelectionOfProbeFilter.Default;

            var query = GetFilterStrategy(new ActSelectionOfProbeFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void TestCuttingOrderFilterStrategy()
        {
            var filter = new CuttingOrderFilter
            {
                CreationDate = new Between<DateTime?>(new DateTime(1900, 1, 1), DateTime.Now),
                DateDocumentIntegration = new Between<DateTime?>(new DateTime(1900, 1, 1), DateTime.Now),
                Numb = 1,
                State = new List<CuttingOrderState> { CuttingOrderState.FirstState }
            };
            var query = GetFilterStrategy(
                new CuttingOrderFilterStrategy(), filter);
            var result = query.List();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().CreationDate, Is.EqualTo(filter.CreationDate));
            Assert.That(result.First().Numb, Is.EqualTo(filter.Numb));
            Assert.That(result.First().DateDocumentIntegration, Is.EqualTo(filter.DateDocumentIntegration));
            Assert.That(filter.State.Contains(result.First().State));
        }
        [Test]
        public void NomenclatureNumberModificationFilterStrategy()
        {
            var filter = NomenclatureNumberModificationFilter.Default;

            var query = GetFilterStrategy(new NomenclatureNumberModificationFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void DepartmentOrderFilterStrategy()
        {
            var filter = new DepartmentOrderFilter
            {
                StateDate = new Between<DateTime?>(new DateTime(1900, 1, 1), DateTime.Now),
                Numb = 1,
                Pref = "Ew",
                WarehouseReceiver = new StoreGasStationOilDepotFilter { AzsNumber = "sd*" },
            };

            var query = GetFilterStrategy(new DepartmentOrderFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void UnitFunctionFilterStrategyTest()
        {
            var filter = new UnitFunctionFilter
            {
                UserPrivilegeFilter = new UserPrivilegeFilter { RnAccessCatalog = 1008008054 },
                Standard = TypeActionInSystem.NonStandardAction,
                SectionOfSystemUnitcode =
                    new SectionOfSystemFilter { UnitCode = "UDO_PCO" }
            };

            var query = GetFilterStrategy(new UnitFunctionFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void AdditionalDictionaryStrategyTest()
        {
            var filter = new AdditionalDictionaryFilter
            {
                Code = "Код товароведа",
                AdditionalDictionaryValues = new AdditionalDictionaryValuesFilter
                {
                    Note = "193887"
                }
            };

            var query = GetFilterStrategy(new AdditionalDictionaryFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void GoodsManagertStrategyTest()
        {
            var filter = new GoodsManagerFilter
            {
                Contractor = new UserFilter { TableNumber = "0013798", OrganizationName = "ЗАО" }
            };

            var query = GetFilterStrategy(new GoodsManagerFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.Not.EqualTo(0));
        }
        [Test]
        public void Deficiency()
        {
            var filter = new DeficiencyFilter();

            var query = GetFilterStrategy(new DeficiencyFilterStrategy(), filter);
            Assert.That(query.RowCount(), Is.GreaterThanOrEqualTo(1));
        }

        private IQueryOver<TEntity, TEntity> GetFilterStrategy<TEntity, TFilter>(
            IFilteringStrategy<TEntity> strategy,
            TFilter filter) where TEntity : class, IHasUid<long> where TFilter : IUserFilter
        {
            IQueryOver<TEntity, TEntity> query = Session.QueryOver<TEntity>();
            strategy.Filtering(query, filter);
            return query;
        }
    }
}
