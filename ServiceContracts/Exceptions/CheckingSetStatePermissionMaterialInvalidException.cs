namespace ServiceContracts.Exceptions
{
    using Halfblood.Common;
    using System;
    using Halfblood.Common.Helpers;

    public class CheckingSetStatePermissionMaterialUserInvalidException : Exception
    {
        public CheckingSetStatePermissionMaterialUserInvalidException(PermissionMaterialUserState newState)
            : base(Resource.CheckingSetStatePlanReceiptOrderInvalid.StringFormat(newState))
        {
            
        }
        public CheckingSetStatePermissionMaterialUserInvalidException(string message)
            : base(message)
        {

        }
    }
}
