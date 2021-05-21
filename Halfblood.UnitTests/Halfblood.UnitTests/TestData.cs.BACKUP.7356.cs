using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Halfblood.UnitTests.BuisnesWorkflow.Tests;
using NHibernate;
using ParusModel;
using ParusModel.WorkOrderDomain;
using ParusModel.WorkOrderDomain.ActInputControlDomain;

namespace Halfblood.UnitTests
{
    public static class TestData
    {
        public static void Create(ISession session)
        {
            var dictionaryPass = Builder<DictionaryPass>.CreateNew()
                    .With(x => x.RN = 0)
                    .With(x => x.CRN = 1007315958)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Agnlist = SampleEntity.GetUserMaratoss())
                .Do(x => session.Save(x))
                .Build();

            var certificatesQuality = Builder<CertificateQuality>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.CRN = 1007318670)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.DictionaryPass = dictionaryPass)
                .Do(x => session.Save(x))
                .Build();

            var actsInputControlFunctioning = Builder<ActInputControlFunctioning>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Agnlist = SampleEntity.GetUserMaratoss())
                .Build();

            var technicalStatesEssential = Builder<TechnicalStateEssential>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var actsInputControlTechnicalState = Builder<ActInputControlTechnicalState>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                .Build();

            foreach (var item in actsInputControlTechnicalState)
            {
                var conEss = technicalStatesEssential.First(x => x.ActInputControlTechnicalState == null);
                conEss.ActInputControlTechnicalState = item;
                item.TechnicalStateEssentials = new List<TechnicalStateEssential>() { conEss };
            }

            var conclusionsEssential = Builder<ConclusionEssential>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.User = SampleEntity.GetUserMaratoss())
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var conclusions = Builder<Conclusion>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Agnlist = SampleEntity.GetUserMaratoss())
                .Build();

            foreach (var item in conclusions)
            {
                 var conEss = conclusionsEssential.First(x => x.Conclusion == null);
                 conEss.Conclusion = item;
                 item.ConclusionEssentials = new List<ConclusionEssential>() { conEss };
            }

            var qualityStatesControlOfTheMakeSignature = Builder<QualityStateControlOfTheMakeSignature>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.User = SampleEntity.GetUserMaratoss())
                    .With(x => x.Department = SampleEntity.CreateStaffingDivision())
                .Build();

            var qualityStatesControlOfTheMake = Builder<QualityStateControlOfTheMake>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Agnlist = SampleEntity.GetUserMaratoss())
                .Build();

            foreach (var item in qualityStatesControlOfTheMake)
            {
                var conEss = qualityStatesControlOfTheMakeSignature.First(x => x.QualityStateControlOfTheMake == null);
                conEss.QualityStateControlOfTheMake = item;
                item.QualityStateControlOfTheMakeSignatureS = new List<QualityStateControlOfTheMakeSignature>() { conEss };
            }

            var solutionByNotes = Builder<SolutionByNote>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.Agnlist = SampleEntity.GetUserMaratoss())
                .Build();

            var theMoveActs = Builder<TheMoveAct>.CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.UserCreator = SampleEntity.GetUserMaratoss())
                    .With(x => x.UserReciver = SampleEntity.GetUserMaratoss())
                    .With(x => x.DepartmentCreator = SampleEntity.CreateStaffingDivision())
                    .With(x => x.DepartmentReciver = SampleEntity.CreateStaffingDivision())
                .Build();

            var actsInputControl = Builder<ActInputControl>
                .CreateListOfSize(10)
                .All()
                    .With(x => x.RN = 0)
                    .With(x => x.CRN = 1007364847)
                    .With(x => x.Company = new Company { RN = 7830001 })
                    .With(x => x.ManagerStoreAct = SampleEntity.GetUserMaratoss())
                    .With(x => x.ManagerStoreTare = SampleEntity.GetUserMaratoss())
                    .With(x => x.CertificateQuality = certificatesQuality.First())
                    .With(x => x.ControlerTare = SampleEntity.GetUserMaratoss())
                .TheFirst(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(0).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(0).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(0).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(0).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(2).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(2).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(2).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(2).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(2).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(0).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(4).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(4).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(4).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(4).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(4).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(4).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(6).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(6).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(6).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(6).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(6).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(6).Take(2).ToList())
                .TheNext(2)
                    .With(x => x.ActInputControlFunctionings = actsInputControlFunctioning.Skip(8).Take(2).ToList())
                    .With(x => x.TheMoveActs = theMoveActs.Skip(8).Take(2).ToList())
                    .With(x => x.Conclusions = conclusions.Skip(8).Take(2).ToList())
                    .With(x => x.ActInputControlTechnicalStates = actsInputControlTechnicalState.Skip(8).Take(2).ToList())
                    .With(x => x.QualityStateControlOfTheMakes = qualityStatesControlOfTheMake.Skip(8).Take(2).ToList())
                    .With(x => x.SolutionByNotes = solutionByNotes.Skip(8).Take(2).ToList())
                .Build();

            foreach (ActInputControl item in actsInputControl)
            {
                foreach (var subItem in item.TheMoveActs) subItem.ActInputControl = item;
                foreach (var subItem in item.Conclusions) subItem.ActInputControl = item;
                foreach (var subItem in item.ActInputControlTechnicalStates) subItem.ActInputControl = item;
                foreach (var subItem in item.QualityStateControlOfTheMakes) subItem.ActInputControl = item;
                foreach (var subItem in item.SolutionByNotes) subItem.ActInputControl = item;
                foreach (var subItem in item.ActInputControlFunctionings) subItem.ActInputControl = item;

                session.Save(item);
            }
        }
    }
}
