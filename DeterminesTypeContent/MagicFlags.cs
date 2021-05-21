namespace DeterminesTypeContent
{
    using System;

    [Flags]
    public enum MagicFlags
    {
        MagicNone = 0,		// No flags
        MagicDebug = 1,		// Turn on debugging
        MagicSymlink = 1 << 1,	// Follow symlinks 
        MagicCompress = 1 << 2,	// Check inside compressed files
        MagicDevices = 1 << 3,	// Look at the contents of devices
        MagicMimeType = 1 << 4,	// Return only the MIME type
        MagicContinue = 1 << 5,	// Return all matches
        MagicCheck = 1 << 6,	// Print warnings to stderr
        MagicPreserveAtime = 1 << 7,	// Restore access time on exit
        MagicRaw = 1 << 8,	// Don't translate unprint chars
        MagicError = 1 << 9,	// Handle ENOENT etc as real errors
        MagicMimeEncoding = 1 << 10,	// Return only the MIME encoding 
        MagicMime = (MagicMimeType | MagicMimeEncoding),
        MagicNoCheckCompress = 1 << 12,	// Don't check for compressed files 
        MagicNoCheckTar = 1 << 13,	// Don't check for tar files 
        MagicNoCheckSoft = 1 << 14,	// Don't check magic entries 
        MagicNoCheckApptype = 1 << 15,	// Don't check application type 
        MagicNoCheckElf = 1 << 16,	// Don't check for elf details 
        MagicNoCheckAscii = 1 << 17,	// Don't check for ascii files 
        MagicNoCheckTokens = 1 << 20,	// Don't check ascii/tokens 

        // Defined for backwards compatibility; do nothing 
        MagicNoCheckFortran = 0,		// Don't check ascii/fortran 
        MagicNoCheckTroff = 0			// Don't check ascii/troff 
    }
}
