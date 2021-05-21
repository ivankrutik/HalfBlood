namespace Buisness.Workflows.Mapping.TestSheetDomain
{
    using AutoMapper;

    using Buisness.Entities.TestSheetDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.TestSheetDomain;

    using ParusModelLite.TestSheetsDomain;

    [AutoMapperProfile]
    public class TestSheetsProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TestSheet, TestSheetDto>();
            Mapper.CreateMap<TestSheetDto, TestSheet>();
            Mapper.CreateMap<TestResult, TestResultDto>();
            Mapper.CreateMap<TestResultDto, TestResult>();
            Mapper.CreateMap<HeatTreatment, HeatTreatmentDto>();
            Mapper.CreateMap<HeatTreatmentDto, HeatTreatment>();
            Mapper.CreateMap<SampleResultSet, SampleResultSetDto>();
            Mapper.CreateMap<SampleResultSetDto, SampleResultSet>();
            Mapper.CreateMap<TestSheet, TestSheetLiteDto>();
            Mapper.CreateMap<TestSheetLiteDto, TestSheet>();
        }
    }
}