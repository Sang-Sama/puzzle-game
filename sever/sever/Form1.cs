using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
namespace sever
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }
        void close()
        {
            server.Close();
        }
        IPEndPoint ip;
        // Socket client;
        Socket server;
        List<Socket> list_client;
        void connect()
        {
            list_client = new List<Socket>();
            ip = new IPEndPoint(IPAddress.Any, 9999); //dia chi server
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //client.Connect(ip);

            server.Bind(ip);
            Thread listen = new Thread(() =>
            {
                try
                {
                    int number = 1;
                    while (number <= 20)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        list_client.Add(client);
                        Thread Receive = new Thread(receive);
                        Receive.IsBackground = true;
                        Receive.Start(client);
                        add_mess("Co " + number + " Client Ket noi moi!");
                        number++;
                    }
                }
                catch
                {

                    IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999); //dia chi server
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }


            });
            //  Thread listen = new Thread(receive);
            listen.IsBackground = true;
            listen.Start();
        }


        private void btnsend_Click_1(object sender, EventArgs e)
        {
            foreach (Socket item in list_client)
            {
                send(item);

            }
            add_mess("::> Server:" + txbmess.Text);
            txbmess.Clear();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (Socket item in list_client)
            {
                sendImage(item);
            }

        }
        void send(Socket client)// gui tin
        {
            if (client != null && txbmess.Text != string.Empty)
            {
                client.Send(serialize("::> Server: " + txbmess.Text));

            }
        }
        void sendImage(Socket client)
        {
                if (client != null && ptbMain.Image != null)
                {
                    client.Send(serialize(ptbMain.Image));
                }
        }
        void receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 100];
                    client.Receive(data);
                    //nhan dc mess
                    var messge = deserialize(data);
                    if (messge.GetType() == typeof(Bitmap))
                    {
                        foreach (Socket item in list_client)
                        {
                            if (item != null && item != client)
                            {
                                item.Send(serialize(messge));
                            }   
                        }
                        ptbMain.Image = (Bitmap)messge;
                    }
                    else
                    if (messge.GetType() == typeof(String))
                    {
                        // send lai cho cac client 
                        foreach (Socket item in list_client)
                        {
                            if (item != null && item != client)
                            {
                                item.Send(serialize(messge));
                            }
                        }
                        add_mess((String)messge);
                    }
                    else
                    {
                        //MessageBox.Show(messge.GetType().ToString());
                    }
                }
            }
            catch
            {
                add_mess("Mat ket noi voi Client!");
                list_client.Remove(client);
                client.Close();
            }



        }

        void add_mess(string s)
        {
            lv.Items.Add(new ListViewItem() { Text = s });
            // txbmess.Clear();
        }
        void addImage(Image i)
        {
            ptbMain.Image = i;
            // txbmess.Clear();
        }
        byte[] serialize(object obj) //phan manh
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, obj);
            return stream.ToArray();
        }

        object deserialize(byte[] data)//tac manh
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter binary = new BinaryFormatter();
            return binary.Deserialize(stream);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var ofDialog = new OpenFileDialog();
            ofDialog.Multiselect = false;
            ofDialog.Filter = "images|*.png;*.jpg;*.jpeg";
            ofDialog.InitialDirectory = @"C:\My Pictures";
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {

                var img = new Bitmap(ofDialog.FileName);
                ptbMain.Image = img;

            }
            ptbMain.SizeMode = PictureBoxSizeMode.Zoom;



        }

      
    }
}
