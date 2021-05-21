namespace Buisness.Filters
{
    using Halfblood.Common;
    using System.ComponentModel;
    using Filtering.Infrastructure;
    using System;

    public class AdditionalDictionaryValuesFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string StringValue { get; set; }
        public decimal? NumValue { get; set; }
        public DateTime? DateValue { get; set; }
        public string Note { get; set; }

        public static AdditionalDictionaryValuesFilter Default
        {
            get { return new AdditionalDictionaryValuesFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}