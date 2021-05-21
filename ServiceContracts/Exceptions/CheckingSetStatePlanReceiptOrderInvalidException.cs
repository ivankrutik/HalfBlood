namespace ServiceContracts.Exceptions
{
    using Halfblood.Common;
    using System;
    using Halfblood.Common.Helpers;

    public class CheckingSetStatePlanReceiptOrderInvalidException : Exception
    {
        public CheckingSetStatePlanReceiptOrderInvalidException(PlanReceiptOrderState newState)
            : base(Resource.CheckingSetStatePlanReceiptOrderInvalid.StringFormat(newState))
        {
            
        }
        public CheckingSetStatePlanReceiptOrderInvalidException(string message)
            : base(message)
        {

        }
    }
}
