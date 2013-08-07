
// Popup.cs - the window used to display song info
// (c) 2005 Marty Dill. See license.txt for details.


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Resources;

namespace iSongShow
{
    public class Popup : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.Label artistLabel;

        private System.ComponentModel.Container components = null;


        public string SongText
        {
            set
            {
                this.songLabel.Text = value;
            }
        }


        public string ArtistText
        {
            set
            {
                this.artistLabel.Text = value;
            }
        }


        public Popup()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            // Initial position in the upper right-hand corner of the screen
            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 2,
                                    Screen.PrimaryScreen.WorkingArea.Y + 2);

            // Transparency is slightly broken. See MSKB 820640
            ResourceManager resourceManager = new ResourceManager("ISongShow.Resources", Assembly.GetExecutingAssembly());
            Bitmap Img = (Bitmap)resourceManager.GetObject("PopupBackground");
            //Img.MakeTransparent(Img.GetPixel(0, 0));
            //this.BackgroundImage = Img;
            this.TransparencyKey = Img.GetPixel(0, 0);
            this.BackColor = Img.GetPixel(0, 0);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Popup));
            this.songLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // songLabel
            // 
            this.songLabel.BackColor = System.Drawing.Color.Black;
            this.songLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.songLabel.ForeColor = System.Drawing.Color.White;
            this.songLabel.Location = new System.Drawing.Point(18, 8);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(312, 23);
            this.songLabel.TabIndex = 0;
            this.songLabel.Text = "Some Song Name Goes Here";
            this.songLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artistLabel
            // 
            this.artistLabel.BackColor = System.Drawing.Color.Black;
            this.artistLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.artistLabel.ForeColor = System.Drawing.Color.White;
            this.artistLabel.Location = new System.Drawing.Point(19, 33);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(300, 16);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist Name Here : Album Name Here";
            this.artistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Popup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(340, 54);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.songLabel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(800, 30);
            this.Name = "Popup";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PopupWindow";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }
        #endregion



        // Fade the window in or out using the specified parameters
        public void FadeMe(int fadeDelay, int opacity, double opacityStep)
        {
            for (int i = 0; i < opacity; ++i)
            {
                this.Opacity += opacityStep;
                Application.DoEvents();
                Thread.Sleep(fadeDelay);
            }
        }
    }
}
