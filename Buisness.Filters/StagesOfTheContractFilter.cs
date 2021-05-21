// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    public class StagesOfTheContractFilter : IUserFilter<long>
    {
        public StagesOfTheContractFilter()
        {
            PersonalAccount = new PersonalAccountFilter();
            Agnlist = UserFilter.Default;
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public string Numb { get; set; }
        public StageStatusState State { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PersonalAccountFilter PersonalAccount { get; set; }
        public UserFilter Agnlist { get; set; }
        public long RnContract { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static StagesOfTheContractFilter Default
        {
            get { return new StagesOfTheContractFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}