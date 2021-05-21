namespace Halfblood.Common.Reporting
{
    using System.Collections.Generic;

    using Halfblood.Common.Connection;

    public class SendData
    {
        public SendData()
        {
            AuthorizationMetadata = new AuthorizationMetadata();
            Parameters = new Dictionary<string, string>();
        }

        public long Rn { get; set; }
        public AuthorizationMetadata AuthorizationMetadata { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
