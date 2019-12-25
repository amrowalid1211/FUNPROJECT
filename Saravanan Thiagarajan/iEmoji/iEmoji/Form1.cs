using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iEmoji
{
    public partial class Form1 : Form
    {
        static int emojiSize = 80;
        static float columns = 4;

        public PictureBox selected = null;

        SoundPlayer simpleSound = new SoundPlayer(@"sound.wav");
       
        public Form1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            GetEmojis();
       //     this.BackColor = Color.Turquoise;
            RoundBorderForm(this);
       //     
            notifyIcon1.Visible = true;
            this.Paint += Form1_Paint;
            this.Resize += Form1_Resize;
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void GetEmojis()
        {
            string[] fileEntries = Directory.GetFiles("imgs");
            this.Width = emojiSize * (int)columns;
            this.Height = (int)(Math.Round((float)fileEntries.Length / columns) * emojiSize)+panel2.Height+panel6.Height;
            //    this.flowLayoutPanel1.Width = emojiSize * fileEntries.Length;
            //    this.flowLayoutPanel1.Height = emojiSize;
            foreach (string fileName in fileEntries)
            {
                PictureBox pb = new PictureBox();
                pb.Image = new Bitmap(fileName);
                pb.Tag = Path.GetFileNameWithoutExtension(fileName);
                pb.Margin = new Padding(0);
                pb.Size = new Size(emojiSize, emojiSize);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Padding = new Padding(10);
                pb.MouseMove += Pb_MouseHover;
                pb.MouseLeave += Pb_MouseLeave;
                pb.Click += Pb_Click;
                RoundBorderForm(pb);
                flowLayoutPanel1.Controls.Add(pb);
            }
           
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Location = new Point(x,y);
            this.TopMost = true;
            
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Padding = new Padding(0);
            pb.Refresh();
            simpleSound.Play();
            if (selected != null)
                selected.BackColor = Color.Transparent;
            selected = pb;
            pb.BackColor = Color.FromArgb(125, Color.Red);
           
            
        }

        private void Pb_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Padding = new Padding(10);
            pb.Refresh();
        }

        private void Pb_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Padding = new Padding(5);
            pb.Refresh();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }
        public static void RoundBorderForm(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
            int CornerRadius = emojiSize/2;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            frm.Region = new Region(path);
            
        }

        public static void RoundBorderForm(PictureBox frm)
        {
           // frm.FormBorderStyle = FormBorderStyle.None;
            Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            frm.Region = new Region(path);

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            send_message();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                send_message();
            }
        }

        private void send_message()
        {
            Hide();
            this.WindowState = FormWindowState.Minimized;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string time = DateTime.Now.ToString();
            MessageBox.Show("("+userName+")\\\""+textBox1.Text + "\"" + "\\" + ((selected!=null)?selected.Tag:"No emoji") + "\\" + time);
            textBox1.Text = "";
            if(selected!=null)
            selected.BackColor = Color.Transparent;
            selected = null;
        }

        private void nightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(42, 42, 42);
            pictureBox1.BackColor = Color.GhostWhite;
        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.WhiteSmoke;
            pictureBox1.BackColor = Color.WhiteSmoke;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
           

        }
    }
}
