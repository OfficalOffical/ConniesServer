using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ConniesServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listener(1071);

        }
        // Server side 
        void listener(int port)
        {
            try
            {

                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    // change here for rdt 1.0 2.0 etc

                    Debug.WriteLine("Connected!");              
              
                    NetworkStream stream = client.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);

                    string valueReaded = sr.ReadToEnd();
                    Debug.WriteLine(valueReaded);

                    

                    stream.Close();
                    client.Close();

                }
            
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

     

    }
}
