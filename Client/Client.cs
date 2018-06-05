using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;

using System.IO;
using System.Numerics;

namespace Client
{
    class Client
    {
        private const int bufferSize = 1024;
        private const int serverPort = 1902;

        private TcpClient tcpClient = null;
        private NetworkStream stream = null; 

        // connection to the server
        public void Connect(IPAddress ip)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(ip, serverPort);
                tcpClient = new TcpClient();
                tcpClient.ReceiveTimeout  = 1000;
                tcpClient.Connect(endPoint);
                stream = tcpClient.GetStream();
            }
            catch (SocketException )
            {
                throw new System.Net.Sockets.SocketException();
            }
        }

        // connection test
        public bool Connected()
        {
            return tcpClient.Client.Connected;
        }

        public EndPoint EndPoint()
        {
            return tcpClient.Client.LocalEndPoint;
        }

        public EndPoint RemoteEndPoint()
        {
            return tcpClient.Client.RemoteEndPoint;
        }

        // sending data to the server
        public void Send(string message)
        {
            byte[] byteSend = Encoding.UTF8.GetBytes(message);
            stream.Write(byteSend, 0, byteSend.Length);
        }

        // receiving a response from the server
        public string Receive()
        {
            try
            {
                string message = "";
                byte[] byteReceive = new byte[bufferSize];

                int bytesData = stream.Read(byteReceive, 0, byteReceive.Length);
                message = Encoding.UTF8.GetString(byteReceive, 0, bytesData);

                return message;
            }
            
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        // detachment of the client
        public void Close()
        {
            string message = "exit:" + "true";
            Send(message);
            tcpClient.Close();
        }
        
        public string GetTextFromFile()
        {
            string text = null;

            try
            {
                text = File.ReadAllText("Belarus.txt").ToString();
            }
            catch (FileLoadException)
            {
                new System.IO.FileLoadException();
            }

            return text;
        }

        // transfer of information to the server
        public void TransmitInfo(string text, string ESD, int d, int n, string hashAlgorithm)
        {
            string message = null;

            try
            {
                message = "message:";
                message += text + " ";
                message += ESD + " ";
                message += d + " ";
                message += n + " ";
                message += hashAlgorithm;

                Send(message);
            }
            catch (SocketException)
            {
                new System.Net.Sockets.SocketException();
            }
        }

        // transfer of information to the server
        public void TransmitInfo(string text, string ESD, int q, int y, int g, string hashAlgorithm)
        {
            string message = null;

            try
            {
                message = "message:";
                message += text + " ";
                message += ESD + " ";
                message += q + " ";
                message += y + " ";
                message += g + " ";
                message += hashAlgorithm;

                Send(message);
            }
            catch (SocketException)
            {
                new System.Net.Sockets.SocketException();
            }
        }

        // get information from the server
        public string GetInformation()
        {
            string message = "information:true";

            Send(message);
            message = Receive();

            return message;
        }
    }
}