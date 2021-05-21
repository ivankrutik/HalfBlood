namespace DeterminesTypeContent
{
    using System;
    using System.Runtime.InteropServices;

    class WrapperLibMagic : IDisposable
    {
        const string MagicDll = @"libmagic-1.dll";


        [DllImport(MagicDll, EntryPoint = "magic_open", CallingConvention = CallingConvention.Cdecl)]
        private extern static IntPtr magic_open(MagicFlags flags);

        [DllImport(MagicDll, EntryPoint = "magic_close", CallingConvention = CallingConvention.Cdecl)]
        private extern static void magic_close(IntPtr magicCookie);

        [DllImport(MagicDll, EntryPoint = "magic_setflags", CallingConvention = CallingConvention.Cdecl)]
        private extern static int magic_setflags(IntPtr magicCookie, MagicFlags flags);

        [DllImport(MagicDll, EntryPoint = "magic_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private extern static IntPtr magic_file(IntPtr magicCookie, string filename);

        [DllImport(MagicDll, EntryPoint = "magic_buffer", CallingConvention = CallingConvention.Cdecl)]
        private extern static IntPtr magic_buffer(IntPtr magicCookie, Byte[] data, int len);

        [DllImport(MagicDll, EntryPoint = "magic_error", CallingConvention = CallingConvention.Cdecl)]
        private extern static IntPtr magic_error(IntPtr magicCookie);

        [DllImport(MagicDll, EntryPoint = "magic_errno", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_errno(IntPtr magicCookie);

        [DllImport(MagicDll, EntryPoint = "magic_load", CallingConvention = CallingConvention.Cdecl)]
        private extern static int magic_load(IntPtr magicCookie, string filename);

        [DllImport(MagicDll, EntryPoint = "magic_descriptor", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr magic_descriptor(IntPtr magicCookie, int fd);

        [DllImport(MagicDll, EntryPoint = "magic_compile", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_compile(IntPtr magicCookie, string filename);

        [DllImport(MagicDll, EntryPoint = "magic_check", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_check(IntPtr magicCookie, string filename);

        [DllImport(MagicDll, EntryPoint = "magic_version", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_version();

        [DllImport(MagicDll, EntryPoint = "magic_list", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_list(IntPtr magicCookie, string filename);

        [DllImport(MagicDll, EntryPoint = "magic_getpath", CallingConvention = CallingConvention.Cdecl)]
        private static extern int magic_getpath(string filename, MagicActions action);




        private static IntPtr _magic = IntPtr.Zero;
        private MagicFlags _flags = MagicFlags.MagicNone | MagicFlags.MagicPreserveAtime;

        public bool IsOpen
        {
            get { return _magic != IntPtr.Zero; }
        }

        public void MagicOpen()
        {
            if (_magic != IntPtr.Zero)
                throw new Exception("Cannot open DeterminesTypeContent instance already opened.");
            _magic = magic_open(MagicFlags.MagicDebug);


            _flags = MagicFlags.MagicNone;
        }

        public void MagicClose()
        {
            magic_close(_magic);
            _magic = IntPtr.Zero;
        }

        private int MagicSetflags(MagicFlags flags)
        {
            return magic_setflags(_magic, flags);
        }

        public string MagicFile(string filename)
        {
            return Marshal.PtrToStringAnsi(magic_file(_magic, filename));
        }

        public string MagicBuffer(Byte[] data)
        {
            return Marshal.PtrToStringAnsi(magic_buffer(_magic, data, data.Length));
        }

        private string MagicDescriptor(int fd)
        {
            return Marshal.PtrToStringAnsi(magic_descriptor(_magic, fd));
        }

        public string MagicError()
        {
            return Marshal.PtrToStringAnsi(magic_error(_magic));
        }

        public int MagicErrno()
        {
            return magic_errno(_magic);
        }

        public int MagicLoad(string filename)
        {
            return magic_load(_magic, filename);
        }

        private int MagicCompile(string filename)
        {
            return magic_compile(_magic, filename);
        }

        private int MagicCheck(string filename)
        {
            return magic_check(_magic, filename);
        }

        private static int MagicVersion()
        {
            return magic_version();
        }

        private int MagicList(string filename)
        {
            return magic_list(_magic, filename);
        }

        private static string MagicGetpath(string filename, MagicActions action)
        {
            return Marshal.PtrToStringAnsi(new IntPtr(magic_getpath(filename, action)));
        }



        public void Dispose()
        {

            if (IsOpen)
            {
                MagicClose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
