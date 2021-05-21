// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderProfile.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;

    using Buisness.Entities.DepartmentOrderDomain;
    using Halfblood.Common.Mappers;

    using Entities.DepartmentOrderDomain;

    [AutoMapperProfile]
    public class DepartmentOrderProfile : Profile
    {
        /// <summary>
        /// The configure.
        /// </summary>
        protected override void Configure()
        {
            CreateDepartmentOrder();
            CreateDepartmentOrderSpecification();
            CreateDepartmentOrderComment();
        }


        private void CreateDepartmentOrderComment()
        {
            Mapper.CreateMap<DepartmentOrderComment, DepartmentOrderCommentDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.DepartmentOrder, o => o.MapFrom(x => x.DepartmentOrder))
                .ForMember(x => x.Comment, o => o.MapFrom(x => x.Comment))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
            Mapper.CreateMap<DepartmentOrderCommentDto, DepartmentOrderComment>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.DepartmentOrder, o => o.MapFrom(x => x.DepartmentOrder))
                .ForMember(x => x.Comment, o => o.MapFrom(x => x.Comment))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
        }
        private void CreateDepartmentOrderSpecification()
        {
            Mapper.CreateMap<DepartmentOrderSpecification, DepartmentOrderSpecifacationDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.DepartmentOrder, o => o.MapFrom(x => x.DepartmentOrder))
                  .ForMember(x => x.Quantity, o => o.MapFrom(x => x.Quantity))
                  .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<DepartmentOrderSpecifacationDto, DepartmentOrderSpecification>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.DepartmentOrder, o => o.MapFrom(x => x.DepartmentOrder))
                  .ForMember(x => x.Quantity, o => o.MapFrom(x => x.Quantity))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
        private void CreateDepartmentOrder()
        {
            Mapper.CreateMap<DepartmentOrder, DepartmentOrderDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.Admitted, o => o.MapFrom(x => x.Admitted))
                  .ForMember(x => x.ClosedRequirement, o => o.MapFrom(x => x.ClosedRequirement))
                  .ForMember(x => x.Comments, o => o.MapFrom(x => x.Comments))
                  .ForMember(x => x.ConfirmedQuantity, o => o.MapFrom(x => x.ConfirmedQuantity))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Matching, o => o.MapFrom(x => x.Matching))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Priority, o => o.MapFrom(x => x.Priority))
                  .ForMember(x => x.RequestedQuantity, o => o.MapFrom(x => x.RequestedQuantity))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.Specifications, o => o.MapFrom(x => x.Specifications))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.WantDateCreate, o => o.MapFrom(x => x.WantDateCreate))
                  .ForMember(x => x.WarehouseReceiver, o => o.MapFrom(x => x.WarehouseReceiver))
                  .ForMember(x => x.WarehouseSource, o => o.MapFrom(x => x.WarehouseSource));
            Mapper.CreateMap<DepartmentOrderDto, DepartmentOrder>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                       .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.Admitted, o => o.MapFrom(x => x.Admitted))
                  .ForMember(x => x.ClosedRequirement, o => o.MapFrom(x => x.ClosedRequirement))
                  .ForMember(x => x.Comments, o => o.MapFrom(x => x.Comments))
                  .ForMember(x => x.ConfirmedQuantity, o => o.MapFrom(x => x.ConfirmedQuantity))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Matching, o => o.MapFrom(x => x.Matching))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Priority, o => o.MapFrom(x => x.Priority))
                  .ForMember(x => x.RequestedQuantity, o => o.MapFrom(x => x.RequestedQuantity))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.Specifications, o => o.MapFrom(x => x.Specifications))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.Material, o => o.MapFrom(x => x.Material))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.WantDateCreate, o => o.MapFrom(x => x.WantDateCreate))
                  .ForMember(x => x.WarehouseReceiver, o => o.MapFrom(x => x.WarehouseReceiver))
                  .ForMember(x => x.WarehouseSource, o => o.MapFrom(x => x.WarehouseSource));
        }

    }
}
