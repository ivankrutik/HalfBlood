// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The plan receipt order profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Halfblood.Common.Mappers;
    using ParusModelLite.PlanReceiptOrderDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan receipt order profile.
    /// </summary>
    [AutoMapperProfile]
    public class PlanReceiptOrderProfile : Profile
    {
        protected override void Configure()
        {
            CreatePlanReceiptOrder();
            CreatePlanCertificat();
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
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
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
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<PlanReceiptOrder, PlanReceiptOrderDto>();
            Mapper.CreateMap<PlanReceiptOrderDto, PlanReceiptOrder>();

            Mapper.CreateMap<PlanReceiptOrder, PlanReceiptOrderLiteDto>()
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Crn, o => o.MapFrom(x => x.Catalog.Rn))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.GroundDocDate, o => o.MapFrom(x => x.GroundDocumentDate))
                .ForMember(x => x.GroundReceiptDocDate, o => o.MapFrom(x => x.GroundReceiptDocumentDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.RnContractor, o => o.ResolveUsing(x => x.UserContractor == null ? 0 : x.UserContractor.Rn))
                .ForMember(x => x.Contractor, o => o.ResolveUsing(x => x.UserContractor == null ? string.Empty : x.UserContractor.ToString()))
                .ForMember(x => x.MemoContractor, o => o.ResolveUsing(x => x.UserContractor == null ? string.Empty : x.UserContractor.TableNumber))
                .ForMember(x => x.RnCreator, o => o.ResolveUsing(x => x.UserCreator == null ? 0 : x.UserCreator.Rn))
                .ForMember(x => x.Creator, o => o.ResolveUsing(x => x.UserCreator == null ? string.Empty : x.UserCreator.ToString()))
                .ForMember(x => x.MemoCreator, o => o.ResolveUsing(x => x.UserCreator == null ? string.Empty : x.UserCreator.TableNumber))
                .ForMember(x => x.RnDepartment, o => o.ResolveUsing(x => x.StaffingDivision == null ? 0 : x.StaffingDivision.RN))
                .ForMember(x => x.Department, o => o.ResolveUsing(x => x.StaffingDivision == null ? string.Empty : x.StaffingDivision.CODE))
                .ForMember(x => x.RnStore, o => o.ResolveUsing(x => x.StoreGasStationOilDepot == null ? 0 : x.StoreGasStationOilDepot.Rn))
                .ForMember(x => x.Store, o => o.ResolveUsing(x => x.StoreGasStationOilDepot == null ? string.Empty : x.StoreGasStationOilDepot.AzsNumber))
                .ForMember(x => x.GroundReceiptDocNumb, o => o.MapFrom(x => x.GroundReceiptDocumentNumb))
                .ForMember(x => x.GroundDocNumb, o => o.MapFrom(x => x.GroundDocumentNumb))
                .ForMember(x => x.RnGroundDocType, o => o.ResolveUsing(x => x.GroundTypeOfDocument == null ? 0 : x.GroundTypeOfDocument.Rn))
                .ForMember(x => x.RnGroundReceiptDocType, o => o.ResolveUsing(x => x.GroundReceiptTypeOfDocument == null ? 0 : x.GroundReceiptTypeOfDocument.Rn))
                .ForMember(x => x.GroundDocType, o => o.ResolveUsing(x => x.GroundTypeOfDocument == null ? string.Empty : x.GroundTypeOfDocument.DocCode))
                .ForMember(x => x.GroundReceiptDocType, o => o.ResolveUsing(x => x.GroundReceiptTypeOfDocument == null ? string.Empty : x.GroundReceiptTypeOfDocument.DocCode));
            Mapper.CreateMap<PlanReceiptOrderLiteDto, PlanReceiptOrder>()
                .AfterMap(
                    (lite, full) =>
                    {
                        if (lite.RnContractor > 0)
                        {
                            full.UserContractor = new User(lite.RnContractor)
                            {
                                TableNumber = lite.MemoContractor,
                                Firstname = lite.Contractor
                            };
                        }

                        if (lite.RnCreator > 0)
                        {
                            full.UserCreator = new User(lite.RnCreator)
                            {
                                TableNumber = lite.MemoCreator,
                                Firstname = lite.Creator
                            };
                        }

                        if (lite.RnStore > 0)
                        {
                            full.StoreGasStationOilDepot = new StoreGasStationOilDepot(lite.RnStore) { AzsName = lite.Store };
                        }

                        if (lite.RnDepartment > 0)
                        {
                            full.StaffingDivision = new StaffingDivision(lite.RnDepartment) { NAME = lite.Department };
                        }

                        if (lite.RnGroundDocType > 0)
                        {
                            full.GroundTypeOfDocument = new TypeOfDocument((long)lite.RnGroundDocType);
                        }

                        if (lite.RnGroundReceiptDocType > 0)
                        {
                            full.GroundReceiptTypeOfDocument = new TypeOfDocument((long)lite.RnGroundReceiptDocType);
                        }
                    })
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.GroundDocumentDate, o => o.MapFrom(x => x.GroundDocDate))
                .ForMember(x => x.GroundReceiptDocumentDate, o => o.MapFrom(x => x.GroundReceiptDocDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))

                .ForMember(x => x.UserCreator, o => o.Ignore())
                .ForMember(x => x.UserContractor, o => o.Ignore())
                .ForMember(x => x.StoreGasStationOilDepot, o => o.Ignore())
                .ForMember(x => x.StaffingDivision, o => o.Ignore())
                .ForMember(x => x.GroundTypeOfDocument, o => o.Ignore())
                .ForMember(x => x.GroundReceiptTypeOfDocument, o => o.Ignore())
                //                .ForMember(x => x.UserContractor.Rn, o => o.MapFrom(x => x.RnContractor))
                //                .ForMember(x => x.UserContractor.Lastname, o => o.MapFrom(x => x.Contractor))
                //                .ForMember(x => x.UserContractor.TableNumber, o => o.MapFrom(x => x.MemoContractor))
                //                .ForMember(x => x.UserCreator.Rn, o => o.MapFrom(x => x.RnCreator))
                //                .ForMember(x => x.UserCreator.Lastname, o => o.MapFrom(x => x.Creator))
                //                .ForMember(x => x.UserCreator.TableNumber, o => o.MapFrom(x => x.MemoCreator))
                //                .ForMember(x => x.StaffingDivision.RN, o => o.MapFrom(x => x.RnDepartment))
                //                .ForMember(x => x.StaffingDivision.NAME, o => o.MapFrom(x => x.InStoreGasStationOilDepot))
                //                .ForMember(x => x.WarehouseReceiver.Rn, o => o.MapFrom(x => x.RnStore))
                //                .ForMember(x => x.WarehouseReceiver.AzsName, o => o.MapFrom(x => x.Store))
                .ForMember(x => x.GroundReceiptDocumentNumb, o => o.MapFrom(x => x.GroundReceiptDocNumb))
                .ForMember(x => x.GroundDocumentNumb, o => o.MapFrom(x => x.GroundDocNumb));
            //                .ForMember(x => x.GroundTypeOfDocument.Rn, o => o.MapFrom(x => x.RnGroundDocType))
            //                .ForMember(x => x.GroundReceiptTypeOfDocument.Rn, o => o.MapFrom(x => x.RnGroundReceiptDocType));
        }
        private void CreatePlanCertificat()
        {
            Mapper.CreateMap<PlanCertificate, PlanCertificateDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.NameOfCurrency, o => o.MapFrom(x => x.NameOfCurrency))
                .ForMember(x => x.Measure, o => o.MapFrom(x => x.Measure))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.ModificationNomenclatureGoodsManager, o => o.MapFrom(x => x.ModificationNomenclatureGoodsManager))
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.SumDocumenta, o => o.MapFrom(x => x.SumDocumenta))
                .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta))
                .ForMember(x => x.PersonalAccounts, o => o.MapFrom(x => x.PersonalAccounts))
                .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder));

            Mapper.CreateMap<PlanCertificateDto, PlanCertificate>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.NameOfCurrency, o => o.MapFrom(x => x.NameOfCurrency))
                .ForMember(x => x.Measure, o => o.MapFrom(x => x.Measure))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.ModificationNomenclature, o => o.MapFrom(x => x.ModificationNomenclature))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.ModificationNomenclatureGoodsManager, o => o.MapFrom(x => x.ModificationNomenclatureGoodsManager))
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.StoreGasStationOilDepot, o => o.MapFrom(x => x.StoreGasStationOilDepot))
                .ForMember(x => x.TaxBand, o => o.MapFrom(x => x.TaxBand))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.SumDocumenta, o => o.MapFrom(x => x.SumDocumenta))
                .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta))
                .ForMember(x => x.PersonalAccounts, o => o.MapFrom(x => x.PersonalAccounts))
                .ForMember(x => x.PlanReceiptOrder, o => o.MapFrom(x => x.PlanReceiptOrder));

            Mapper.CreateMap<PlanCertificate, PlanCertificateLiteDto>()
                .ForMember(x => x.CRn, o => o.ResolveUsing(x => x.Catalog == null ? 0 : x.Catalog.Rn))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(
                    x => x.Currency,
                    o => o.ResolveUsing(x => x.NameOfCurrency == null ? string.Empty : x.NameOfCurrency.Code))
                .ForMember(
                    x => x.Measure,
                    o => o.ResolveUsing(x => x.Measure == null ? string.Empty : x.Measure.MEASMNEMO))
                .ForMember(
                    x => x.MemoCreator,
                    o => o.ResolveUsing(x => x.UserCreator == null ? string.Empty : x.UserCreator.TableNumber))
                .ForMember(
                    x => x.MemoModifNomen,
                    o =>
                    o.ResolveUsing(
                        x => x.ModificationNomenclature == null ? string.Empty : x.ModificationNomenclature.Name))
                .ForMember(
                    x => x.NomModifCode,
                    o =>
                    o.ResolveUsing(
                        x => x.ModificationNomenclature == null ? string.Empty : x.ModificationNomenclature.Code))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
                .ForMember(x => x.Prn, o => o.ResolveUsing(x => x.PlanReceiptOrder == null ? 0 : x.PlanReceiptOrder.Rn))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.RnCreator, o => o.ResolveUsing(x => x.UserCreator == null ? 0 : x.UserCreator.Rn))
                .ForMember(
                    x => x.RnCurrency,
                    o => o.ResolveUsing(x => x.NameOfCurrency == null ? 0 : x.NameOfCurrency.Rn))
                .ForMember(x => x.RnMeasure, o => o.ResolveUsing(x => x.Measure == null ? 0 : x.Measure.Rn))
                .ForMember(
                    x => x.RnModifNomName,
                    o => o.ResolveUsing(x => x.ModificationNomenclature == null ? 0 : x.ModificationNomenclature.Rn))
                .ForMember(
                    x => x.RnModifNomNameTov,
                    o =>
                    o.ResolveUsing(
                        x =>
                        x.ModificationNomenclatureGoodsManager == null ? 0 : x.ModificationNomenclatureGoodsManager.Rn))
                .ForMember(
                    x => x.RnQualityCertificate,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? 0 : x.CertificateQuality.Rn))
                .ForMember(
                    x => x.RnStore,
                    o => o.ResolveUsing(x => x.StoreGasStationOilDepot == null ? 0 : x.StoreGasStationOilDepot.Rn))
                .ForMember(x => x.RnTaxBand, o => o.ResolveUsing(x => x.TaxBand == null ? 0 : x.TaxBand.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(
                    x => x.Store,
                    o =>
                    o.ResolveUsing(
                        x => x.StoreGasStationOilDepot == null ? string.Empty : x.StoreGasStationOilDepot.AzsName))
                .ForMember(x => x.SumDocumenta, o => o.MapFrom(x => x.SumDocumenta))
                .ForMember(x => x.SumWithTaxDocumenta, o => o.MapFrom(x => x.SumWithTaxDocumenta))
                .ForMember(x => x.TaxBand, o => o.ResolveUsing(x => x.TaxBand == null ? string.Empty : x.TaxBand.Name))
                .ForMember(
                    x => x.Cast,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.Cast))
                .ForMember(
                    x => x.FullRepresentation,
                    o =>
                    o.ResolveUsing(
                        x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.FullRepresentation))
                .ForMember(
                    x => x.GostCast,
                    o =>
                    o.ResolveUsing(x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.GostCast))
                .ForMember(
                    x => x.GostMix,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.GostMix))
                .ForMember(
                    x => x.MakingDate,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? null : x.CertificateQuality.MakingDate))
                .ForMember(
                    x => x.Numb,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? null : x.CertificateQuality.Numb))
                .ForMember(
                    x => x.NomerCertificata,
                    o =>
                    o.ResolveUsing(
                        x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.NumberOfCertificate))
                .ForMember(
                    x => x.Mix,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.Mix))
                .ForMember(
                    x => x.CreatorFactory,
                    o =>
                    o.ResolveUsing(
                        x =>
                        x.CertificateQuality == null || x.CertificateQuality.CreatorFactory == null
                            ? string.Empty
                            : x.CertificateQuality.CreatorFactory.ToString()))
                .ForMember(
                    x => x.StorageDate,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? null : x.CertificateQuality.StorageDate))
                .ForMember(
                    x => x.Sizes,
                    o => o.ResolveUsing(x => x.CertificateQuality == null ? string.Empty : x.CertificateQuality.Sizes));
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
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.Creator))
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
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));

            Mapper.CreateMap<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));
            Mapper.CreateMap<PlanReceiptOrderPersonalAccountDto, PlanReceiptOrderPersonalAccount>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.PersonalAccount, o => o.MapFrom(x => x.PersonalAccount))
                .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserSetState, o => o.MapFrom(x => x.UserSetState));

            Mapper.CreateMap<PersonalAccountOfPlanReceiptOrderLiteDto, PlanReceiptOrderPersonalAccount>()
                .AfterMap(
                    (lite, full) =>
                    {
                        if (lite.RnCreator > 0)
                        {
                            full.Creator = new User(lite.RnCreator) { OrganizationName = lite.Creator, TableNumber = lite.MemoCreator };
                        }

                        if (lite.RnPersonalAccount > 0)
                        {
                            full.PersonalAccount = new PersonalAccount(lite.RnPersonalAccount) { Numb = lite.PersonalAccount };
                        }

                        if (lite.PRn > 0)
                        {
                            full.PlanCertificate = new PlanCertificate(lite.PRn);
                        }

                        if (lite.CRn > 0)
                        {
                            full.Catalog = new Catalog(lite.CRn);
                        }

                        if (lite.RnAgentState > 0)
                        {
                            full.UserSetState = new User((long)lite.RnAgentState) { OrganizationName = lite.AgentState, TableNumber = lite.MemoAgentState };
                        }
                    })
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                
                .ForMember(x => x.Creator, o => o.Ignore())
                .ForMember(x => x.UserSetState, o => o.Ignore())
                .ForMember(x => x.PersonalAccount, o => o.Ignore())
                .ForMember(x => x.PlanCertificate, o => o.Ignore())
                .ForMember(x => x.Catalog, o => o.Ignore());

            Mapper.CreateMap<PlanReceiptOrderPersonalAccount, PersonalAccountOfPlanReceiptOrderLiteDto>()
                .ForMember(x => x.CRn, o => o.ResolveUsing(x => x.Catalog == null ? 0 : x.Catalog.Rn))
                .ForMember(x => x.PRn, o => o.ResolveUsing(x => x.PlanCertificate == null ? 0 : x.PlanCertificate.Rn))
                .ForMember(x => x.CountByDocument, o => o.MapFrom(x => x.CountByDocument))
                .ForMember(x => x.CountFact, o => o.MapFrom(x => x.CountFact))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
               
                .ForMember(x => x.RnCreator, o => o.ResolveUsing(x => x.Creator == null ? 0 : x.Creator.Rn))
                .ForMember(x => x.Creator, o => o.ResolveUsing(x => x.Creator == null ? null : x.Creator.OrganizationName))
                .ForMember(x => x.MemoCreator, o => o.ResolveUsing(x => x.Creator == null ? null : x.Creator.TableNumber))

                .ForMember(x => x.RnPersonalAccount, o => o.ResolveUsing(x => x.PersonalAccount == null ? 0 : x.PersonalAccount.Rn))
                .ForMember(x => x.PersonalAccount, o => o.ResolveUsing(x => x.PersonalAccount == null ? null : x.PersonalAccount.Numb))
                
                .ForMember(x => x.RnAgentState, o => o.ResolveUsing(x => x.UserSetState == null ? 0 : x.UserSetState.Rn))
                .ForMember(x => x.MemoAgentState, o => o.ResolveUsing(x => x.UserSetState == null ? null : x.UserSetState.TableNumber))
                .ForMember(x => x.AgentState, o => o.ResolveUsing(x => x.UserSetState == null ? null : x.UserSetState.OrganizationName));
        }
    }
}
