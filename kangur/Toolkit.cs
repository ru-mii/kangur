using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kangur
{
    /// <summary>
    /// Cool and useful functions.
    /// </summary>
    public static class Toolkit
    {
        /// <summary>
        /// Check if window = form is already open
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsFormOpen(string name)
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

        /// <summary>
        /// Check if form is visible
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsFormVisible(string name)
        {
            // go through all of the forms
            foreach (Form window in Application.OpenForms)
            {
                // check name of each form and return true
                // if it matches our search + form is visible
                if (window.Name == name && window.Visible)
                    return true;
            }

            // above didn't hit true so we just return false
            return false;
        }

        /// <summary>
        /// Change memory protection.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool DisableMemoryProtection(uint address, int size)
        { return VirtualProtectEx(Main.mainGameProcess.Handle, (IntPtr)address, size, 0x40, out IntPtr zero); }

        /// <summary>
        /// Write memory easily, a cool wrapper.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool WriteMemory(uint address, byte[] array)
        {
            // longer function in wrapper
            return WriteProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
                array, array.Length, out IntPtr nullification);
        }

        public static uint ReadMemoryInt32(uint address)
        {
            // 4 because int is 4
            byte[] rawBytes = new byte[4];

            // read raw bytes
            ReadProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
            rawBytes, rawBytes.Length, out IntPtr nullification);

            // return parsed bytes to int
            return BitConverter.ToUInt32(rawBytes, 0);
        }

        /// <summary>
        /// Reads float value from memory.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static float ReadMemoryFloat(uint address)
        {
            // 4 because float is 4
            byte[] rawBytes = new byte[4];

            // read raw bytes
            ReadProcessMemory(Main.mainGameProcess.Handle, (IntPtr)address,
            rawBytes, rawBytes.Length, out IntPtr nullification);

            // return parsed bytes to float
            return BitConverter.ToSingle(rawBytes, 0);
        }

        /// <summary>
        /// Allocates memory.
        /// </summary>
        /// <returns></returns>
        public static uint AllocateMemory()
        { return (uint)VirtualAllocEx(Main.mainGameProcess.Handle, IntPtr.Zero, 0x1000, 0x1000 | 0x2000, 0x40); }

        // checks if key is pressed
        public static bool IsKeyPressed(int keyCode)
        {
            // read key status from table and compare
            short keyStatus = GetAsyncKeyState(keyCode);

            // return if pressed
            return (keyStatus & 1) != 0;
        }

        /// <summary>
        /// Merging byte arrays with concat.
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static byte[] MergeByteArrays(params byte[][] arrays)
        {
            // create empty array
            byte[] byteArray = new byte[0];

            // go through each arrays and connect with concat
            foreach (byte[] array in arrays)
                byteArray = byteArray.Concat(array).ToArray();

            // returned merged arrays
            return byteArray;
        }

        // show custom message box with warning or error icon
        public static void ShowError(string message) { MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static void ShowInfo(string message) { MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }

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

        // imported memory allocation
        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
        uint dwSize, uint flAllocationType, uint flProtect);

        // imported key state
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}