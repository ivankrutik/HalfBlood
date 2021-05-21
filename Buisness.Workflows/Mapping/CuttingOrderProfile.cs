// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CuttingOrderProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.CuttingOrderDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.CuttingOrderDomain;

    [AutoMapperProfile]
    public class CuttingOrderProfile : Profile
    {
        protected override void Configure()
        {
            CreateCuttingOrder();
            CreateCuttingOrderMove();
            CreateCuttingOrderSpecification();
            CreateSample();
            CreateSampleCertification();
            CreateCertification();
        }

        private void CreateCuttingOrder()
        {
            Mapper.CreateMap<CuttingOrder, CuttingOrderDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.AssumeDate, o => o.MapFrom(x => x.AssumeDate))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                  .ForMember(x => x.DateDocumentIntegration, o => o.MapFrom(x => x.DateDocumentIntegration))
                  .ForMember(x => x.Department, o => o.MapFrom(x => x.Department))
                  .ForMember(x => x.District, o => o.MapFrom(x => x.District))
                  .ForMember(x => x.Inspector, o => o.MapFrom(x => x.Inspector))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Priority, o => o.MapFrom(x => x.Priority))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.Specifications, o => o.MapFrom(x => x.Specifications))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.Storekeeper, o => o.MapFrom(x => x.Storekeeper));
            Mapper.CreateMap<CuttingOrderDto, CuttingOrder>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.AssumeDate, o => o.MapFrom(x => x.AssumeDate))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                  .ForMember(x => x.DateDocumentIntegration, o => o.MapFrom(x => x.DateDocumentIntegration))
                  .ForMember(x => x.Department, o => o.MapFrom(x => x.Department))
                  .ForMember(x => x.District, o => o.MapFrom(x => x.District))
                  .ForMember(x => x.Inspector, o => o.MapFrom(x => x.Inspector))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Priority, o => o.MapFrom(x => x.Priority))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.Specifications, o => o.MapFrom(x => x.Specifications))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.Storekeeper, o => o.MapFrom(x => x.Storekeeper));
        }

        private void CreateCuttingOrderMove()
        {
            Mapper.CreateMap<CuttingOrderMove, CuttingOrderMoveDto>();
            Mapper.CreateMap<CuttingOrderMoveDto, CuttingOrderMove>()
                  .IgnoreAllNonExisting();
        }
        private void CreateCuttingOrderSpecification()
        {
            Mapper.CreateMap<CuttingOrderSpecification, CuttingOrderSpecificationDto>();
            Mapper.CreateMap<CuttingOrderSpecificationDto, CuttingOrderSpecification>()
                .IgnoreAllNonExisting();
        }
        private void CreateSample()
        {
            Mapper.CreateMap<Sample, SampleDto>();
            Mapper.CreateMap<SampleDto, Sample>()
                .IgnoreAllNonExisting();
        }
        private void CreateSampleCertification()
        {
            Mapper.CreateMap<SampleCertification, SampleCertificationDto>();
            Mapper.CreateMap<SampleCertificationDto, SampleCertification>()
                .IgnoreAllNonExisting();
        }
        private void CreateCertification()
        {
            Mapper.CreateMap<Certification, CertificationDto>();
            Mapper.CreateMap<CertificationDto, Certification>()
                .IgnoreAllNonExisting();
        }

    }
}
