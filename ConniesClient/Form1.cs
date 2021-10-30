using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ConniesClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            clientMessage();
        }

        void clientMessage()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1071);
                NetworkStream stream = client.GetStream();

                StreamWriter sw = new StreamWriter(stream);
                StreamReader sr = new StreamReader(stream);


                sw.WriteLine("Sended from Client");
                sw.Flush();



                

                stream.Close();
                client.Close();

               

            }
            catch(Exception e)
            {
                Debug.WriteLine("Failed",e);
            }

        }

    }
}
