namespace Buisness.Filters
{
    using Halfblood.Common;
    using System.ComponentModel;
    using Filtering.Infrastructure;


    public class AdditionalDictionaryFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public  string Code { get; set; }
        public  string Name { get; set; }

        public AdditionalDictionaryValuesFilter AdditionalDictionaryValues { get; set; }
        

        public static AdditionalDictionaryFilter Default
        {
            get { return new AdditionalDictionaryFilter
            {
                AdditionalDictionaryValues =  AdditionalDictionaryValuesFilter.Default
            }; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}