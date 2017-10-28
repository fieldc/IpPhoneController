using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace CiscoBerbee
{
    public partial class Cisco7975 : PhoneController
    {
        private Timer screenRefreshTimer;
        public Cisco7975() { }
        public Cisco7975(string phoneIp, string userName, string password)
            : base(phoneIp, userName, password)
        {
            InitializeComponent();
            this.screenRefreshTimer = new Timer();
            this.screenRefreshTimer.Tick += new EventHandler(screenRefreshTimer_Tick);
            this.screenRefreshTimer.Interval = 2000;
            this.screenRefreshTimer.Enabled = true;
            this.screenRefreshTimer.Start();
            this.RefreshScreenShot();
            this.keyPad1.Controller = this;
            this.extraButtons1.Controller = this;

            this.upButton.Tag = "NavUp";
            this.upButton.Click += new EventHandler(button_Click);
            this.downButton.Tag = "NavDwn";
            this.downButton.Click += new EventHandler(button_Click);
            this.leftButton.Tag = "NavLeft";
            this.leftButton.Click += new EventHandler(button_Click);
            this.rightButton.Tag = "NavRight";
            this.rightButton.Click += new EventHandler(button_Click);
            this.centerButton.Tag = "NavSelect";
            this.centerButton.Click += new EventHandler(button_Click);

            this.lineButton1.Tag = "Line1";
            this.lineButton1.Click += new EventHandler(button_Click);
            this.lineButton2.Tag = "Line2";
            this.lineButton2.Click += new EventHandler(button_Click);
            this.lineButton3.Tag = "Line3";
            this.lineButton3.Click += new EventHandler(button_Click);
            this.lineButton4.Tag = "Line4";
            this.lineButton4.Click += new EventHandler(button_Click);
            this.lineButton5.Tag = "Line5";
            this.lineButton5.Click += new EventHandler(button_Click);
            this.lineButton6.Tag = "Line6";
            this.lineButton6.Click += new EventHandler(button_Click);
            this.lineButton7.Tag = "Line7";
            this.lineButton7.Click += new EventHandler(button_Click);
            this.lineButton8.Tag = "Line8";
            this.lineButton8.Click += new EventHandler(button_Click);

            this.softKey1.Tag = "Soft1";
            this.softKey1.Click += new EventHandler(button_Click);
            this.softKey2.Tag = "Soft2";
            this.softKey2.Click += new EventHandler(button_Click);
            this.softKey3.Tag = "Soft3";
            this.softKey3.Click += new EventHandler(button_Click);
            this.softKey4.Tag = "Soft4";
            this.softKey4.Click += new EventHandler(button_Click);
            this.softKey5.Tag = "Soft5";
            this.softKey5.Click += new EventHandler(button_Click);
        }

        void button_Click(object sender, EventArgs e)
        {
            this.SendButton((string)((PictureBox)sender).Tag);
            this.RefreshScreenShot();
        }
        void screenRefreshTimer_Tick(object sender, EventArgs e)
        {
            this.RefreshScreenShot();
        }
        public override void RefreshScreenShot()
        {
            AsyncCallback cb = new AsyncCallback(GetScreenShotAsynCallBack);
            Object state = new Object();
            this.getPhoneImageDelegate.BeginInvoke(cb, state);
        }

        private void GetScreenShotAsynCallBack(IAsyncResult ar)
        {
            if (ar != null)
            {
                GetPhoneImage gpi = (GetPhoneImage)((AsyncResult)ar).AsyncDelegate;
                Bitmap answer = gpi.EndInvoke(ar);
                if (answer != null) //we can fail to get the image
                {
                    this.screenShotBox.Image = answer; //CipImage.FromStream(answer).ToBitmap();
                }
            }
            return;
        }
    }
}
