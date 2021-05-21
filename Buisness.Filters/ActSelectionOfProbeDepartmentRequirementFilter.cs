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
    public class ActSelectionOfProbeDepartmentRequirementFilter : IUserFilter<long>
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActSelectionOfProbeDepartmentRequirementFilter" /> class.
        /// </summary>
        public ActSelectionOfProbeDepartmentRequirementFilter()
        {
           
        }

  

        object IHasUid.Rn { get { return Rn; } }


        public static ActSelectionOfProbeDepartmentRequirementFilter Default
        {
            get { return new ActSelectionOfProbeDepartmentRequirementFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}