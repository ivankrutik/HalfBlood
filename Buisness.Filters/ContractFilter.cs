namespace Buisness.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Buisness.Entities.CommonDomain;
    using Filtering.Infrastructure;
    using Halfblood.Common;

    public class ContractFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Pref { get; set; }
        public string Numb { get; set; }
        public Between<DateTime> DocDate { get; set; }
        public Between<DateTime?> RegDate { get; set; }
        public ContractStatusState State { get; set; }
        public Between<DateTime?> ConfirmDate { get; set; }
        public Between <DateTime?> CloseDate { get; set; }
        public Between <DateTime> BeginDate { get; set; }
        public Between<DateTime?> EndDate { get; set; }
        public UserDto Contaractor { get; set; }

        public StagesOfTheContractFilter StagesOfTheContract { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}