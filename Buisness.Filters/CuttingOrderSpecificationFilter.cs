// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderSpecificationFilter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CuttingOrderSpecificationFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Filtering.Infrastructure;
using Halfblood.Common;

namespace Buisness.Filters
{
    /// <summary>
    ///     The cutting order specification filter.
    /// </summary>
    public class CuttingOrderSpecificationFilter : IUserFilter<long>
    {
        public CuttingOrderSpecificationFilter()
        {
            CuttingOrder = new CuttingOrderFilter();
        }

        object IHasUid.Rn { get { return Rn; } }
        public CuttingOrderSpecificationState State { get; set; }
        public Between<DateTime> CreationDate { get; set; }
        public Between<DateTime> AssumeDate { get; set; }
        public long? NormExpense { get; set; }
        public long? CountPartWithBlank { get; set; }
        public long? PartBlankWeight { get; set; }
        public long? PartBlankLenght { get; set; }
        public long? PartBlankWidth { get; set; }
        public long? MaxDeflectionLenght { get; set; }
        public long? MinDeflectionLenght { get; set; }
        public long? DemandContract { get; set; }
        public long? DemandGoods { get; set; }
        public long? DemandPlanMonth { get; set; }
        public PersonalAccountFilter PersonalAccount { get; set; }
        public long Crn { get; set; }
        public StaffingDivisionFilter Department { get; set; }
        public NomenclatureNumberModificationFilter NomModif { get; set; }
        public UserFilter Inspector { get; set; }
        public CuttingOrderFilter CuttingOrder { get; set; }
        public IList<SampleFilter> Samples { get; set; }
        public IList<CertificationFilter> Certifications { get; set; }

        public static CuttingOrderSpecificationFilter Default
        {
            get { return new CuttingOrderSpecificationFilter(); }
        }

        public long Rn { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}