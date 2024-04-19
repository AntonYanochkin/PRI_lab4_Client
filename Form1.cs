using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace PRI_lab4
{
    public partial class Form1 : Form
    {
         // ������� UDP �����
        public static UdpClient udpClient = new UdpClient(111);
        public Form1()
        {
            InitializeComponent();
            a();
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int port = 1234;
            // �������� ������������� ������ � ������ IPAddress
            if (IPAddress.TryParse(textBox1.Text, out IPAddress ipAddress))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
                //
                
                {
                    try
                    {
                        string message = textBox2.Text;

                        // ���������� ��������� �������
                        byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                        udpClient.Send(sendBytes, sendBytes.Length, remoteEndPoint);

                        // �������� ����� �� �������
                        /*
                        IPEndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] serverResponseBytes = udpClient.Receive(ref serverResponseEndPoint);
                        string serverResponse = Encoding.ASCII.GetString(serverResponseBytes);
                        
                        MessageBox.Show($"����� �� �������: {serverResponse}");
                        */
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("�� � �� ���� ,��� ���� Ip ������������� �� ������ � IPAddress");
            }
            
        }
        private async void a()
        {
            while (true)
            {
                var result = await udpClient.ReceiveAsync();
                string message = Encoding.UTF8.GetString(result.Buffer);
                textBox3.Text += message+"\r\n";
            }
        }
    }
}