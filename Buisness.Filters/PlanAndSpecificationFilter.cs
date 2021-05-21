// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StagesOfTheContractFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StagesOfTheContractFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Buisness.Filters
{
    using System;
    using System.ComponentModel;
    using Filtering.Infrastructure;

    using Halfblood.Common;

    public class PlanAndSpecificationFilter : IUserFilter<long>
    {
        public PlanAndSpecificationFilter()
        {
            PersonalAccount = new PersonalAccountFilter();
            ModificationNomenclature = new NomenclatureNumberModificationFilter();
        }

        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public Between<DateTime> BeginDate { get; set; }
        public Between<DateTime> EndDate { get; set; }

        public PersonalAccountFilter PersonalAccount { get; set; }
        public NomenclatureNumberModificationFilter ModificationNomenclature { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public static PlanAndSpecificationFilter Default
        {
            get { return new PlanAndSpecificationFilter(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}