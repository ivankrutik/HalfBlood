// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ActInputControlDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class ActInputControlDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual long CRN { get; set; }
        public virtual string ViewTareStamp { get; set; }
        public virtual DateTime? OpenningTareDate { get; set; }
        public virtual DateTime? ControlerTareDate { get; set; }
        public virtual ActInputControlState State { get; set; }
        public virtual string Note { get; set; }
        //public virtual Company Company { get; set; }
        public virtual UserDto ControlerTare { get; set; }
        public virtual UserDto ManagerStoreAct { get; set; }
        public virtual UserDto ManagerStoreTare { get; set; }
        public virtual IList<TheMoveActDto> TheMoveActs { get; set; }
        public virtual IList<ConclusionDto> Conclusions { get; set; }
        public virtual IList<QualityStateControlOfTheMakeDto> QualityStateControlOfTheMakes { get; set; }
        public virtual IList<SolutionByNoteDto> SolutionByNotes { get; set; }
        public virtual IList<ActInputControlTechnicalStateDto> ActInputControlTechnicalStates { get; set; }
        public virtual IList<ActInputControlFunctioningDto> ActInputControlFunctionings { get; set; }
        public virtual long Rn { get; set; }
    }
}