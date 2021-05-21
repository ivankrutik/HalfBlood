namespace Buisness.Components.StoredProcedure.ExpenditureInvoiceDomain
{
    using System;
    using Halfblood.Common;
    using NHibernate.Helper;
    using ParusModel.Entities.ExpenditureInvoiceDomain;


    public class ExpenditureInvoiceSetStateSP : IStoredProcedure
    {
        public ExpenditureInvoiceSetStateSP(ExpenditureInvoice entity, InvoiceForTransmissionInUnitState newState, InvoiceForTransmissionInUnitInState newStateIn)
        {
            RN = entity.Rn;
            WorkDate = entity.WorkDate;
            InWorkDate = entity.WorkDate;
            StateIn = newStateIn;
            State = newState;
        }
        [StoredParameter("Rn")]
        public long RN
        {
            get;
            private set;
        }
        [StoredParameter("Status")]
        public InvoiceForTransmissionInUnitState State
        {
            get;
            private set;
        }
        [StoredParameter("InStatus")]
        public InvoiceForTransmissionInUnitInState StateIn
        {
            get;
            private set;
        }
        [StoredParameter("WorkDate")]
        public DateTime WorkDate
        {
            get;
            private set;
        }
        [StoredParameter("InWorkDate")]
        public DateTime InWorkDate
        {
            get;
            private set;
        }
        public string Name
        {
            get { return "ChangeStatusExpenditureInvoice"; }
        }
    }
}
