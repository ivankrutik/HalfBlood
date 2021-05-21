// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActSelectionOfProbe.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ActSelectionOfProbe type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain
{
    using Halfblood.Common;

    using System;
    using System.Collections.Generic;

    public class ActSelectionOfProbeLiteDto : IDto<long>
    {
        public virtual long Rn { get; set; }
        public virtual long Crn { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual long? RnDepartmentCreator { get; set; }
        public virtual string MemoDepartmentCreator { get; set; }
        public virtual long? RnControlerOTK { get; set; }
        public virtual string ControlerOTK { get; set; }
        public virtual string MemoControlerOTK { get; set; }
        public virtual DateTime? ControlerOTKDate { get; set; }
        public virtual long RnCreator { get; set; }
        public virtual string Creator { get; set; }
        public virtual string MemoCreator { get; set; }
        public virtual string Sample { get; set; }
        public virtual string Note { get; set; }
        public virtual ActSelectionOfProbeState State { get; set; }
        public virtual IList<ActSelectionOfProbeDepartmentLiteDto> ActSelectionOfProbeDepartments { get; set; }

        public virtual long RnCertificate { get; set; }
        public virtual string NumbCertificate { get; set; }
        public virtual string FullRepresentattion { get; set; }
        public virtual string Cast { get; set; }

        object IHasUid.Rn { get { return Rn; } }
    }
}
