namespace DeterminesTypeContent
{
    using System;

    public class MagicException : Exception
    {
        private readonly string _text;
        private readonly int _errno;

        public int ErrorNumber
        {
            get { return _errno; }
        }

        public MagicException(string text, int errno)
            : base(text)
        {
            _text = text;
            _errno = errno;
  
        }

        override public string ToString()
        {
            return _text;
        }
    }
}
