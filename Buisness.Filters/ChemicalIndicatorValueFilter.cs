// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChemicalIndicatorValueFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ChemicalIndicatorValueFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System.ComponentModel;

    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class ChemicalIndicatorValueFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Value { get; set; }
        public CertificateQualityFilter CertificateQuality { get; set; }
        public DictionaryChemicalIndicatorFilter ChemicalIndicator { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static ChemicalIndicatorValueFilter Default
        {
            get { return new ChemicalIndicatorValueFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}