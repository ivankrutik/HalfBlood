// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CuttingOrderProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings.CuttingOrderDomain
{
    using AutoMapper;
    using Buisness.Entities.CuttingOrderDomain;
    using Halfblood.Common.Mappers;

    using ParusModelLite.CuttingOrderDomain;

    using Entities.CuttingOrderDomain;

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
            Mapper.CreateMap<CuttingOrder, CuttingOrderDto>();
            Mapper.CreateMap<CuttingOrderDto, CuttingOrder>();

            Mapper.CreateMap<CuttingOrder, CuttingOrderLiteDto>();
            Mapper.CreateMap<CuttingOrderLiteDto, CuttingOrder>();
        }
        private void CreateCuttingOrderMove()
        {
            Mapper.CreateMap<CuttingOrderMove, CuttingOrderMoveDto>();
            Mapper.CreateMap<CuttingOrderMoveDto, CuttingOrderMove>();
        }
        private void CreateCuttingOrderSpecification()
        {
            Mapper.CreateMap<CuttingOrderSpecification, CuttingOrderSpecificationDto>();
            Mapper.CreateMap<CuttingOrderSpecificationDto, CuttingOrderSpecification>();
        }
        private void CreateSample()
        {
            Mapper.CreateMap<Sample, SampleDto>();
            Mapper.CreateMap<SampleDto, Sample>();
        }
        private void CreateSampleCertification()
        {
            Mapper.CreateMap<SampleCertification, SampleCertificationDto>();
            Mapper.CreateMap<SampleCertificationDto, SampleCertification>();
        }
        private void CreateCertification()
        {
            Mapper.CreateMap<Certification, CertificationDto>();
            Mapper.CreateMap<CertificationDto, Certification>();
        }
    }
}
