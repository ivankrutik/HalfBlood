// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDestinationFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActSelectionOfProbeDestinationFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Filters
{
    using System.ComponentModel;
    using Filtering.Infrastructure;
    using Halfblood.Common;

    /// <summary>
    ///     The act selection of probe destination filter.
    /// </summary>
    public class ActSelectionOfProbeDepartmentFilter : IUserFilter<long>
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActSelectionOfProbeDepartmentFilter" /> class.
        /// </summary>
        public ActSelectionOfProbeDepartmentFilter()
        {
           
        }

  

        object IHasUid.Rn { get { return Rn; } }


        public static ActSelectionOfProbeDepartmentFilter Default
        {
            get { return new ActSelectionOfProbeDepartmentFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}