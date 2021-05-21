namespace Buisness.Components.StoredProcedure
{
    using System;
    using Halfblood.Common;
    using NHibernate.Helper;
    using ParusModel.Entities.CreditSlipDomain;

  public  class CreditSlipSetStateSP : IStoredProcedure
    {
        public CreditSlipSetStateSP(CreditSlip entity, CreditSlipState newState)
        {
            RN = entity.Rn;
            WorkDate = entity.WorkDate;
            State = newState;
        }

        [StoredParameter("RN")]
        public long RN
        {
            get;
            private set;
        }

        [StoredParameter("STATE")]
        public CreditSlipState State
        {
            get;
            private set;
        }

        [StoredParameter("WORK_DATE")]
        public DateTime WorkDate
        {
            get;
            private set;
        }

        public string Name
        {
            get { return "P_INORDERS_SET_STATUS"; }
        }
    }
}
