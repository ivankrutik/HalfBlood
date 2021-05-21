// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Buisness.Filters
{
    using System;
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    using System.Collections.Generic;

    public class CertificateQualityFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long RnWareHouse { get; set; }
        public string Cast { get; set; }
        public PlanCertificateFilter PlanCertificate { get; set; }
        public Between<DateTime> CreationDate { get; set; }
        public UserFilter CreatorFactory { get; set; }
        public string DeliveryCondition { get; set; }
        public string FullRepresentation { get; set; }
        public string GostMarka { get; set; }
        public string GostMix { get; set; }
        public Between<DateTime> MakingDate { get; set; }
        public string Marka { get; set; }
        public string Mix { get; set; }
        public string ModeThermoTreatment { get; set; }
        public string NomerCertificata { get; set; }
        public string Note { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public string StandardSize { get; set; }
        public Between<DateTime> StorageDate { get; set; }
        public UserFilter UserCreator { get; set; }
        public NomenclatureNumberFilter NomenclatureNumber { get; set; }
        public IList<QualityCertificateState> State { get; set; }
        public static CertificateQualityFilter Default
        {
            get { return new CertificateQualityFilter(); }
        }

        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}