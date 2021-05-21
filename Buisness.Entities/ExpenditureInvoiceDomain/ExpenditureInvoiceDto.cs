namespace Buisness.Entities.ExpenditureInvoiceDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;

    public class ExpenditureInvoiceDto : IDto<long>
    {
        public ExpenditureInvoiceDto()
        {
            ExpenditureInvoiceSpecifications = new List<ExpenditureInvoiceSpecificationDto>();
        }

        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual string Pref { get; set; }
        public virtual string Numb { get; set; }
        public virtual DateTime Docdate { get; set; }
        public virtual InvoiceForTransmissionInUnitState Status { get; set; }
        public virtual InvoiceForTransmissionInUnitInState InStatus { get; set; }
        public virtual DateTime WorkDate { get; set; }
        public virtual DateTime? InWorkDate { get; set; }
        public virtual DateTime? ReservDate { get; set; }
        public virtual string DirNumb { get; set; }
        public virtual DateTime? DirDate { get; set; }
        public virtual decimal CurCours { get; set; }
        public virtual decimal CurBase { get; set; }
        public virtual decimal SummWithnds { get; set; }
        public virtual decimal ServSummnds { get; set; }
        public virtual decimal? Facurcours { get; set; }
        public virtual decimal? FacurBase { get; set; }
        public virtual decimal? InCurcours { get; set; }
        public virtual decimal? InCurBase { get; set; }
        public virtual string ValidDocNumb { get; set; }
        public virtual DateTime? ValidDocDate { get; set; }
        public virtual string RecipNumb { get; set; }
        public virtual DateTime? RecipDate { get; set; }
        public virtual string GetConfirm { get; set; }
        public virtual string WayBladeNumb { get; set; }
        public virtual string Comment { get; set; }
        public virtual string InPartyCode { get; set; }
        public virtual CatalogDto Acatalog { get; set; }
        public virtual long? AgentCarTrailer2 { get; set; }
        public virtual long? AgentCarTrailer1 { get; set; }
        public virtual long? AgentCar { get; set; }
        public virtual long? AgnDriver { get; set; }
        public virtual StoreGasStationOilDepotDto Store { get; set; }
        public virtual StoreGasStationOilDepotDto InStore { get; set; }
        public virtual KindOfWarehouseOperationsDto Stoper { get; set; }
        public virtual KindOfWarehouseOperationsDto InStoper { get; set; }
        public virtual NameOfCurrencyDto NameOfCurrency { get; set; }
        public virtual long? Route { get; set; }
        public virtual long ViewShipment { get; set; }
        public virtual TypeOfDocumentDto TypeOfDocumentValidTypeOfDocument { get; set; }
        public virtual TypeOfDocumentDto TypeOfDocumentRecipDoc { get; set; }
        public virtual TypeOfDocumentDto TypeOfDocument { get; set; }
        public virtual TypeOfDocumentDto TypeOfDocumentDirDoc { get; set; }
        public virtual PersonalAccountDto PersonalAccount { get; set; }
        public virtual long? PointOfTheGraphAccount { get; set; }
        public virtual BatchDto Batch { get; set; }
        public virtual StaffingDivisionDto StaffingDivision { get; set; }
        public virtual LegalPersonDto LegalPerson { get; set; }
        public virtual UserDto MOL { get; set; }
        public virtual UserDto InMOL { get; set; }
        public virtual UserDto Ferryman { get; set; }
        public virtual UserDto AgnlistAgent { get; set; }
        public virtual IList<ExpenditureInvoiceSpecificationDto> ExpenditureInvoiceSpecifications { get; set; }
        public virtual string NameSectionOfSystem { get; protected set; }
        public virtual CatalogDto Catalog { get; set; }
        
    }
    }
