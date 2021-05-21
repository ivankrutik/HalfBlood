// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeDepartment.cs" company="VZ">
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

    /// <summary>
    /// The act selection of probe destination.
    /// </summary>
    public class ActSelectionOfProbeDepartment : EntityBase<ActSelectionOfProbeDepartment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbe"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActSelectionOfProbeDepartment(long rn) : this()
        {
            Rn = rn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActSelectionOfProbe"/> class.
        /// </summary>
        public ActSelectionOfProbeDepartment()
        {
        }

        public  ActSelectionOfProbe ActSelectionOfProbe { get; set; }
        public  long Rn { get; set; }
        public  DateTime? CreationDate { get; set; }
        public  DateTime? ControlerDate { get; set; }
        public  DateTime? CustomerDate { get; set; }
        public  User AgentDepartment { get; set; }
        public  DateTime? AgentDepartmentDate { get; set; }
        public  User Controler { get; set; }
        public  User Customer { get; set; }
        public  User Creator { get; set; }
        public  IList<ActSelectionOfProbeDepartmentRequirement> ActSelectionOfProbeDepartmentRequirements { get; set; }
        public  string NameSectionOfSystem { get; protected set; }
        public  decimal? Quantity { get; set; }
        public  string Note { get; set; }
        public  StaffingDivision DepartmentReceiver { get; set; }
        public  StaffingDivision DepartmentMakingSample { get; set; }
        public  User Receiver { get; set; }
        public  decimal? QuantityReceiver { get; set; }
        public  DateTime ReceiverDate { get; set; }
        public  string Requirements { get; set; }
    }
}
