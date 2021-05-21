// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using AutoMapper;

    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;

    /// <summary>
    /// The act selection of probe profile.
    /// </summary>
    [AutoMapperProfile]
    public class ActSelectionOfProbeProfile : Profile
    {
        /// <summary>
        /// The configure.
        /// </summary>
        protected override void Configure()
        {
            CreateActSelectionOfProbe();
            CreateActSelectionOfProbeDepartment();
            CreateActSelectionOfProbeDepartmentRequirementDto();
        }

        private void CreateActSelectionOfProbeDepartmentRequirementDto()
        {
            Mapper.CreateMap<ActSelectionOfProbeDepartmentRequirement, ActSelectionOfProbeDepartmentRequirementDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.ActSelectionOfProbeDepartment, o => o.MapFrom(x => x.ActSelectionOfProbeDepartment))
                .ForMember(x => x.Requirement, o => o.MapFrom(x => x.Requirement));



            Mapper.CreateMap<ActSelectionOfProbeDepartmentRequirementDto, ActSelectionOfProbeDepartmentRequirement>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.ActSelectionOfProbeDepartment, o => o.MapFrom(x => x.ActSelectionOfProbeDepartment))
                .ForMember(x => x.Requirement, o => o.MapFrom(x => x.Requirement));


        }

        private void CreateActSelectionOfProbe()
        {
            Mapper.CreateMap<ActSelectionOfProbe, ActSelectionOfProbeDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Controler, o => o.MapFrom(x => x.Controler))
                .ForMember(x => x.ControlerDate, o => o.MapFrom(x => x.ControlerDate))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.DepartmentCreator, o => o.MapFrom(x => x.DepartmentCreator))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Sample, o => o.MapFrom(x => x.Sample))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<ActSelectionOfProbeDto, ActSelectionOfProbe>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Controler, o => o.MapFrom(x => x.Controler))
                .ForMember(x => x.ControlerDate, o => o.MapFrom(x => x.ControlerDate))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.DepartmentCreator, o => o.MapFrom(x => x.DepartmentCreator))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Sample, o => o.MapFrom(x => x.Sample))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateActSelectionOfProbeDepartment()
        {
            Mapper.CreateMap<ActSelectionOfProbeDepartment, ActSelectionOfProbeDepartmentDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.ActSelectionOfProbe, o => o.MapFrom(x => x.ActSelectionOfProbe))
                .ForMember(x => x.AgentDepartment, o => o.MapFrom(x => x.AgentDepartment))
                .ForMember(x => x.AgentDepartmentDate, o => o.MapFrom(x => x.AgentDepartmentDate))
                .ForMember(x => x.ControlerOtk, o => o.MapFrom(x => x.Controler))
                .ForMember(x => x.ControlerOtkDate, o => o.MapFrom(x => x.ControlerDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.Customer, o => o.MapFrom(x => x.Customer))
                .ForMember(x => x.CustomerDate, o => o.MapFrom(x => x.CustomerDate))
                .ForMember(x => x.DateCreate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Quantity, o => o.MapFrom(x => x.Quantity))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.DepartmentReceiver, o => o.MapFrom(x => x.DepartmentReceiver))
                .ForMember(x => x.Receiver, o => o.MapFrom(x => x.Receiver))
                .ForMember(x => x.QuantityReceiver, o => o.MapFrom(x => x.QuantityReceiver))
                .ForMember(x => x.DepartmentMakingSample, o => o.MapFrom(x => x.DepartmentMakingSample))
                .ForMember(x => x.ReceiverDate, o => o.MapFrom(x => x.ReceiverDate));
            Mapper.CreateMap<ActSelectionOfProbeDepartmentDto, ActSelectionOfProbeDepartment>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.ActSelectionOfProbe, o => o.MapFrom(x => x.ActSelectionOfProbe))
                .ForMember(x => x.AgentDepartment, o => o.MapFrom(x => x.AgentDepartment))
                .ForMember(x => x.AgentDepartmentDate, o => o.MapFrom(x => x.AgentDepartmentDate))
                .ForMember(x => x.Controler, o => o.MapFrom(x => x.ControlerOtk))
                .ForMember(x => x.ControlerDate, o => o.MapFrom(x => x.ControlerOtkDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.Customer, o => o.MapFrom(x => x.Customer))
                .ForMember(x => x.CustomerDate, o => o.MapFrom(x => x.CustomerDate))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.DateCreate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Quantity, o => o.MapFrom(x => x.Quantity))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.DepartmentReceiver, o => o.MapFrom(x => x.DepartmentReceiver))
                .ForMember(x => x.Receiver, o => o.MapFrom(x => x.Receiver))
                .ForMember(x => x.QuantityReceiver, o => o.MapFrom(x => x.QuantityReceiver))
                .ForMember(x => x.DepartmentMakingSample, o => o.MapFrom(x => x.DepartmentMakingSample))
                .ForMember(x => x.ReceiverDate, o => o.MapFrom(x => x.ReceiverDate));
        }
    }
}

