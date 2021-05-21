namespace Buisness.Components.StoredProcedure.PlanReceiptOrderDomain
{
    using System;

    using Halfblood.Common;

    using NHibernate.Helper;

    using ParusModel.Entities.ExpenditureInvoiceDomain;

    public class ChangeStatusExpenditureInvoiceSP : IStoredProcedure
    {
        public ChangeStatusExpenditureInvoiceSP(
            ExpenditureInvoice expenditureInvoice,
            InvoiceForTransmissionInUnitState state,
            InvoiceForTransmissionInUnitInState inState,
            DateTime dateOfPosting = default(DateTime),
            DateTime dateOfConfirm = default(DateTime))
        {
            Rn = expenditureInvoice.Rn;
            State = state;
            InState = inState;
            DateOfPosting = dateOfPosting == default(DateTime) ? DateTime.Now : dateOfPosting;
            DateOfConfirm = dateOfConfirm == default(DateTime) ? DateTime.Now : dateOfConfirm;
        }

        public string Name
        {
            get { return "ChangeStatusExpenditureInvoice"; }
        }

        [StoredParameter("WorkDate")]
        public DateTime DateOfConfirm { get; private set; }

        [StoredParameter("Rn")]
        public long Rn { get; private set; }

        [StoredParameter("Status")]
        public InvoiceForTransmissionInUnitState State { get; private set; }
        
        [StoredParameter("InStatus")]
        public InvoiceForTransmissionInUnitInState InState { get; private set; }
        
        [StoredParameter("InWorkDate")]
        public DateTime DateOfPosting { get; private set; }
    }
}
