using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UdpClient udpClient = new UdpClient();
        Thread thread;
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 9760);
        public MainWindow()
        {
            InitializeComponent();
            udpClient.ExclusiveAddressUse = false;
            udpClient.Client.SetSocketOption(
            SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.Bind(endPoint);
			HelloviaDebug();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            UdpReceiveResult packet; 
            var client = new UdpClient();

            UdpClient listener = new UdpClient(30303);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 30303);

        }
        private void HelloviaDebug()
        {
				 System.Diagnostics.Debug.Write( "Hello via Debug!" );

        }

        private void ReceiveMessage()
        {
            //while (true)
            //{
            // IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            //  byte[] content = udpClient.Receive(ref endPoint);
            udpClient.BeginReceive(new AsyncCallback(Read_Callback), null);

            //if (content.Length > 0)
            //{
            //    string message = Encoding.ASCII.GetString(content);

            //    this.Invoke(myDelegate, new object[] { message });
            //}
            // }
        }

        public void Read_Callback(IAsyncResult ar)
        {
            try
            {
                byte[] buffer = udpClient.EndReceive(ar, ref endPoint);
                // Process buffer
                string s = Encoding.ASCII.GetString(buffer);
                // richTextBox1.Text = s;
                udpClient.BeginReceive(new AsyncCallback(Read_Callback), null);

            }
            catch (Exception ex)
            { }
        }
    }
}
