using Buisness.Entities.TestSheetDomain;
using Halfblood.Common;
using NHibernate.Helper.Filter;
using NHibernate.Helper.Repository;
using NHibernate.Helper.Service;
using ParusModel.Entities.TestSheetDomain;
using ServiceContracts.Facades;

namespace Buisness.Workflows.Services.TestSheetDomain
{
    [Register(typeof (ITestSheetsService))]
    public class TestSheetsService : ServiceBase, ITestSheetsService
    {
        public TestSheetsService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public TestSheetDto InsertTestSheet(TestSheetDto entity)
        {
            return AddEntity<TestSheet, TestSheetDto>(entity);
        }

        public TestResultDto InsertTestResult(TestResultDto entity)
        {
            return AddEntity<TestResult, TestResultDto>(entity);
        }

        public HeatTreatmentDto InsertHeatTreatment(HeatTreatmentDto entity)
        {
            return AddEntity<HeatTreatment, HeatTreatmentDto>(entity);
        }

        public SampleResultSetDto InsertSampleResultSet(SampleResultSetDto entity)
        {
            return AddEntity<SampleResultSet, SampleResultSetDto>(entity);
        }

        public void UpdateTestSheet(TestSheetDto entity)
        {
            UpdateEntity<TestSheet, TestSheetDto>(entity);
        }

        public void UpdateTestResult(TestResultDto entity)
        {
            UpdateEntity<TestResult, TestResultDto>(entity);
        }

        public void UpdateHeatTreatment(HeatTreatmentDto entity)
        {
            UpdateEntity<HeatTreatment, HeatTreatmentDto>(entity);
        }

        public void UpdateSampleResultSet(SampleResultSetDto entity)
        {
            UpdateEntity<SampleResultSet, SampleResultSetDto>(entity);
        }

        public void RemoveTestSheet(long rn)
        {
            RemoveEntity<TestSheet>(new TestSheet{Rn=rn});
        }

        public void RemoveTestResult(long rn)
        {
            RemoveEntity<TestResult>(new TestResult{Rn=rn});
        }

        public void RemoveHeatTreatment(long rn)
        {
            RemoveEntity<HeatTreatment>(new HeatTreatment{Rn=rn});
        }

        public void RemoveSampleResultSet(long rn)
        {
            RemoveEntity<SampleResultSet>(new SampleResultSet{Rn=rn});
        }
    }
}