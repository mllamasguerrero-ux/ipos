using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPos
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Drawing.Imaging;
    public class RawPrinterHelperZPL
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);


        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, byte[] pBytes, Int32 dwCount, out Int32 dwWritten);


        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        public static bool SendBytesToPrinter(string szPrinterName, byte[] bytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false;

            di.pDocName = "Zebra Label";
            di.pDataType = "RAW";


            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, bytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
                throw new Win32Exception(dwError);
            }
            return bSuccess;
        }
    }
    public class ZplImage
    {
        public static string GetGrfStoreCommand(string filename, Bitmap bmpSource)
        {
            if (bmpSource == null)
            {
                throw new ArgumentNullException("bmpSource");
            }
            validateFilename(filename);

            var dim = new Rectangle(Point.Empty, bmpSource.Size);
            var stride = ((dim.Width + 7) / 8);
            var bytes = stride * dim.Height;

            using (var bmpCompressed = bmpSource.Clone(dim, PixelFormat.Format1bppIndexed))
            {
                var result = new StringBuilder();

                result.AppendFormat("^XA~DG{2},{0},{1},", stride * dim.Height, stride, filename);
                byte[][] imageData = GetImageData(dim, stride, bmpCompressed);

                byte[] previousRow = null;
                foreach (var row in imageData)
                {
                    appendLine(row, previousRow, result);
                    previousRow = row;
                }
                result.Append(@"^FS^XZ");

                return result.ToString();
            }
        }

        public static string GetGrfDeleteCommand(string filename)
        {
            validateFilename(filename);

            return string.Format("^XA^ID{0}^FS^XZ", filename);
        }

        public static string GetGrfPrintCommand(string filename)
        {
            validateFilename(filename);

            //return string.Format("^XA^FO0,0^XG{0},1,1^FS^XZ", filename);
            return string.Format("^FO160,10^XG{0},1,1^FS", filename);
        }

        static Regex regexFilename = new Regex("^[REBA]:[A-Z0-9]{1,8}\\.GRF$");

        private static void validateFilename(string filename)
        {
            if (!regexFilename.IsMatch(filename))
            {
                throw new ArgumentException("Filename must be in the format "
                    + "R:XXXXXXXX.GRF.  Drives are R, E, B, A.  Filename can "
                    + "be alphanumeric between 1 and 8 characters.", "filename");
            }
        }

        unsafe private static byte[][] GetImageData(Rectangle dim, int stride, Bitmap bmpCompressed)
        {
            byte[][] imageData;
            var data = bmpCompressed.LockBits(dim, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            try
            {
                byte* pixelData = (byte*)data.Scan0.ToPointer();
                byte rightMask = (byte)(0xff << (data.Stride * 8 - dim.Width));
                imageData = new byte[dim.Height][];

                for (int row = 0; row < dim.Height; row++)
                {
                    byte* rowStart = pixelData + row * data.Stride;
                    imageData[row] = new byte[stride];

                    for (int col = 0; col < stride; col++)
                    {
                        byte f = (byte)(0xff ^ rowStart[col]);
                        f = (col == stride - 1) ? (byte)(f & rightMask) : f;
                        imageData[row][col] = f;
                    }
                }
            }
            finally
            {
                bmpCompressed.UnlockBits(data);
            }
            return imageData;
        }

        private static void appendLine(byte[] row, byte[] previousRow, StringBuilder baseStream)
        {
            if (row.All(r => r == 0))
            {
                baseStream.Append(",");
                return;
            }

            if (row.All(r => r == 0xff))
            {
                baseStream.Append("!");
                return;
            }

            if (previousRow != null && MatchByteArray(row, previousRow))
            {
                baseStream.Append(":");
                return;
            }

            byte[] nibbles = new byte[row.Length * 2];
            for (int i = 0; i < row.Length; i++)
            {
                nibbles[i * 2] = (byte)(row[i] >> 4);
                nibbles[i * 2 + 1] = (byte)(row[i] & 0x0f);
            }

            for (int i = 0; i < nibbles.Length; i++)
            {
                byte cPixel = nibbles[i];

                int repeatCount = 0;
                for (int j = i; j < nibbles.Length && repeatCount <= 400; j++)
                {
                    if (cPixel == nibbles[j])
                    {
                        repeatCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (repeatCount > 2)
                {
                    if (repeatCount == nibbles.Length - i
                        && (cPixel == 0 || cPixel == 0xf))
                    {
                        if (cPixel == 0)
                        {
                            if (i % 2 == 1)
                            {
                                baseStream.Append("0");
                            }
                            baseStream.Append(",");
                            return;
                        }
                        else if (cPixel == 0xf)
                        {
                            if (i % 2 == 1)
                            {
                                baseStream.Append("F");
                            }
                            baseStream.Append("!");
                            return;
                        }
                    }
                    else
                    {
                        baseStream.Append(getRepeatCode(repeatCount));
                        i += repeatCount - 1;
                    }
                }
                baseStream.Append(cPixel.ToString("X"));
            }
        }

        private static string getRepeatCode(int repeatCount)
        {
            if (repeatCount > 419)
                throw new ArgumentOutOfRangeException();

            int high = repeatCount / 20;
            int low = repeatCount % 20;

            const string lowString = " GHIJKLMNOPQRSTUVWXY";
            const string highString = " ghijklmnopqrstuvwxyz";

            string repeatStr = "";
            if (high > 0)
            {
                repeatStr += highString[high];
            }
            if (low > 0)
            {
                repeatStr += lowString[low];
            }

            return repeatStr;
        }

        private static bool MatchByteArray(byte[] row, byte[] previousRow)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != previousRow[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    internal static class NativeMethods
    {
        #region winspool.drv

        #region P/Invokes

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern UInt32 StartDocPrinter(IntPtr hPrinter, Int32 level, IntPtr di);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool WritePrinter(
            // 0
            IntPtr hPrinter,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pBytes,
            // 2
            UInt32 dwCount,
            out UInt32 dwWritten);

        #endregion

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        internal struct DOC_INFO_1
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string DocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string OutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Datatype;
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Represents a print job in a spooler queue
    /// </summary>
}
