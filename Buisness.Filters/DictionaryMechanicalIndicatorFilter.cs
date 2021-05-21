// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMechanicalIndicatorFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryMechanicalIndicatorFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class DictionaryMechanicalIndicatorFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public CatalogFilter Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MechanicIndicatorValueFilter MechanicIndicatorValues { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static DictionaryMechanicalIndicatorFilter Default
        {
            get { return new DictionaryMechanicalIndicatorFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}