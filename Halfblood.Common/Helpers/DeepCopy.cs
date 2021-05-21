namespace Halfblood.Common.Helpers
{
    using System;
    using System.Diagnostics.Contracts;

    using Newtonsoft.Json;

    public static class DeepCopy
    {
        public static T MakeCopy<T>(this T copiedObject)
        {
            Contract.Requires(copiedObject != null);
            Contract.Ensures(Contract.Result<T>() != null);

            Type copiedObjectType = copiedObject.GetType();
            string json = JsonConvert.SerializeObject(copiedObject);
            var buffer = (T)JsonConvert.DeserializeObject(json, copiedObjectType);

            return buffer;
        }
    }
}
