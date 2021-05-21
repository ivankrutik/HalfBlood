namespace Halfblood.Common.Settings
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ParserSettingException : Exception
    {
        public ParserSettingException()
        {
        }

        public ParserSettingException(string message)
            : base(message)
        {
        }

        public ParserSettingException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ParserSettingException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}