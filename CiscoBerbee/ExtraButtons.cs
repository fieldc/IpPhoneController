using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiscoBerbee
{
    public partial class ExtraButtons : UserControl
    {
        private PhoneController controller;

        private void Initialize()
        {
            InitializeComponent();
            this.messagesButton.Tag = "Messages";
            this.messagesButton.Click += new EventHandler(button_Click);

            this.servicesButton.Tag = "Services";
            this.servicesButton.Click += new EventHandler(button_Click);

            this.directoriesButton.Tag = "Directories";
            this.directoriesButton.Click += new EventHandler(button_Click);

            this.settingsButton.Tag = "Settings";
            this.settingsButton.Click += new EventHandler(button_Click);

            this.helpButton.Tag = "Info";
            this.helpButton.Click += new EventHandler(button_Click);

            this.volDownButton.Tag = "VolDwn";
            this.volDownButton.Click += new EventHandler(button_Click);

            this.volUpButton.Tag = "VolUp";
            this.volUpButton.Click += new EventHandler(button_Click);

            this.headsetButton.Tag = "Headset";
            this.headsetButton.Click += new EventHandler(button_Click);

            this.muteButton.Tag = "Mute";
            this.muteButton.Click += new EventHandler(button_Click);

            this.speakerButton.Tag = "Speaker";
            this.speakerButton.Click += new EventHandler(button_Click);
        }
        public ExtraButtons()
        {
            this.Initialize();
        }

        public ExtraButtons(PhoneController controller)
        {
            this.controller = controller;
            this.Initialize();
        }

        void button_Click(object sender, EventArgs e)
        {
            controller.SendButton((string)((PictureBox)sender).Tag);
            controller.RefreshScreenShot();
        }
        public PhoneController Controller
        {
            get { return this.controller; }
            set { this.controller = value; }
        }
    }
}
