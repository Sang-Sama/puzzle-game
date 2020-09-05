using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhepHinh
{
    public partial class frmMain : Form
    {
        PictureBox CurentPic = new PictureBox();
        IPEndPoint ip;
        Socket client;
        int nRow;
        int nCol;
        frmRemote frmRemote;
        Help frmhelp;
        public static PictureBox pic;
        public frmMain()
        {
           

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
            pnlMain.SendToBack();
            bool s = CkeckResult();
            frmRemote.add_pn1 += showImage;
            frmRemote._up += moveUp;
            frmRemote._down += moveDown;
            frmRemote._left += moveLeft;
            frmRemote._right += moveRight;
            frmRemote._turn += turnImange;
           

            LocationChanged += (o, e) => {
                if(frmRemote != null)
                {
                    frmRemote.Left = Left + Width;
                    frmRemote.Top = Top;
                }
                if(frmhelp != null)
                {
                    frmhelp.Left = Left - Width / 2 - 50;
                    frmhelp.Top = Top;
                }
            };
            cbHelp.CheckedChanged += (or, er) => {
                frmhelp = new Help();
                if (cbHelp.Checked == true)
                {
                    frmhelp.Show();
                    cbHelp.Enabled = false;
                }
            };

        }

        /// <summary>
        /// Socket
        void connect()
        {
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999); //dia chi server
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(ip);

            Thread listen = new Thread(receive);
            listen.IsBackground = true;
            listen.Start();
        }
        void send()
        {
            if (txbmess.Text != string.Empty)
            {

                client.Send(serialize("::>" + tbxName.Text + ": " + txbmess.Text));
                add_mess("::>" + tbxName.Text + ": " + txbmess.Text);
            }

        }
        void sendResult(string s)
        {
            

                client.Send(serialize("::>" + tbxName.Text + ": " +s));
                 

        }
        void receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 100];
                    client.Receive(data);
                    var messge = deserialize(data);
                    if (messge.GetType() == typeof(Bitmap))
                    {
                        if (messge != null)
                        {
                            Start.Click += (o, e) =>
                            {
                                if (frmRemote != null)
                                {
                                    frmRemote.Close();
                                }
                                cbHelp.Enabled = true;
                                nRow = int.Parse(nmudLine.Value.ToString());
                                nCol = int.Parse(nmudColumn.Value.ToString());
                                frmRemote = new frmRemote(nRow, nCol, (Bitmap)messge);
                                frmRemote.StartPosition = FormStartPosition.Manual;
                                frmRemote.Left = Left + Width;
                                frmRemote.Top = Top;
                                frmRemote.Show();

                                frmRemote.LocationChanged += (or, er) =>
                                {
                                    Left = frmRemote.Left - Width;
                                    Top = frmRemote.Top;
                                };

                            };
                        }
                        else {MessageBox.Show("Waiting for server"); }
                    }
                    else
                    if (messge.GetType() == typeof(String))
                    {
                        add_mess((String)messge);
                    }
                    else
                    {
                        //  MessageBox.Show(messge.GetType().ToString());
                    }
                }
            }
            catch
            {
                close();
            }



        }
        void add_mess(string s)
        {
            lv.Items.Add(new ListViewItem() { Text = s });
        }
        byte[] serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, obj);
            return stream.ToArray();
        }

        object deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter binary = new BinaryFormatter();
            return binary.Deserialize(stream);
        }
        void close()
        {
            client.Close();
        }
        /// </summary>







        private void turnImange()
            
        {
            Image bmp = CurentPic.Image;
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            CurentPic.Image = bmp;
        }

        //public frmMain(string ig) : this()
        //{
        //    lbIngame.Text = ig;
        //}

    
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        //private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmhelp = new Help();
        //    frmhelp.StartPosition = FormStartPosition.Manual;
        //    frmhelp.Left = Left - Width / 2 - 50;
        //    frmhelp.Top = Top;
        //    frmhelp.Show();
        //    cbHelp.Enabled = true;
        //    cbHelp.Checked = true;
        //}
        
        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        List<PictureBox> lstpicture = new List<PictureBox>();
        Point pStart, pEnd;
        bool isDown = false;
        public void showImage(PictureBox picture, Size z)
        {
            PictureBox pic = new PictureBox();
            picture.Location = new Point(14, 150);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.MouseDown += picB_MouseDown1;
            picture.MouseMove += picB_MouseMove1;
            picture.MouseUp += picB_MouseUp1;
            // picture.MouseLeave += picB_MouseClick1;
            //picture.MouseClick += picB_MouseClick1;
            picture.MouseDoubleClick += picB_DoubleClick;
            pic = picture;
            pic.Name = picture.Name;
            this.Controls.Add(pic);
            pic.BringToFront();
            lstpicture.Add(pic);
        }
       
        private void picB_DoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            if (CurentPic.Name == "")
            {
                CurentPic = pic;

            }
            else
            {
                CurentPic.BorderStyle = System.Windows.Forms.BorderStyle.None;
                CurentPic = pic;
            }
        }

        private void moveRight()
        {
            if (CurentPic.Location.X < 494) { 
                int Col = int.Parse(nmudColumn.Value.ToString());
            int with = 443 / Col;
            int x = CurentPic.Location.X+with;
            
            CurentPic.Location = new Point(x-(int)(with* 0.18), CurentPic.Location.Y);
            }
        }

        private void moveLeft()
        {
            if(CurentPic.Location.X > 223)
            { 
            int Col = int.Parse(nmudColumn.Value.ToString());
            int with = 443 / Col;
            int x = CurentPic.Location.X - with;
            CurentPic.Location = new Point(x + (int)(with * 0.18), CurentPic.Location.Y);
            }
        }

        private void moveDown()
        {
            if (CurentPic.Location.Y < 461)
            {
                int Row = int.Parse(nmudLine.Value.ToString());
                int height = 448 / Row;
                int y = CurentPic.Location.Y + height;
                CurentPic.Location = new Point(CurentPic.Location.X, y - (int)(height * 0.16));
            }
        }

        private void moveUp()
        {
            if (CurentPic.Location.Y > 210)
            {
                int Row = int.Parse(nmudLine.Value.ToString());
                int height = 448 / Row;
                int y = CurentPic.Location.Y - height;
                CurentPic.Location = new Point(CurentPic.Location.X, y + (int)(height * 0.16));
            }
        }


        void picB_MouseClick1(object sender, EventArgs e)
        {
            
        }
        
        void picB_MouseUp1(object sender, MouseEventArgs e)
        {
            isDown = false;
            

        }
        int sc = 0;
        void picB_MouseDown1(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            isDown = true;
            pStart.X = e.X;
            pStart.Y = e.Y;
            foreach (PictureBox box in lstpictureBox)
            {
               
                
                int s = box.Location.X - pic.Location.X;
                int c = box.Location.Y - pic.Location.Y;

                if ((s > -25 && s < 25) && (c > -25 && c < 25)&& sc%2==0)
                {          
                    pic.Location = box.Location;
                    isDown = false;
                }
                
            }
            sc = sc + 1;
            //MessageBox.Show(pic.Location.ToString());

        }
        void picB_MouseMove1(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (isDown)
            {
                pEnd.X = e.X;
                pEnd.Y = e.Y;

                int vX = pEnd.X - pStart.X;
                int vY = pEnd.Y - pStart.Y;

                int a = pic.Top + vY;
                int b = pic.Left + vX;
                if (a <= pnlMain.Location.Y) { vY = -pic.Top + pnlMain.Location.Y + 2; }
                if (b <= pnlMain.Location.X) { vX = -pic.Left + pnlMain.Location.X + 2; }
                if (a >= pnlMain.Height +150) { vY = pnlMain.Height - pic.Top - 7; }
                if (b >= pnlMain.Width - pic.Width + 2) { vX = pnlMain.Width - pic.Left - pic.Width + 4; }
                pic.Top += vY;
                pic.Left += vX;
            }
            
        }
        List<PictureBox> lstpictureBox = new List<PictureBox>();
        public void aboutLocation()
        {
            int Row = int.Parse(nmudLine.Value.ToString());
            int Col = int.Parse(nmudColumn.Value.ToString());
            int with = 443 / Col;
            int height = 448 / Row;
            for (int iR = 0; iR < Row  ; iR++)
            {
                for (int iC = 0; iC < Col; iC++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Name = iC.ToString() + iR.ToString();
      
                    //pic.BackColor = Color.AntiqueWhite;
                    pic.Location = new Point(100+((150+ iC * with)- (int)((150 + iC * with) * 0.18)), (250+ iR * height)-(int)((250 + iR * height) * 0.16));
                    pic.Size = new Size(with, height);
          
                    this.Controls.Add(pic);
                    pic.BringToFront();
                     pic.Hide();
                    //pic.BorderStyle = BorderStyle.FixedSingle;
                    lstpictureBox.Add(pic);
                    
                }
               
            }
            
            
        }
        public bool CkeckResult()
        {
            int Row = int.Parse(nmudLine.Value.ToString());
            int Col = int.Parse(nmudColumn.Value.ToString());
            int s=0;
            foreach (PictureBox box in lstpictureBox)
            {
                foreach (PictureBox pic in lstpicture)
                {
                    if (box.Name == pic.Name && box.Location == pic.Location)
                    {
                        s = s + 1;
                    }
                   
                }
            }

            if (s == Row * Col) { return true; }
            else
            { return false; } 
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {

           

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            aboutLocation();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            bool check = CkeckResult();
            if (check == true)
            {
                MessageBox.Show("You win");
                sendResult("Client Win !");
            }
            else
            { MessageBox.Show("Incomplete!  Continue "); }
        }

        private void CbHelp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Btnsend_Click(object sender, EventArgs e)
        {
            send();
            txbmess.Clear();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
          

        }

         
    }
}
