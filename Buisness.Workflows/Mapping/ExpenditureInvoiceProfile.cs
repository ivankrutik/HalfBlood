namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.ExpenditureInvoiceDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities;
    using ParusModel.Entities.Common;
    using ParusModel.Entities.ExpenditureInvoiceDomain;

    [AutoMapperProfile]
    public class ExpenditureInvoiceProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ExpenditureInvoice, ExpenditureInvoiceDto>();
            Mapper.CreateMap<ExpenditureInvoiceDto, ExpenditureInvoice>();

          
            Mapper.CreateMap<ExpenditureInvoiceSpecificationDto, ExpenditureInvoiceSpecification>();
            Mapper.CreateMap<ExpenditureInvoiceSpecification, ExpenditureInvoiceSpecificationDto>();
        }
    }
}
