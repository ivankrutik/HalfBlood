namespace Buisness.Filters
{
    using Filtering.Infrastructure;
    using Halfblood.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class PermissionMaterialFilter : IUserFilter<long>
    {
        public PermissionMaterialFilter()
        {
            CreationDate = new Between<DateTime?>();
            States = new List<PermissionMaterialState>
                        {
                            PermissionMaterialState.New,
                            PermissionMaterialState.Confirming,
                            PermissionMaterialState.ConfirmingExtension,
                            PermissionMaterialState.Confirmed,
                            PermissionMaterialState.NotConfirmed,
                            PermissionMaterialState.Closed
                        };
            StateDate = new Between<DateTime?>();
            AcceptToDate = new Between<DateTime?>();
        }

        object IHasUid.Rn { get { return Rn; } }
        public Between<DateTime?> CreationDate { get; set; }
        public IList<PermissionMaterialState> States { get; set; }
        public Between<DateTime?> StateDate { get; set; }
        public Between<DateTime?> AcceptToDate { get; set; }

        public static PermissionMaterialFilter Default
        {
            get { return new PermissionMaterialFilter(); }
        }

        public long Rn { get; set; }

        public long? Rnf { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}