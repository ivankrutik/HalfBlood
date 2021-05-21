namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;

    using Buisness.Entities.TestSheetDomain;

    using Halfblood.Common.Mappers;

    using ParusModelLite.TestSheetsDomain;

    using UI.Entities.TestSheetsDomain;

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