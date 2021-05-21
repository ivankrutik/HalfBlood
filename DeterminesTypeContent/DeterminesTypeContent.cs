namespace DeterminesTypeContent
{
    using System;
    using System.IO;

    public class DeterminesTypeContent : IDisposable
    {
        private readonly WrapperLibMagic _wm;
        public DeterminesTypeContent(string dbMagic = null)
        {
            _wm = new WrapperLibMagic();
            _wm.MagicOpen();
            var result=_wm.MagicLoad(dbMagic ?? @"magic.mgc");
            if (result == -1)
                throw CurrentError();
        }

        ~DeterminesTypeContent()
        {
            if (_wm.IsOpen)
                _wm.MagicClose();
        }

        public void Dispose()
        {
            _wm.Dispose();

        }
        private MagicException CurrentError()
        {
            return new MagicException(_wm.MagicError(), _wm.MagicErrno());
        }
        public string GetMimeType(string filename)
        {
            var text = _wm.MagicFile(filename);
            if (string.IsNullOrWhiteSpace(text))
                throw CurrentError();
            return text;
        }
        public string GetMimeType(FileInfo fi)
        {
            return GetMimeType(fi.FullName);
        }
        public string GetMimeType(byte[] data)
        {
            var text = _wm.MagicBuffer(data);
            if (String.IsNullOrWhiteSpace(text))
                throw CurrentError();
            return text;
        }
    }
}



