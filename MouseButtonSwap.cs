/*
 * Created by
 * User: Possessed
 * Date: 22/08/2019
 * Time: 08:36
 * 
 * TODO: Automatically Install the Left Handed Cursors Package.
 * 
 * Credits:
 * nyritha from deviantart.com for the Aero Left Handed cursor pack.
 * https://www.deviantart.com/nyritha/art/Aero-Left-Handed-cursor-pack-326620456
 * 
 * Icon by zerode from 
 * http://www.iconarchive.com/show/plump-icons-by-zerode/Document-config-icon.html
 * 
 * stackolverflow.com for the code snippets and all the useful stuff.
 * https://stackoverflow.com/questions/41713827/programmatically-change-custom-mouse-cursor-in-windows
 * 
 * Requires .NET Framework 2.0
 */

using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace Mouse_Button_Swap
{
    class MouseButtonSwap
    {
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern Int32 GetSystemMetrics(UInt32 nIndex);

        const UInt32 SPI_SETMOUSEBUTTONSWAP = 0x21;
        const UInt32 SPI_SETCURSORS         = 0x57;
        const UInt32 SPIF_UPDATEINIFILE     = 0x01;
        const UInt32 SPIF_SENDWININICHANGE  = 0x02;
        const UInt32 SM_SWAPBUTTON          = 23;

        static void MouseButtonSwapMagic()
        {
            //Open the desired registry key for further magic
            RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");

            if (RegKey == null)
            {
                Console.WriteLine("Failed to Open the Registry Key!");
                return;
            }

            //Swap the Mouse Buttons
            //Change the Cursor in the registry according to the current button
            if (GetSystemMetrics(SM_SWAPBUTTON) == 0)
            {
                SystemParametersInfo(SPI_SETMOUSEBUTTONSWAP, 1, null, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                RegKey.SetValue("", "Windows Aero Left Handed", RegistryValueKind.String);
                RegKey.SetValue("AppStarting", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_working.ani", RegistryValueKind.ExpandString);
                RegKey.SetValue("Arrow", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_arrow.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Crosshair", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_cross.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Hand", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_link.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Help", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_helpsel.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("IBeam", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_text.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("No", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_unavail.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("NWPen", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_pen.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeAll", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_move.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNESW", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_nesw.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNS", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_ns.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNWSE", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_nwse.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeWE", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_ew.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("UpArrow", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_up.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Wait", "%SYSTEMROOT%\\Cursors\\Windows Aero\\Windows Aero Left Handed\\aero_busy.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Scheme Source", "1", RegistryValueKind.DWord);
            }
            else if (GetSystemMetrics(SM_SWAPBUTTON) == 1)
            {
                SystemParametersInfo(SPI_SETMOUSEBUTTONSWAP, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                RegKey.SetValue("", "Windows Aero", RegistryValueKind.String);
                RegKey.SetValue("AppStarting", "%SYSTEMROOT%\\Cursors\\aero_working.ani", RegistryValueKind.ExpandString);
                RegKey.SetValue("Arrow", "%SYSTEMROOT%\\Cursors\\aero_arrow.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Crosshair", "", RegistryValueKind.ExpandString);
                RegKey.SetValue("Hand", "%SYSTEMROOT%\\Cursors\\aero_link.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Help", "%SYSTEMROOT%\\Cursors\\aero_helpsel.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("IBeam", "", RegistryValueKind.ExpandString);
                RegKey.SetValue("No", "%SYSTEMROOT%\\Cursors\\aero_unavail.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("NWPen", "%SYSTEMROOT%\\Cursors\\aero_pen.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeAll", "%SYSTEMROOT%\\Cursors\\aero_move.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNESW", "%SYSTEMROOT%\\Cursors\\aero_nesw.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNS", "%SYSTEMROOT%\\Cursors\\aero_ns.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeNWSE", "%SYSTEMROOT%\\Cursors\\aero_nwse.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("SizeWE", "%SYSTEMROOT%\\Cursors\\aero_ew.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("UpArrow", "%SYSTEMROOT%\\Cursors\\aero_up.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Wait", "%SYSTEMROOT%\\Cursors\\aero_busy.cur", RegistryValueKind.ExpandString);
                RegKey.SetValue("Scheme Source", "2", RegistryValueKind.DWord);
            }

            //Broadcast the Cursor changes in the registry and make them live.
            SystemParametersInfo(SPI_SETCURSORS, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

            //Log stuff
            if (GetSystemMetrics(SM_SWAPBUTTON) == 0)
            {
                Console.WriteLine("MouseButtonSwapState is: {0} - Right Handed", GetSystemMetrics(SM_SWAPBUTTON));
            }
            else if (GetSystemMetrics(SM_SWAPBUTTON) == 1)
            {
                Console.WriteLine("MouseButtonSwapState is: {0} - Left Handed", GetSystemMetrics(SM_SWAPBUTTON));
            }

            if (Convert.ToInt32(RegKey.GetValue("Scheme Source")) == 1)
            {
                Console.WriteLine("Mouse Cursor Scheme is: {0} - User Scheme", RegKey.GetValue("Scheme Source"));
            }
            else if (Convert.ToInt32(RegKey.GetValue("Scheme Source")) == 2)
            {
                Console.WriteLine("Mouse Cursor Scheme is: {0} - System Scheme", RegKey.GetValue("Scheme Source"));
            }

            RegKey.Close();
        }
        static void Main()
        {
            //Windows Title
            Console.Title = "Mouse Button and Cursor Swap v1.0 - Possessed";
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.WriteLine("[+] Enjoy!");
            Console.WriteLine("[!] Run the program again to swap buttons between left and right!");
            Console.WriteLine("");

            //Abrakadabra
            MouseButtonSwapMagic();

            //Wait for keypress to exit
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            //Take a nap before really closing
            Thread.Sleep(500);
        }
    }
}