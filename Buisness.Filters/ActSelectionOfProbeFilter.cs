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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Filtering.Infrastructure;
    using Halfblood.Common;

    /// <summary>
    ///     The act selection of probe destination filter.
    /// </summary>
    public class ActSelectionOfProbeFilter : IUserFilter<long>
    {
        private static long _rn;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActSelectionOfProbeFilter" /> class.
        /// </summary>
        public ActSelectionOfProbeFilter()
        {
            CreationDate = new Between<DateTime?>();
            State = new List<ActSelectionOfProbeState>();
            CertificateQualityFilter = CertificateQualityFilter.Default;
        }

  

        object IHasUid.Rn { get { return Rn; } }
        public CertificateQualityFilter CertificateQualityFilter { get; set; }
        public long  RnDepartmentCreator { get; set; }
        public Between<DateTime?> CreationDate { get; set; }
        public IList<ActSelectionOfProbeState> State { get; set; }
        
        public static ActSelectionOfProbeFilter Default
        {
            get { return new ActSelectionOfProbeFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}