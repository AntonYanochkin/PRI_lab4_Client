using System.Net.Sockets;
using System.Net;
using System.Text;

namespace PRI_lab4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //while (true)
            //{
            //    IPEndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //    byte[] serverResponseBytes = Form1.udpClient.Receive(ref serverResponseEndPoint);
            //    string serverResponse = Encoding.ASCII.GetString(serverResponseBytes);
            //    MessageBox.Show($"Ответ от сервера: {serverResponse}");
            //}
        }
    }
}