using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhepHinh
{
    
    public partial class frmRemote : Form
    {
        public delegate void SendImage(PictureBox img, Size z);
        public static SendImage add_pn1 = null;
        public delegate void MoveUp();
        public static MoveUp _up = null;
        public delegate void MoveDown();
        public static MoveDown _down = null;
        public delegate void MoveLeft();
        public static MoveLeft _left = null;
        public delegate void MoveRight();
        public static MoveRight _right = null;
        public delegate void turnPiece();
        public static turnPiece _turn = null;
        public frmRemote()
        {
            InitializeComponent();

        }
        
       Point pStart, pEnd;
        bool isDown = false;
        Size sizeOriginal = new Size(200, 200);
        double ratio = .2, ratioCut = .25;
        bool isHL = false;
        Pen pen = new Pen(Color.Red, 4f);
        //int count = 0;

        private void FrmRemote_Load(object sender, EventArgs e)
        {
           
        }

        public frmRemote(int nRow, int nCol,Bitmap img) : this()
        {
            //var ofDialog = new OpenFileDialog();
            //ofDialog.Multiselect = false;
            //ofDialog.Filter = "images|*.png;*.jpg;*.jpeg";
            //ofDialog.InitialDirectory = @"C:\My Pictures";
            if (img!=null)
            {
               
                //var img = new Bitmap(ofDialog.FileName);
                Help.filename = img;
                 var sizeBound = pnlMain.ClientSize;
                var sizePiece = new Size
                {
                    Width = sizeBound.Width / nCol,
                    Height = sizeBound.Height / nRow
                };
                var sizeImgPatch = new Size
                {
                    Width = img.Width / nCol,
                    Height = img.Height / nRow
                };
                //int padding = 3;
                for (int iR = 0; iR < nRow; iR++)
                {
                    for (int iC = 0; iC < nCol; iC++)
                    {
                        int idx = iC + iR * nCol;
                       // var picB = new PictureBox();
                      

                        int left = Utils.Rd.Next(sizeBound.Width - sizePiece.Width);
                        int top = Utils.Rd.Next(sizeBound.Height - sizePiece.Height);
                        
                        //picB.Left = iC * (sizePiece.Width + padding);
                        //picB.Top = iR * (sizePiece.Height + padding);
                        double ratio = 1.2;
                        var imgPiece = new Bitmap(sizePiece.Width, sizePiece.Height);
                        using (var g = Graphics.FromImage(imgPiece))
                        {
                            g.DrawImage(img, new Rectangle(0, 0, (int)(sizePiece.Width), (int)(sizePiece.Height)),
                                new Rectangle(iC * sizeImgPatch.Width, iR * sizeImgPatch.Height, (int)(sizeImgPatch.Width * ratio),(int)(sizeImgPatch.Height * ratio)), GraphicsUnit.Pixel);
                        }//- (sizeImgPatch.Width * 0.5)*0.25)//- (sizeImgPatch.Height * 0.5) * 0.25)
                        //sizeOriginal = imgPiece.Size;
                        PictureBox picB;
                        // Bitmap k= new Bitmap(imgPiece.Width, imgPiece.Height);
                        if (iR == 0 && iC == 0)
                        {
                            picB = cutImageTopLeft(imgPiece, sizePiece);
                        }
                        else if (iR == nRow - 1 && iC == 0) { picB = cutImageBottomLeft(imgPiece, sizePiece);  }
                        else if (iR == nRow - 1 && iC == nCol - 1) { picB = cutImageRightBottom(imgPiece, sizePiece); }
                        else if (iC == 0 && iR == nRow - 1) { picB = cutImageTopRight(imgPiece, sizePiece); }
                        else if (iC == 0) { picB = cutImageleft(imgPiece, sizePiece); }
                        else if (iR == nRow - 1) {  picB = cutImagebottom(imgPiece, sizePiece); }
                        else if (iR == 0) { picB = cutImageTop(imgPiece, sizePiece); }
                        else if (iC == nCol - 1) { picB = cutImageRight(imgPiece, sizePiece); }
                        else {  picB = cutImageform1(imgPiece, sizePiece); }
                        //picB.Size = sizePiece;
                        picB.Name = iC.ToString() + iR.ToString();
                        picB.Left = left;
                        picB.Top = top;
                        picB.SizeMode = PictureBoxSizeMode.StretchImage;
                        // picB.Region = new System.Drawing.Region(k);
                        //picB.Image = k;
                        pnlMain.Controls.Add(picB);
                       picB.MouseDown += picB_MouseDown;
                       picB.MouseMove += picB_MouseMove;
                        picB.MouseUp += picB_MouseUp;
                        
                        picB.MouseDoubleClick += picB_DoubleClick;
                        //picB.MouseClick += picB_Click;



                    }
                }
                void picB_MouseUp(object sender, MouseEventArgs e)
                {
                    isDown = false;

                }
                void picB_MouseDown(object sender, MouseEventArgs e)
                {

                    isDown = true;
                    pStart.X = e.X;
                    pStart.Y = e.Y;
                }
                void picB_MouseMove(object sender, MouseEventArgs e)
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
                        if (a >= pnlMain.Height) { vY = pnlMain.Height - pic.Top - 7; }
                        if (b >= pnlMain.Width - pic.Width + 2) { vX = pnlMain.Width - pic.Left - pic.Width + 4; }
                        pic.Top += vY;
                        pic.Left += vX;
                    }
                }

             

                
                void picB_DoubleClick(object sender, MouseEventArgs e)
                {
                    
                    PictureBox pic = (PictureBox)sender;
                    
                    pic.MouseMove -= picB_MouseMove;
                    pic.MouseDoubleClick -= picB_DoubleClick;
                    add_pn1(pic, pic.Size);
                    

                    //pic.Visible = false;
                    //sendImg(pic.Image);

                    //frmMain jg = new frmMain(picB);
                    //count++;
                    //LbNumber.Text = count.ToString();
                    //picB.Visible = false;

                }
                //void picB_Click(object sender, MouseEventArgs e)
                //{
                //    PictureBox pic = (PictureBox)sender;
                //    pic.BorderStyle = BorderStyle.Fixed3D;

                //}
              
            }
        }

        public PictureBox cutImageform1(Bitmap img ,Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;
           
            var gPath = new GraphicsPath();

            //gPath.AddLine(dY, 0, (int)((sizeOriginal.Width - wCut) / 2), 0);
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)-dCut, (float)(2 * r), (float)(2 * r), 210, -sweepA);
            //gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), 0, sizeOriginal.Width - dY, 0);
            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);
            ////////////////
            ///Right  
            //gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            //startA = -angle;
            //gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            //gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);

            //////////////////
            ///Bottom

            //gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            //startA = (180 - angle) / 2;
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            //gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            /////////////////////
            //////left

            //gPath.AddLine(dY, (2 * dY + hOfCenter), dY, (int)(dY + ((hOfCenter + wCut)) / 2));
            //startA = angle / 2;
            //gPath.AddArc(0, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, sweepA);
            //gPath.AddLine(dY, (int)(dY + (hOfCenter - wCut) / 2), dY, 0);
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

            }
            var picB = new PictureBox();
           
            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageTop(Bitmap img,Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();
            gPath.AddLine(0, 0, (int)((sizeOriginal.Width - wCut) / 2), 0);
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), 0, sizeOriginal.Width - dY, 0);
            //////////////
            // Right
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);
            ////////////////
            // Bottom
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            ///////////////////
            ////left
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, 0);


            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

                // g.DrawArc(pen, sizeOfOriginal.Width / 4, 0 , sizeOfOriginal.Width / 2, sizeOfOriginal.Height / 2, 180, 360);
            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageleft(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();
            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);

            //////////////
            // Right
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);
            ////////////////
            // Bottom
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            ///////////////////
            ////left
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            //gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);


            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

                // g.DrawArc(pen, sizeOfOriginal.Width / 4, 0 , sizeOfOriginal.Width / 2, sizeOfOriginal.Height / 2, 180, 360);
            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImagebottom(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();
            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);

            //////////////
            // Right
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);

            // Bottom
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            // gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            ///////////////////
            ////left
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);


            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

                // g.DrawArc(pen, sizeOfOriginal.Width / 4, 0 , sizeOfOriginal.Width / 2, sizeOfOriginal.Height / 2, 180, 360);
            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageRight(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();

            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);
            ////////////////
            ///Right  
            gPath.AddLine(sizeOriginal.Width, 0, sizeOriginal.Width, (int)(dY + (hOfCenter - wCut) / 2));

            gPath.AddLine(sizeOriginal.Width, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width, 2 * dY + hOfCenter);
            //////////////////
            ///Bottom

            //gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            //startA = (180 - angle) / 2;
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            //gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            /////////////////////
            //////left

            //gPath.AddLine(dY, (2 * dY + hOfCenter), dY, (int)(dY + ((hOfCenter + wCut)) / 2));
            //startA = angle / 2;
            //gPath.AddArc(0, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, sweepA);
            //gPath.AddLine(dY, (int)(dY + (hOfCenter - wCut) / 2), dY, 0);
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageTopLeft(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();
            gPath.AddLine(0, 0, (int)((sizeOriginal.Width - wCut) / 2), 0);
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), 0, sizeOriginal.Width - dY, 0);
            //////////////
            // Right
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);
            ////////////////
            // Bottom
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            ///////////////////
            ////left
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            // gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, 0);


            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

                // g.DrawArc(pen, sizeOfOriginal.Width / 4, 0 , sizeOfOriginal.Width / 2, sizeOfOriginal.Height / 2, 180, 360);
            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageBottomLeft(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();
            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);

            //////////////
            // Right
            gPath.AddLine(sizeOriginal.Width - dY, dY, sizeOriginal.Width - dY, (int)(dY + (hOfCenter - wCut) / 2));
            startA = -angle;
            gPath.AddArc((float)((sizeOriginal.Width - r - hCut) - dCut), (float)(dY + (hOfCenter - wCut) / 2), (float)(r) * 2, (float)(r) * 2, startA, sweepA);
            gPath.AddLine(sizeOriginal.Width - dY, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width - dY, dY + hOfCenter);
            ////////////////
            // Bottom
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            // gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            ///////////////////
            ////left
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            //gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);


            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

                // g.DrawArc(pen, sizeOfOriginal.Width / 4, 0 , sizeOfOriginal.Width / 2, sizeOfOriginal.Height / 2, 180, 360);
            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _up();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _left();
        }

       

        private void Button3_Click(object sender, EventArgs e)
        {
            _down();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _turn();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            _right();
        }

        public PictureBox cutImageTopRight(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();

            gPath.AddLine(0, 0, (int)((sizeOriginal.Width - wCut) / 2), 0);
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), 0, sizeOriginal.Width - dY, 0);
            ////////////////
            ///Right  
            gPath.AddLine(sizeOriginal.Width, 0, sizeOriginal.Width, (int)(dY + (hOfCenter - wCut) / 2));

            gPath.AddLine(sizeOriginal.Width, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width, 2 * dY + hOfCenter);
            //////////////////
            ///Bottom

            //gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            //startA = (180 - angle) / 2;
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            //gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            /////////////////////
            //////left

            //gPath.AddLine(dY, (2 * dY + hOfCenter), dY, (int)(dY + ((hOfCenter + wCut)) / 2));
            //startA = angle / 2;
            //gPath.AddArc(0, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, sweepA);
            //gPath.AddLine(dY, (int)(dY + (hOfCenter - wCut) / 2), dY, 0);
            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
        public PictureBox cutImageRightBottom(Bitmap img, Size z)
        {
            sizeOriginal = z;
            double r = ratio * sizeOriginal.Width / 2;
            double dCut = ratioCut * r * 2; //  phần trong dường tròn
            double hCut = r - dCut; // từ mặt đến tâm đường tròn
            float angle = (float)(Math.Acos(hCut / r) * 2 * 180 / Math.PI); //cung tròn trong 
            double wCut = 2 * Math.Sqrt(r * r - hCut * hCut);// hình chiếu của tâm dường tròn đến điểm cắt
            int dY = (int)(2 * r - dCut);// phần lồi
            int hOfCenter = sizeOriginal.Height - 2 * dY;
            var bmp = new Bitmap(sizeOriginal.Width, sizeOriginal.Height);
            float sweepA = 360 - angle;
            float startA = (180 + angle) / 2;

            var gPath = new GraphicsPath();

            gPath.AddLine(0, dY, (int)((sizeOriginal.Width - wCut) / 2), dY);
            gPath.AddArc((float)(sizeOriginal.Width / 2 - r), 0, (float)(2 * r), (float)(2 * r), startA, sweepA);
            gPath.AddLine((int)((sizeOriginal.Width + wCut) / 2), dY, sizeOriginal.Width, dY);
            ////////////////
            ///Right  
            gPath.AddLine(sizeOriginal.Width, 0, sizeOriginal.Width, (int)(dY + (hOfCenter - wCut) / 2));

            gPath.AddLine(sizeOriginal.Width, (int)(dY + (hOfCenter + wCut) / 2), sizeOriginal.Width, 2 * dY + hOfCenter);
            //////////////////
            ///Bottom

            gPath.AddLine(sizeOriginal.Width - dY, 2 * dY + hOfCenter, (int)((sizeOriginal.Width + wCut) / 2), 2 * dY + hOfCenter);
            startA = (180 - angle) / 2;
            //gPath.AddArc((float)(sizeOriginal.Width / 2 - r), (float)(dY + hOfCenter), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine((int)((sizeOriginal.Width - wCut) / 2), 2 * dY + hOfCenter, (float)dY, 2 * dY + hOfCenter);
            /////////////////////
            //////left


            gPath.AddLine(0, (2 * dY + hOfCenter), 0, (int)(dY + ((hOfCenter + wCut)) / 2));
            startA = 180 - angle / 2;
            gPath.AddArc((float)-dCut, (float)(dY + (hOfCenter - wCut) / 2), (float)(2 * r), (float)(2 * r), startA, -sweepA);
            gPath.AddLine(0, (int)(dY + (hOfCenter - wCut) / 2), 0, dY);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clip = new Region(gPath);
                g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                if (isHL) { g.DrawPath(pen, gPath); }
                //g.DrawPath(pen, gPath);

            }
            var picB = new PictureBox();

            picB.Image?.Dispose();
            picB.Image = bmp;
            picB.Region = new Region(gPath);
            picB.Size = z;
            ///////////
            return picB;
        }
    }
}
