// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiremensFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The requiremens filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using Filtering.Infrastructure;

namespace Buisness.Filters
{
    using Halfblood.Common;

    /// <summary>
    ///     The requiremens filter.
    /// </summary>
    public class RequiremensFilter : IUserFilter<long>
    {
        object IHasUid.Rn { get { return Rn; } }

        public long Rn { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public string Requirements { get; set; }

        public long MakingSample { get; set; }

        public static RequiremensFilter Default
        {
            get { return new RequiremensFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}