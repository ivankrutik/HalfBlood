namespace Halfblood.Common.Reporting
{
    using System.Collections.Generic;
    
    public interface IBuilderQuery
    {
        IDictionary<string, string> GetParameters(object reportSettings);
    }
}
