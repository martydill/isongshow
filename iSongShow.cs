
// iSongShow.cs - app runner
// (c) 2005 Marty Dill. See license.txt for details.


using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using iTunesLib;

namespace iSongShow
{
    class iSongShowMain
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);


        // Handles play events from iTunes
        private static void OnPlayEvent(object o)
        {
            PopupRunner.EnqueueTrack((IITTrack)o);
        }


        [STAThread]
        static void Main(string[] args)
        {
            // Only allow one instance
            bool amITheFirstInstance;
            Mutex m = new Mutex(true, "#iSongShow_Mutex#", out amITheFirstInstance);
            if (!amITheFirstInstance)
            {
                MessageBox.Show("iSongShow is already running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // Die painfully if iTunes isn't installed
            iTunesApp app;
            try
            {
                app = new iTunesAppClass();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to create instance of iTunesAppClass. Maybe iTunes isn't installed?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Run!
            try
            {
                SettingsForm settingsForm = new SettingsForm();

                app.OnPlayerPlayEvent += new
                   iTunesLib._IiTunesEvents_OnPlayerPlayEventEventHandler(OnPlayEvent);


                // Yes, the sole purpose of this code is to reduce the apparent memory usage as reported
                // by task manager. Maybe this way I'll get fewer complaints about the supposedly large
                // memory footprint of .NET apps. *Sigh*
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);


                Application.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show("Something that wasn't supposed to happen did: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                app.OnPlayerPlayEvent -= new
                   iTunesLib._IiTunesEvents_OnPlayerPlayEventEventHandler(OnPlayEvent);
            }
        }
    }
}
