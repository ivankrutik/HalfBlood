// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeFilteringService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FakeFilteringService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buisness.Entities.CommonDomain;
using Buisness.Entities.TestSheetDomain;
using Buisness.Filters.TestSheetsDomain;
using Filtering.Infrastructure;
using FizzWare.NBuilder;
using Halfblood.Common;
using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;
using ParusModelLite.TestSheetsDomain;
using ServiceContracts.Facades;

namespace Halfblood.Test.MockObjects
{
    public class FakeFilteringService : IFilteringService
    {
        private static readonly RandomGenerator _rnd = new RandomGenerator(new Random((int) DateTime.Now.Ticks));
        private static int _ii;
        private static int _rn = 10000;

        public IList<IDto> Filtering(Type type, IUserFilter filter)
        {
            IList<IDto> collection = null;
            if (Handled(type, filter, ref collection))
            {
                return collection;
            }

            object builder =
                typeof (Builder<>).MakeGenericType(type)
                    .GetMethod("CreateListOfSize", new[] {typeof (int)})
                    .Invoke(null, new object[] {10});

            var collection2 = (IList) builder.GetType().GetMethod("Build").Invoke(builder, null);

            return collection2.Cast<IDto>().ToList();
        }

        private static UserDto NewUser()
        {
            return new UserDto
            {
                Firstname = _rnd.Phrase(15),
                Lastname = _rnd.Phrase(10),
                TableNumber = _rnd.Next(100000, 999999).ToString(),
                NameShort = _rnd.Phrase(15),
                OrganizationName = _rnd.Phrase(15),
                Rn = _rnd.Next(4000, 5000)
            };
        }

        private static DateTime NewDate()
        {
            DateTime curdate = DateTime.Now.AddDays(-30);
            return _rnd.Next(curdate, curdate.AddDays(60));
        }

        private static int GetMin()
        {
            return _rnd.Next(3, 5);
        }

        private static int GetMax()
        {
            return GetMin()*2;
        }

        private bool Handled(Type type, IUserFilter filter, ref IList<IDto> collection)
        {
            if (type == typeof (TestSheetLiteDto))
            {
                collection = Builder<TestSheetLiteDto>.CreateListOfSize(_rnd.Next(GetMin(), GetMax()))
                    .All()
                    .Do(x => x.Rn = ++_rn)
                    .Do(x => x.Note = _rnd.Phrase(50))
                    .Do(x => x.Number = _rnd.Next(1000, 5000))
                    .Do(x => x.CreationDate = NewDate())
                    .Do(x => x.SampleMaker = "Иванов Иван Иванович")
                    .Do(x => x.SampleMakerDate = NewDate())
                    .Do(x => x.OtkEmployee = "Иванов Иван Иванович")
                    .Do(x => x.OtkEmployeeDate = NewDate())
                    .Do(x => x.VpEmployee = "Иванов Иван Иванович")
                    .Do(x => x.VpEmployeeDate = NewDate())
                    .Do(x => x.LabChief = "Иванов Иван Иванович")
                    .Do(x => x.LabChiefDate = NewDate())
                    .Do(x => x.FixingCardNumber = _rnd.Next(1000, 2000))
                    .Do(x => x.Heater = "Иванов Иван Иванович")
                    .Do(x => x.HeaterDate = NewDate())
                    .Do(x => x.Material = _rnd.Phrase(80))
                    .Do(x => x.Certificate = _rnd.Phrase(80))
                    .Do(x => x.ActSelectionDate = NewDate())
                    .Do(x => x.ActSelectionNumber = _rnd.Next(1000, 5000))
                    .Do(x => x.RnActSelection = _rnd.Next(1000, 5000))
                    .Build().Cast<IDto>().ToList();
                return true;
            }

            if (type == typeof (TestResultDto))
            {
                if (((ITestSheetChild) filter).RnTestSheet > 0)
                    collection =
                        Builder<TestResultDto>.CreateListOfSize(_rnd.Next(GetMin(), GetMax()))
                            .All()
                            .Do(x => x.Rn = ++_rn)
                            .Do(
                                x =>
                                    x.AnalysesRange =
                                        string.Format("{0} - {1}", _rnd.Next(2000, 3000).ToString(),
                                            _rnd.Next(3000, 4000).ToString()))
                            .Do(x => x.TestingMethod = _rnd.Phrase(20))
                            .Do(x => x.Requirements = _rnd.Phrase(40))
                            .Do(x => x.Equipment = _rnd.Phrase(20))
                            .Do(x => x.Value = Math.Round((100*_rnd.Next(0, 1.0)), _rnd.Next(1, 3)).ToString())
                            .Do(x => x.Note = _rnd.Phrase(50))
                            .Do(x => x.Tester = NewUser())
                            .Do(x => x.TesterDate = NewDate())
                            .Do(x => x.IndicatorName = _rnd.Phrase(20))
                            .Do(x => x.Unit = _rnd.Phrase(5))
                            .Do(x =>
                            {
                                if (!_rnd.Boolean()) return;
                                x.SampleResultSets =
                                    Builder<SampleResultSetDto>.CreateListOfSize(GetMin()).All()
                                        .Do(z => z.Rn = ++_rn)
                                        .Do(z => z.IsRow = true)
                                        .Do(z =>
                                        {
                                            z.Value1 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value2 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value3 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value4 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value5 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value6 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value7 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value8 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value9 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                            z.Value10 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        })
                                        .Do(z => z.TestResult = x)
                                        .Build();
                                // создаём заголовок таблицы
                                x.SampleResultSets.Insert(0, Builder<SampleResultSetDto>.CreateNew()
                                    .Do(z => z.Rn = ++_rn)
                                    .Do(z => z.IsRow = false)
                                    .Do(z =>
                                    {
                                        z.Value1 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value2 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value3 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value4 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value5 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value6 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value7 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value8 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value9 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                        z.Value10 = _rnd.Boolean() ? _rnd.Next(10, 100).ToString() : string.Empty;
                                    })
                                    .Do(z => z.TestResult = x)
                                    .Build());
                            })
                            .Build().Cast<IDto>().ToList();
                else collection = new List<IDto>();
                return true;
            }

            if (type == typeof (HeatTreatmentDto))
            {
                if (((ITestSheetChild) filter).RnTestSheet > 0)
                    collection =
                        Builder<HeatTreatmentDto>.CreateListOfSize(_rnd.Next(1, GetMin()))
                            .All()
                            .Do(x => x.Rn = ++_rn)
                            .Do(x => x.PutTemperature = _rnd.Next(100, 500))
                            .Do(x => x.SetTemperature = _rnd.Next(100, 500))
                            .Do(x => x.HeatingTime = _rnd.Next(10, 120))
                            .Do(x => x.HoldingTime = _rnd.Next(10, 120))
                            .Do(x => x.AmbientTemperature = _rnd.Next(100, 500))
                            .Build().Cast<IDto>().ToList();
                else collection = new List<IDto>();
                return true;
            }

            if (type == typeof (ActSelectionOfProbeLiteDto))
            {
                collection =
                    Builder<ActSelectionOfProbeLiteDto>.CreateListOfSize(10)
                        .All()
                        .With(
                            x => x.ActSelectionOfProbeDepartments,
                            Builder<ActSelectionOfProbeDepartmentLiteDto>.CreateListOfSize(10)
                                .All()
                                .With(
                                    x => x.ActSelectionOfProbeDepartmentRequirements,
                                    Builder<ActSelectionOfProbeDepartmentRequirementLiteDto>.CreateListOfSize(10)
                                        .All()
                                        .With(x => x.Requirement, _ii++.ToString())
                                        .Build())
                                .Build())
                        .Build()
                        .Cast<IDto>()
                        .ToList();
                return true;
            }

            return false;
        }
    }
}