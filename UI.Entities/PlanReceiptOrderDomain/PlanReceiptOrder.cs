// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrder.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using CommonDomain;
    using Halfblood.Common;

    /// <summary>
    /// The plan receipt order.
    /// </summary>
    public class PlanReceiptOrder : EntityBase<PlanReceiptOrder>, IHasState<PlanReceiptOrderState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptOrder"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public PlanReceiptOrder(long rn)
        {
            Rn = rn;
        }

        public PlanReceiptOrder()
        {
            GroundDocumentDate = DateTime.Today;
            GroundReceiptDocumentDate = DateTime.Today;
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? GroundDocumentDate { get; set; }
        public string GroundDocumentNumb { get; set; }
        public string Note { get; set; }
        public long Numb { get; set; }
        public IList<PlanCertificate> PlanCertificates { get; set; }
        public string Pref { get; set; }
        public StaffingDivision StaffingDivision { get; set; }
        public PlanReceiptOrderState State { get; set; }
        public DateTime? StateDate { get; set; }
        public StoreGasStationOilDepot StoreGasStationOilDepot { get; set; }
        public TypeOfDocument GroundTypeOfDocument { get; set; }
        public User UserContractor { get; set; }
        public User UserCreator { get; set; }
        public string GroundReceiptDocumentNumb { get; set; }
        public DateTime? GroundReceiptDocumentDate { get; set; }
        public TypeOfDocument GroundReceiptTypeOfDocument { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PlanReceiptOrder == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as PlanReceiptOrder;

            return Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }

        public override string ToString()
        {
            return Numb + "-" + Pref;
        }
    }
}