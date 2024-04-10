using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PRI_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int port = 1234;
            // �������� ������������� ������ � ������ IPAddress
            if (IPAddress.TryParse(textBox1.Text, out IPAddress ipAddress))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
                //
                // ������� UDP �����
                using (UdpClient udpClient = new UdpClient())
                {
                    try
                    {
                        string message = textBox2.Text;

                        // ���������� ��������� �������
                        byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                        udpClient.Send(sendBytes, sendBytes.Length, remoteEndPoint);

                        // �������� ����� �� �������
                        IPEndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] serverResponseBytes = udpClient.Receive(ref serverResponseEndPoint);
                        string serverResponse = Encoding.ASCII.GetString(serverResponseBytes);

                        MessageBox.Show($"����� �� �������: {serverResponse}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������: {ex.Message}");
                    }
                }
                MessageBox.Show("cool");
            }
            else
            {
                MessageBox.Show("�� � �� ���� ��� ���� Ip ������������� �� ������ � IPAddress");
            }
        }
    }
}