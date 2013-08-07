
// PopupRunner.cs - does the work of displaying the song popup
// (c) 2005 Marty Dill. See license.txt for details.


using System;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

using iTunesLib;


namespace iSongShow
{
    public class PopupRunner
    {
        private static Stack songs = new Stack();
        private static Thread thread;


        // When a play event we gets fired, we push the track onto a stack. The runner thread will then
        // grab the top item from the stack and display it. When done, it will grab the new top item
        // (if it exists), clear the stack, and display the item. The result of doing this is that
        // no matter how many play events get fired while we are displaying a song, only the first and
        // last will be shown.
        public static void EnqueueTrack(IITTrack track)
        {
            lock (typeof(PopupRunner))
            {
                lock (songs)
                {
                    songs.Push(track);
                }

                if (thread == null || thread.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    thread = new Thread(new ThreadStart(PopupRunner.Run));
                    thread.Start();
                }
            }
        }


        public static void Run()
        {
            Popup displayForm = new Popup();

            while (true)
            {
                int fadeDelay = Settings.Instance.GetInt("FadeDelay");
                int opacity = Settings.Instance.GetInt("Opacity");
                double opacityStep = Settings.Instance.GetDouble("OpacityStep");
                int popupDuration = Settings.Instance.GetInt("PopupDuration");

                lock (songs)
                {
                    IITTrack track = songs.Pop() as IITTrack;
                    displayForm.SongText = track.Name;

                    // Still need to handle names that are too long to fit in labels ...
                    if (track.Artist != null && track.Album != null)
                        displayForm.ArtistText = track.Artist + " : " + track.Album;
                    else if (track.Artist == null)
                        displayForm.ArtistText = track.Album;
                    else
                        displayForm.ArtistText = track.Artist;
                }

                displayForm.Show();
                displayForm.FadeMe(fadeDelay, opacity, opacityStep);


                long start = DateTime.Now.Ticks;
                long currentTime;

                do
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    currentTime = DateTime.Now.Ticks;
                }
                while (currentTime - start < popupDuration * 10000);


                displayForm.FadeMe(fadeDelay, opacity, -opacityStep);
                displayForm.Hide();

                lock (songs)
                {
                    if (songs.Count == 0)
                        return;

                    iTunesLib.IITTrack t = songs.Pop() as iTunesLib.IITTrack;
                    songs.Clear();
                    songs.Push(t);
                }
            }
        }
    }
}
