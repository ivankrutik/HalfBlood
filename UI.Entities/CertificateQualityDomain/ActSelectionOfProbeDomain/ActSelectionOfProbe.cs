// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbe.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe destination.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using System;
    using System.Collections.Generic;
    using UI.Entities.CommonDomain;
    using ReactiveUI;
    using Halfblood.Common;

    /// <summary>
    /// The act selection of probe destination.
    /// </summary>
    public class ActSelectionOfProbe : EntityBase<ActSelectionOfProbe>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbe"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActSelectionOfProbe(long rn)
            : this()
        {
            Rn = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbe"/> class.
        /// </summary>
        public ActSelectionOfProbe()
        {
            ActSelectionOfProbeDepartments = new ReactiveList<ActSelectionOfProbeDepartment>();
        }

        public long Rn { get; set; }
        public DateTime? CreationDate { get; set; }
        public StaffingDivision DepartmentCreator { get; set; }
        public User Creator { get; set; }
        public string Sample { get; set; }
        public User Controler { get; set; }
        public DateTime? ControlerDate { get; set; }
        public string Note { get; set; }
        public ActSelectionOfProbeState State { get; set; }
        public IList<ActSelectionOfProbeDepartment> ActSelectionOfProbeDepartments { get; set; }
    }
}
