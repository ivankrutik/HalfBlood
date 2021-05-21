using System;
using System.Collections.Generic;
using System.ComponentModel;
using Buisness.Entities.CertificateQualityDomain;
using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
using Buisness.Entities.CommonDomain;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class ActInputControlFilter : IUserFilter<long>
    {
        public string ViewTareStamp { get; set; }
        public Between<DateTime?> OpenningTareDate { get; set; }
        public Between<DateTime?> ControlerTareDate { get; set; }
        public IList<ActInputControlState> State { get; set; }
        public string Note { get; set; }
        public IList<UserDto> ControlerTare { get; set; }
        public IList<UserDto> ManagerStoreAct { get; set; }
        public IList<UserDto> ManagerStoreTare { get; set; }
        public IList<TheMoveActDto> TheMoveActs { get; set; }
        public IList<ConclusionDto> Conclusions { get; set; }
        public IList<QualityStateControlOfTheMakeDto> QualityStateControlOfTheMakes { get; set; }
        public IList<SolutionByNoteDto> SolutionByNotes { get; set; }
        public IList<ActInputControlTechnicalStateDto> ActInputControlTechnicalStates { get; set; }
        public IList<ActInputControlFunctioningDto> ActInputControlFunctionings { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public long Rn { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        object IHasUid.Rn { get { return Rn; } }
    }
}