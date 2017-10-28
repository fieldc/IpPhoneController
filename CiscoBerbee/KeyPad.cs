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
    public partial class KeyPad : UserControl
    {
        private PhoneController controller;

        public KeyPad()
        {
            this.Initialize();
        }
        public KeyPad(PhoneController controller)
        {
            this.controller = controller;
            this.Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            this.button0.Click += new EventHandler(button_Click);
            this.button0.Tag = "KeyPad0";

            this.button1.Click += new EventHandler(button_Click);
            this.button1.Tag = "KeyPad1";

            this.button2.Click += new EventHandler(button_Click);
            this.button2.Tag = "KeyPad2";

            this.button3.Click += new EventHandler(button_Click);
            this.button3.Tag = "KeyPad3";

            this.button4.Click += new EventHandler(button_Click);
            this.button4.Tag = "KeyPad4";

            this.button5.Click += new EventHandler(button_Click);
            this.button5.Tag = "KeyPad5";

            this.button6.Click += new EventHandler(button_Click);
            this.button6.Tag = "KeyPad6";

            this.button7.Click += new EventHandler(button_Click);
            this.button7.Tag = "KeyPad7";

            this.button8.Click += new EventHandler(button_Click);
            this.button8.Tag = "KeyPad8";

            this.button9.Click += new EventHandler(button_Click);
            this.button9.Tag = "KeyPad9";

            this.buttonStar.Click += new EventHandler(button_Click);
            this.buttonStar.Tag = "KeyPadStar";

            this.buttonPound.Click += new EventHandler(button_Click);
            this.buttonPound.Tag = "KeyPadPound";
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
