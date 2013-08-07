
// SettingsForm.cs - Form that lets you change settings ...
// (c) 2005 Marty Dill. See license.txt for details.


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace iSongShow
{
    public class SettingsForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Label opacityStepLabel;
        private System.Windows.Forms.Label fadeDelayLabel;
        private System.Windows.Forms.Label popupDurationLabel;
        private System.Windows.Forms.TextBox opacityTextBox;
        private System.Windows.Forms.TextBox opacityStepTextBox;
        private System.Windows.Forms.TextBox fadeDelayTextBox;
        private System.Windows.Forms.TextBox popupDurationTextBox;
        private System.ComponentModel.IContainer components;


        public SettingsForm()
        {
            InitializeComponent();
        }


        // Hide the form instead of closing it
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            base.OnClosing(e);
        }


        // Hide the form instead of minimizing the window
        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();

            base.OnResize(e);
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SettingsForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.opacityStepLabel = new System.Windows.Forms.Label();
            this.fadeDelayLabel = new System.Windows.Forms.Label();
            this.popupDurationLabel = new System.Windows.Forms.Label();
            this.opacityTextBox = new System.Windows.Forms.TextBox();
            this.opacityStepTextBox = new System.Windows.Forms.TextBox();
            this.fadeDelayTextBox = new System.Windows.Forms.TextBox();
            this.popupDurationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "iSongShow";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.OnNotifyIconClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuItem1,
                                                                                     this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Settings";
            this.menuItem1.Click += new System.EventHandler(this.OnSettingsClick);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.OnExitClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(137, 152);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(72, 24);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(17, 152);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(72, 24);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.OnOkClick);
            // 
            // opacityLabel
            // 
            this.opacityLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.opacityLabel.Location = new System.Drawing.Point(24, 16);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(96, 16);
            this.opacityLabel.TabIndex = 2;
            this.opacityLabel.Text = "Opacity (%)";
            // 
            // opacityStepLabel
            // 
            this.opacityStepLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.opacityStepLabel.Location = new System.Drawing.Point(24, 48);
            this.opacityStepLabel.Name = "opacityStepLabel";
            this.opacityStepLabel.Size = new System.Drawing.Size(96, 16);
            this.opacityStepLabel.TabIndex = 3;
            this.opacityStepLabel.Text = "Opacity Step";
            // 
            // fadeDelayLabel
            // 
            this.fadeDelayLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.fadeDelayLabel.Location = new System.Drawing.Point(24, 80);
            this.fadeDelayLabel.Name = "fadeDelayLabel";
            this.fadeDelayLabel.Size = new System.Drawing.Size(96, 16);
            this.fadeDelayLabel.TabIndex = 4;
            this.fadeDelayLabel.Text = "Fade Delay";
            // 
            // popupDurationLabel
            // 
            this.popupDurationLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.popupDurationLabel.Location = new System.Drawing.Point(24, 112);
            this.popupDurationLabel.Name = "popupDurationLabel";
            this.popupDurationLabel.Size = new System.Drawing.Size(123, 16);
            this.popupDurationLabel.TabIndex = 5;
            this.popupDurationLabel.Text = "Popup Duration (ms)";
            // 
            // opacityTextBox
            // 
            this.opacityTextBox.Location = new System.Drawing.Point(157, 14);
            this.opacityTextBox.Name = "opacityTextBox";
            this.opacityTextBox.Size = new System.Drawing.Size(40, 20);
            this.opacityTextBox.TabIndex = 7;
            this.opacityTextBox.Text = "50";
            // 
            // opacityStepTextBox
            // 
            this.opacityStepTextBox.Location = new System.Drawing.Point(156, 46);
            this.opacityStepTextBox.Name = "opacityStepTextBox";
            this.opacityStepTextBox.Size = new System.Drawing.Size(40, 20);
            this.opacityStepTextBox.TabIndex = 8;
            this.opacityStepTextBox.Text = "50";
            // 
            // fadeDelayTextBox
            // 
            this.fadeDelayTextBox.Location = new System.Drawing.Point(156, 78);
            this.fadeDelayTextBox.Name = "fadeDelayTextBox";
            this.fadeDelayTextBox.Size = new System.Drawing.Size(40, 20);
            this.fadeDelayTextBox.TabIndex = 9;
            this.fadeDelayTextBox.Text = "50";
            // 
            // popupDurationTextBox
            // 
            this.popupDurationTextBox.Location = new System.Drawing.Point(156, 110);
            this.popupDurationTextBox.Name = "popupDurationTextBox";
            this.popupDurationTextBox.Size = new System.Drawing.Size(40, 20);
            this.popupDurationTextBox.TabIndex = 10;
            this.popupDurationTextBox.Text = "50";
            // 
            // SettingsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(226, 191);
            this.Controls.Add(this.popupDurationTextBox);
            this.Controls.Add(this.fadeDelayTextBox);
            this.Controls.Add(this.opacityStepTextBox);
            this.Controls.Add(this.opacityTextBox);
            this.Controls.Add(this.popupDurationLabel);
            this.Controls.Add(this.fadeDelayLabel);
            this.Controls.Add(this.opacityStepLabel);
            this.Controls.Add(this.opacityLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }
        #endregion


        // Handler for context menu's Exit item
        private void OnExitClick(object sender, System.EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            Application.Exit();
        }


        // Handler for context menu's Settings item
        private void OnSettingsClick(object sender, System.EventArgs e)
        {
            this.Show();
        }


        // Handler for form's OK button
        private void OnOkClick(object sender, System.EventArgs e)
        {
            int opacity = Convert.ToInt32(opacityTextBox.Text);
            double opacityStep = Convert.ToDouble(opacityStepTextBox.Text);
            int fadeDelay = Convert.ToInt32(fadeDelayTextBox.Text);
            int popupDuration = Convert.ToInt32(popupDurationTextBox.Text);

            Settings s = Settings.Instance;
            s.SetValue("Opacity", opacity);
            s.SetValue("OpacityStep", opacityStep);
            s.SetValue("FadeDelay", fadeDelay);
            s.SetValue("PopupDuration", popupDuration);

            this.Hide();
        }


        // Handler for form's cancel button
        private void OnCancelClick(object sender, System.EventArgs e)
        {
            this.Hide();
        }


        // Handler for notification area icon click
        private void OnNotifyIconClick(object sender, System.EventArgs e)
        {
            LoadSettings();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.Show();
        }


        // Fill form's text boxes with fresh data
        private void LoadSettings()
        {
            Settings s = Settings.Instance;

            int opacity = s.GetInt("Opacity");
            double opacityStep = s.GetDouble("OpacityStep");
            int fadeDelay = s.GetInt("FadeDelay");
            int popupDuration = s.GetInt("PopupDuration");

            this.opacityTextBox.Text = opacity + "";
            this.opacityStepTextBox.Text = opacityStep + "";
            this.fadeDelayTextBox.Text = fadeDelay + "";
            this.popupDurationTextBox.Text = popupDuration + "";
        }
    }
}
