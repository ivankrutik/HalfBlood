// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ContractProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.ContractDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.ContractDomain;

    /// <summary>
    /// The contract profile.
    /// </summary>
    [AutoMapperProfile]
    public class ContractProfile : Profile
    {
        protected override void Configure()
        {
            CreateContract();
            CreateStagesOfTheContract();
            CreatePlanAndSpecification();
        }

        private static void CreateContract()
        {
            Mapper.CreateMap<Contract, ContractDto>()
                .ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                .ForMember(x => x.CloseDate, o => o.MapFrom(x => x.CloseDate))
                .ForMember(x => x.ConfirmDate, o => o.MapFrom(x => x.ConfirmDate))
                .ForMember(x => x.ContractorAgent, o => o.MapFrom(x => x.ContractorAgent))
                .ForMember(x => x.DocDate, o => o.MapFrom(x => x.DocDate))
                .ForMember(x => x.EndDate, o => o.MapFrom(x => x.EndDate))
                //.ForMember(x => x.ExtNumber, o => o.MapFrom(x => x.ExtNumber))
                .ForMember(x => x.Numb , o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.RegDate, o => o.MapFrom(x => x.RegDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StagesOfTheContracts, o => o.MapFrom(x => x.Stages))
                .ForMember(x => x.Status, o => o.MapFrom(x => x.State));

            Mapper.CreateMap<ContractDto, Contract>()
                   .ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                .ForMember(x => x.CloseDate, o => o.MapFrom(x => x.CloseDate))
                .ForMember(x => x.ConfirmDate, o => o.MapFrom(x => x.ConfirmDate))
                .ForMember(x => x.ContractorAgent, o => o.MapFrom(x => x.ContractorAgent))
                .ForMember(x => x.DocDate, o => o.MapFrom(x => x.DocDate))
                .ForMember(x => x.EndDate, o => o.MapFrom(x => x.EndDate))
                //.ForMember(x => x.ExtNumber, o => o.MapFrom(x => x.ExtNumber))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.RegDate, o => o.MapFrom(x => x.RegDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Stages, o => o.MapFrom(x => x.StagesOfTheContracts))
                .ForMember(x => x.State, o => o.MapFrom(x => x.Status));
        }
        private static void CreateStagesOfTheContract()
        {
            Mapper.CreateMap<Stage, StagesOfTheContractDto>();
            Mapper.CreateMap<StagesOfTheContractDto, Stage>()
                .IgnoreAllNonExisting();
        }
        private static void CreatePlanAndSpecification()
        {
            Mapper.CreateMap<PlanAndSpecification, PlanAndSpecificationDto>()
                 .ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                 .ForMember(x => x.EndDate, o => o.MapFrom(x => x.EndDate))
                 .ForMember(x => x.FactQuant, o => o.MapFrom(x => x.FactQuant))
                 .ForMember(x => x.FactSum, o => o.MapFrom(x => x.FactSum))
                 .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                 .ForMember(x => x.NomenclatureNumber, o => o.MapFrom(x => x.NomenclatureNumber))
                 .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                 .ForMember(x => x.PlanQuant, o => o.MapFrom(x => x.PlanQuant))
                 .ForMember(x => x.PlanSum, o => o.MapFrom(x => x.PlanSum))
                 .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                 .ForMember(x => x.Quant, o => o.MapFrom(x => x.Quant))
                 .ForMember(x => x.PlanSum, o => o.MapFrom(x => x.PlanSum))
                 .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                 .ForMember(x => x.SumWithNds, o => o.MapFrom(x => x.SumWithNds))
                 .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta))
                 .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand));
            Mapper.CreateMap<PlanAndSpecificationDto, PlanAndSpecification>()
                .ForMember(x => x.BeginDate, o => o.MapFrom(x => x.BeginDate))
                 .ForMember(x => x.EndDate, o => o.MapFrom(x => x.EndDate))
                 .ForMember(x => x.FactQuant, o => o.MapFrom(x => x.FactQuant))
                 .ForMember(x => x.FactSum, o => o.MapFrom(x => x.FactSum))
                 .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                 .ForMember(x => x.NomenclatureNumber, o => o.MapFrom(x => x.NomenclatureNumber))
                 .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                 .ForMember(x => x.PlanQuant, o => o.MapFrom(x => x.PlanQuant))
                 .ForMember(x => x.PlanSum, o => o.MapFrom(x => x.PlanSum))
                 .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                 .ForMember(x => x.Quant, o => o.MapFrom(x => x.Quant))
                 .ForMember(x => x.PlanSum, o => o.MapFrom(x => x.PlanSum))
                 .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                 .ForMember(x => x.SumWithNds, o => o.MapFrom(x => x.SumWithNds))
                 .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta))
                 .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand));
        }
    }
}
