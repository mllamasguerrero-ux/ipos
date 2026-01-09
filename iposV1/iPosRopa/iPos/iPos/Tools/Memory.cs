using System.Collections;
using System.Runtime.InteropServices;
using System;
class Memory
{
       [DllImport("kernel32.dll")]
       public static extern bool SetProcessWorkingSetSize( IntPtr proc, int min, int max );
    public static void ReduceMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
       public Memory()
       {
                ReduceMemory() ;
        }
}
