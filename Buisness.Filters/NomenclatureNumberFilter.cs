// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatureNumberFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    /// <summary>
    ///     The nomenclature number filter.
    /// </summary>
    public class NomenclatureNumberFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static NomenclatureNumberFilter Default
        {
            get { return new NomenclatureNumberFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}