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
            // Пытаемся преобразовать строку в объект IPAddress
            if (IPAddress.TryParse(textBox1.Text, out IPAddress ipAddress))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
                //
                // Создаем UDP сокет
                using (UdpClient udpClient = new UdpClient())
                {
                    try
                    {
                        string message = textBox2.Text;

                        // Отправляем сообщение серверу
                        byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                        udpClient.Send(sendBytes, sendBytes.Length, remoteEndPoint);

                        // Получаем ответ от сервера
                        IPEndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] serverResponseBytes = udpClient.Receive(ref serverResponseEndPoint);
                        string serverResponse = Encoding.ASCII.GetString(serverResponseBytes);

                        MessageBox.Show($"Ответ от сервера: {serverResponse}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
                MessageBox.Show("cool");
            }
            else
            {
                MessageBox.Show("Да я не знаю как твой Ip преобразовать из строки в IPAddress");
            }
        }
    }
}