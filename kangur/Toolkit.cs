using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kangur
{
    // cool and useful functions
    class Toolkit
    {
        // check if window = form is already open
        public bool IsFormOpen(string name)
        {
            // go through all of the forms
            foreach (Form window in Application.OpenForms)
            {
                // check name of each form and return true
                // if it matches our search
                if (window.Name == name) return true;
            }

            // above didn't hit true so we just return false
            return false;
        }

        // change memory protection
        public bool DisableMemoryProtection (uint address, int size)
        { return VirtualProtectEx(Main.mainGameProcess.Handle, (IntPtr)address, size, 0x40, out IntPtr zero); }

        // write memory easily, a cool wrapper
        public bool WriteMemory(uint address, byte[] array)
        {
            // longer function in wrapper
            return WriteProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
                array, array.Length, out IntPtr nullification);
        }

        public uint ReadMemory32 (uint address)
        {
            // 4 because int is 4
            byte[] rawBytes = new byte[4];

            // read raw bytes
            ReadProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
            rawBytes, rawBytes.Length, out IntPtr nullification);

            // return parsed bytes to int
            return BitConverter.ToUInt32(rawBytes, 0); 
        }

        // reads float value from memory
        public float ReadMemoryFloat (uint address)
        {
            // 4 because float is 4
            byte[] rawBytes = new byte[4];

            // read raw bytes
            ReadProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
            rawBytes, rawBytes.Length, out IntPtr nullification);

            // return parsed bytes to float
            return BitConverter.ToSingle(rawBytes, 0);
        }

        // checks if key is pressed
        public bool IsKeyPressed(int keyCode) 
        {
            // read key status from table and compare
            short keyStatus = GetAsyncKeyState(keyCode);

            // return if pressed
            if ((keyStatus & 0x8000) > 0) return true;
            else return false;
        }

        // merging byte arrays with concat
        public byte[] MergeByteArrays(byte[] array1, byte[] array2)
        { return array1.Concat(array2).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5, byte[] array6)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray().Concat(array6).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5, byte[] array6, byte[] array7)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray().Concat(array6).ToArray().Concat(array7).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5, byte[] array6, byte[] array7, byte[] array8)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray().Concat(array6).ToArray().Concat(array7).ToArray().Concat(array8).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5, byte[] array6, byte[] array7, byte[] array8, byte[] array9)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray().Concat(array6).ToArray().Concat(array7).ToArray().Concat(array8).ToArray().Concat(array9).ToArray(); }

        public byte[] MergeByteArrays(byte[] array1, byte[] array2, byte[] array3, byte[] array4, byte[] array5, byte[] array6, byte[] array7, byte[] array8, byte[] array9, byte[] array10)
        { return array1.Concat(array2).ToArray().Concat(array3).ToArray().Concat(array4).ToArray().Concat(array5).ToArray().Concat(array6).ToArray().Concat(array7).ToArray().Concat(array8).ToArray().Concat(array9).ToArray().Concat(array10).ToArray(); }

        // imported protection change
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress,
        int dwSize, uint flNewProtect, out IntPtr lpflOldProtect);

        // imported write memory 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
        IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        // exported read memory
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
        IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesRead);

        // imported key state
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}
