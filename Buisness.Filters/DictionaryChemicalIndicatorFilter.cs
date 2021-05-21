// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryChemicalIndicatorFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryChemicalIndicatorFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    public class DictionaryChemicalIndicatorFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual CatalogFilter Catalog { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual ChemicalIndicatorValueFilter ChemicalIndicatorValues { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static DictionaryChemicalIndicatorFilter Default
        {
            get { return new DictionaryChemicalIndicatorFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}