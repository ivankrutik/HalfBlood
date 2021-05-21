using Buisness.Entities.TestSheetDomain;

namespace ServiceContracts.Facades
{
    public interface ITestSheetsService
    {
        TestSheetDto InsertTestSheet(TestSheetDto entity);
        TestResultDto InsertTestResult(TestResultDto entity);
        HeatTreatmentDto InsertHeatTreatment(HeatTreatmentDto entity);
        SampleResultSetDto InsertSampleResultSet(SampleResultSetDto entity);

        void UpdateTestSheet(TestSheetDto entity);
        void UpdateTestResult(TestResultDto entity);
        void UpdateHeatTreatment(HeatTreatmentDto entity);
        void UpdateSampleResultSet(SampleResultSetDto entity);

        void RemoveTestSheet(long rn);
        void RemoveTestResult(long rn);
        void RemoveHeatTreatment(long rn);
        void RemoveSampleResultSet(long rn);
    }
}