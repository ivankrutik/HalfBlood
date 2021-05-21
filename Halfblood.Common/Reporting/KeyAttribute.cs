namespace Halfblood.Common.Reporting
{
    using System;

    public class KeyAttribute : Attribute
    {
        public string Key { get; private set; }

        public KeyAttribute(string key)
        {
            Key = key;
        }
    }
}
