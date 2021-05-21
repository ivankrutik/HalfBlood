// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbeViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act selection of probe view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using Halfblood.Common;
    using System.Collections.Generic;
    using System;

    public partial class ActSelectionOfProbeDepartmentLiteDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long Rn { get; set; }
        public virtual long Crn { get; set; }
        public virtual long RnCreator { get; set; }
        public virtual string Creator { get; set; }
        public virtual string MemoCreator { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string MemoControlerOTK { get; set; }
        public virtual long? RnControlerOTK { get; set; }
        public virtual DateTime? ControlerOTKDate { get; set; }
        public virtual string ControlerOTK { get; set; }
        public virtual long? RnCustomer { get; set; }
        public virtual string MemoCustomer { get; set; }
        public virtual string Customer { get; set; }
        public virtual DateTime? CustomerDate { get; set; }
        public virtual long? RnAgentDepartment { get; set; }
        public virtual string AgentDepartment { get; set; }
        public virtual string MemoAgentDepartment { get; set; }
        public virtual DateTime? AgentDdepartmentDate { get; set; }
        public virtual long? RnDepartmentMakingSample { get; set; }
        public virtual string DepartmentMakingSample { get; set; }
        public virtual long? Quantity { get; set; }
        public virtual string Note { get; set; }
        public virtual long? RnDepartmentReceiver { get; set; }
        public virtual string DepartmentReceiver { get; set; }
        public virtual long? RnReceiver { get; set; }
        public virtual string Receiver { get; set; }
        public virtual DateTime? ReceiverDate { get; set; }
        public virtual long? QunatityReceiver { get; set; }

        public virtual IList<ActSelectionOfProbeDepartmentRequirementLiteDto> ActSelectionOfProbeDepartmentRequirements { get; set; }
        public virtual ActSelectionOfProbeLiteDto ActSelectionOfProbe { get; set; }
    }
}
