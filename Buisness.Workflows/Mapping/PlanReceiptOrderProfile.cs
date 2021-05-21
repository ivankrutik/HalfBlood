// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping
{
    using AutoMapper;

    using Buisness.Entities.PlanReceiptOrderDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    using System;

    /// <summary>
    /// The plan receipt order profile.
    /// </summary>
    [AutoMapperProfile]
    public class PlanReceiptOrderProfile : Profile
    {
        protected override void Configure()
        {
            CreatePlanReceiptOrder();
            CreatePlanCertificate();
            CreatePersonalAccount();
        }
        private void CreatePlanReceiptOrder()
        {
            Mapper.CreateMap<PlanReceiptOrder, PlanReceiptOrderWithoutPlanCertificateDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.GroundDocumentDate, o => o.MapFrom(x => x.GroundDocumentDate))
                .ForMember(x => x.GroundDocumentNumb, o => o.MapFrom(x => x.GroundDocumentNumb))
                .ForMember(x => x.GroundReceiptDocumentDate, o => o.MapFrom(x => x.GroundReceiptDocumentDate))
                .ForMember(x => x.GroundReceiptDocumentNumb, o => o.MapFrom(x => x.GroundReceiptDocumentNumb))
                .ForMember(x => x.GroundReceiptTypeOfDocument, o => o.MapFrom(x => x.GroundReceiptTypeOfDocument))
                .ForMember(x => x.GroundTypeOfDocument, o => o.MapFrom(x => x.GroundTypeOfDocument))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StaffingDivision, o => o.MapFrom(x => x.StaffingDivision))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                .ForMember(x => x.UserContractor, o => o.MapFrom(x => x.UserContractor))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .IgnoreAllNonExisting();
            Mapper.CreateMap<PlanReceiptOrderWithoutPlanCertificateDto, PlanReceiptOrder>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.GroundDocumentDate, o => o.MapFrom(x => x.GroundDocumentDate))
                .ForMember(x => x.GroundDocumentNumb, o => o.MapFrom(x => x.GroundDocumentNumb))
                .ForMember(x => x.GroundReceiptDocumentDate, o => o.MapFrom(x => x.GroundReceiptDocumentDate))
                .ForMember(x => x.GroundReceiptDocumentNumb, o => o.MapFrom(x => x.GroundReceiptDocumentNumb))
                .ForMember(x => x.GroundReceiptTypeOfDocument, o => o.MapFrom(x => x.GroundReceiptTypeOfDocument))
                .ForMember(x => x.GroundTypeOfDocument, o => o.MapFrom(x => x.GroundTypeOfDocument))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StaffingDivision, o => o.MapFrom(x => x.StaffingDivision))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                .ForMember(x => x.UserContractor, o => o.MapFrom(x => x.UserContractor))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));

            Mapper.CreateMap<PlanReceiptOrder, PlanReceiptOrderDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.GroundDocumentDate, o => o.MapFrom(x => x.GroundDocumentDate))
                  .ForMember(x => x.GroundDocumentNumb, o => o.MapFrom(x => x.GroundDocumentNumb))
                  .ForMember(x => x.GroundReceiptDocumentDate, o => o.MapFrom(x => x.GroundReceiptDocumentDate))
                  .ForMember(x => x.GroundReceiptDocumentNumb, o => o.MapFrom(x => x.GroundReceiptDocumentNumb))
                  .ForMember(x => x.GroundReceiptTypeOfDocument, o => o.MapFrom(x => x.GroundReceiptTypeOfDocument))
                  .ForMember(x => x.GroundTypeOfDocument, o => o.MapFrom(x => x.GroundTypeOfDocument))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.StaffingDivision, o => o.MapFrom(x => x.StaffingDivision))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                  .ForMember(x => x.UserContractor, o => o.MapFrom(x => x.UserContractor))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.PlanCertificates, o => o.MapFrom(x => x.PlanCertificates));
            Mapper.CreateMap<PlanReceiptOrderDto, PlanReceiptOrder>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.GroundDocumentDate, o => o.MapFrom(x => x.GroundDocumentDate))
                  .ForMember(x => x.GroundDocumentNumb, o => o.MapFrom(x => x.GroundDocumentNumb))
                  .ForMember(x => x.GroundReceiptDocumentDate, o => o.MapFrom(x => x.GroundReceiptDocumentDate))
                  .ForMember(x => x.GroundReceiptDocumentNumb, o => o.MapFrom(x => x.GroundReceiptDocumentNumb))
                  .ForMember(x => x.GroundReceiptTypeOfDocument, o => o.MapFrom(x => x.GroundReceiptTypeOfDocument))
                  .ForMember(x => x.GroundTypeOfDocument, o => o.MapFrom(x => x.GroundTypeOfDocument))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.StaffingDivision, o => o.MapFrom(x => x.StaffingDivision))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                  .ForMember(x => x.UserContractor, o => o.MapFrom(x => x.UserContractor))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
            .ForMember(x => x.PlanCertificates, o => o.MapFrom(x => x.PlanCertificates));
        }
        private void CreatePlanCertificate()
        {
            Mapper.CreateMap<PlanCertificate, PlanCertificateDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                  .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                  .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                  .ForMember(x => x.ModificationNomenclatureGoodsManager, o => o.MapFrom(x => x.ModificationNomenclatureGoodsManager))
                  .ForMember(x => x.NameOfCurrency, o => o.MapFrom(x => x.NameOfCurrency))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.PersonalAccounts, o => o.MapFrom(x => x.PlanReceiptOrderPersonalAccounts))
                  .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder))
                  .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.Measure, o => o.MapFrom(x => x.Measure))
                  .ForMember(x => x.SumDocumenta, o => o.MapFrom(x => x.SumDocumenta))
                  .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand))
                  .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta));
            Mapper.CreateMap<PlanCertificateDto, PlanCertificate>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                  .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                  .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                  .ForMember(x => x.ModificationNomenclatureGoodsManager, o => o.MapFrom(x => x.ModificationNomenclatureGoodsManager))
                  .ForMember(x => x.NameOfCurrency, o => o.MapFrom(x => x.NameOfCurrency))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.PlanReceiptOrderPersonalAccounts, o => o.MapFrom(x => x.PersonalAccounts))
                  .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder))
                  .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.Measure, o => o.MapFrom(x => x.Measure))
                  .ForMember(x => x.SumDocumenta, o => o.MapFrom(x => x.SumDocumenta))
                  .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand))
                  .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta));
        }
        private void CreatePersonalAccount()
        {
            Mapper.CreateMap<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));
            Mapper.CreateMap<PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto, PlanReceiptOrderPersonalAccount>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));

            Mapper.CreateMap<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountDto>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                  .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                  .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlaneCertificate))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));
            Mapper.CreateMap<PlanReceiptOrderPersonalAccountDto, PlanReceiptOrderPersonalAccount>()
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                  .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                  .ForMember(x => x.PlaneCertificate, o => o.MapFrom(x => x.PlanCertificate))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                  .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));
        }

    }
}