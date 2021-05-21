// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyFilter.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The empty filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    /// <summary>
    ///     The empty filter.
    /// </summary>
    public class EmptyFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public static EmptyFilter Empty = new EmptyFilter();
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}