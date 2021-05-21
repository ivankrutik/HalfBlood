namespace Buisness.Filters
{
    using System;
    using System.ComponentModel;
    using Filtering.Infrastructure;
    using Halfblood.Common;

    public class WarehouseQualityCertificateRestFilter : IUserFilter<long>
    {
        object IHasUid.Rn
        {
            get { return Rn; }
        }

        public long Acatalog { get; set; }

        public UserFilter UserCreator { get; set; }
        public Between<DateTime> CreationDate { get; set; }
        public decimal Numb { get; set; }
        public string Pref { get; set; }
        public WarehouseQualityCertificateState State { get; set; }
        public Between<DateTime> StateDate { get; set; }
        public string Note { get; set; }
        public UserFilter Storekeeper { get; set; }
        public Between<DateTime> StorekeeperDate { get; set; }
        public string Marka { get; set; }
        public string Cast { get; set; }
        public string FullRepresentation { get; set; }
        public string GostMarka { get; set; }
        public string GostMix { get; set; }
        public string Mix { get; set; }
        public long RNCertificateQuality { get; set; }
        public static CertificationFilter Default
        {
            get { return new CertificationFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}