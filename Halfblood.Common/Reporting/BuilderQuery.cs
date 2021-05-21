namespace Halfblood.Common.Reporting
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IBuilderQuery))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuilderQuery : IBuilderQuery
    {
        public IDictionary<string, string> GetParameters(object reportSettings)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            reportSettings.GetPropertiesMarkAttribute(
                (KeyAttribute attribute, object value) =>
                parameters.Add(attribute.Key, value != null ? value.ToString() : string.Empty));

            return parameters;
        }
    }
}
