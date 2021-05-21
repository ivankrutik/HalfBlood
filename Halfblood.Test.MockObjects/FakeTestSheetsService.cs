// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeTestSheetsService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FakeTestSheetsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Entities.TestSheetDomain;
using ServiceContracts.Facades;

namespace Halfblood.Test.MockObjects
{
    public class FakeTestSheetsService : ITestSheetsService
    {
        public static long NextRn = 9999;

        public TestSheetDto InsertTestSheet(TestSheetDto entity)
        {
            return new TestSheetDto {Rn = ++NextRn};
        }

        public TestResultDto InsertTestResult(TestResultDto entity)
        {
            return new TestResultDto {Rn = ++NextRn};
        }

        public HeatTreatmentDto InsertHeatTreatment(HeatTreatmentDto entity)
        {
            return new HeatTreatmentDto {Rn = ++NextRn};
        }

        public SampleResultSetDto InsertSampleResultSet(SampleResultSetDto entity)
        {
            return new SampleResultSetDto {Rn = ++NextRn};
        }

        public void UpdateTestSheet(TestSheetDto entity)
        {
        }

        public void UpdateTestResult(TestResultDto entity)
        {
        }

        public void UpdateHeatTreatment(HeatTreatmentDto entity)
        {
        }

        public void UpdateSampleResultSet(SampleResultSetDto entity)
        {
        }

        public void RemoveTestSheet(long rn)
        {
        }

        public void RemoveHeatTreatment(long rn)
        {
        }

        public void RemoveTestResult(long rn)
        {
        }

        public void RemoveSampleResultSet(long rn)
        {
        }
    }
}