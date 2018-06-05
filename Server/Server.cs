using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security;
using System.Threading;
using System.Diagnostics;

using System.Numerics;

using Client;

namespace Server
{
    class Server
    {
        private const int bufferSize = 1024;
        private const int serverPort = 1902;

        private static TcpListener listener = null;
        public Server()
        {
            try
            {
                string adr = Dns.GetHostName();
                IPHostEntry ipAdr = Dns.Resolve(adr);
                IPAddress serverIp = ipAdr.AddressList[0];

                IPEndPoint endPoint = new IPEndPoint(serverIp, serverPort);

                listener = new TcpListener(endPoint);
                listener.Start();

                Console.WriteLine("Server {0} is running and listening", listener.LocalEndpoint);
                Console.WriteLine("Waiting for connection...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                 
                    Thread thread = new Thread(new ThreadStart(delegate { Execute(client); }));
                    thread.Start();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e + "\n\n" + e.Message);
                Console.ReadLine();
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }

        private static void Execute(TcpClient client)
        {
            string RSA = "RSA";
            string DSA = "DSA";

            byte[] byteRecord = new byte[bufferSize];
            string dataReceive = null;
            string data = null;
            string information = "";
            int lengthByteRecord = 0;
            Boolean flag = true;

            NetworkStream stream = client.GetStream();

            try
            {
                Console.WriteLine("Client {0} is connected", client.Client.RemoteEndPoint);

                while (flag)
                {
                    lengthByteRecord = stream.Read(byteRecord, 0, byteRecord.Length);
                    dataReceive = Encoding.UTF8.GetString(byteRecord, 0, lengthByteRecord);

                    string[] split = dataReceive.Split(new Char[] { ':' });

                    dataReceive = split[0];
                    data = split[1];

                    if (dataReceive.IndexOf("message") > -1)
                    {
                        Console.WriteLine("Server received message");

                        string[] message = data.Split(new Char[] { ' ' });
                        

                        if (String.Compare(message[message.Length-1], RSA) == 0)
                        {

                            string text = message[0];
                            string ESD = message[1];
                            int d = Convert.ToInt32(message[2]);
                            int n = Convert.ToInt32(message[3]);
                            string hashAlgorithm = message[4];

                            string hash = RSAProvider.Dedoce(ESD, d, n);

                            if (hash.CompareTo(text) == 0)
                            {
                                information += "hash: " + text + ";";
                                information += "ESD: " + ESD + ";";
                                information += "size ESD: " + ESD.Length + " bites;";
                                information += "hash Algorithm: " + hashAlgorithm + ";";
                                information += "size hash: " + text.Length + " bytes";
                                
                                Console.WriteLine("Server authentication the message");
                                Console.WriteLine("Encryption algorithm - RSA");

                            }
                            else
                            {
                                Console.WriteLine("Server does not authenticate the message");
                                Console.WriteLine("Encryption algorithm - RSA");
                            }
                        }

                        if (String.Compare(message[message.Length-1], DSA) == 0)
                        {

                            string text = message[0];
                            string ESD = message[1];
                            int q = Convert.ToInt32(message[2]);
                            int y = Convert.ToInt32(message[3]);
                            int g = Convert.ToInt32(message[4]);
                            string hashAlgorithm = message[5];
                            
                            int p = DSAProvider.CalculateP(q);

                            bool result = DSAProvider.DecodeAndEqual(text, p, q, y, g, ESD);
                            
                            if (result)
                            {
                                information += "hash: " + text + ";";
                                information += "ESD: " + ESD + ";";
                                information += "size ESD: " + ESD.Length + " bites;";
                                information += "hash Algorithm: " + hashAlgorithm + ";";
                                information += "size hash: " + text.Length + " bytes";

                                Console.WriteLine("Server authentication the message");
                                Console.WriteLine("Encryption algorithm - DSA");
                            }
                            else
                            {
                                Console.WriteLine("Server does not authenticate the message");
                                Console.WriteLine("Encryption algorithm - DSA");
                            }
                        }
                    }

                    else if (dataReceive.IndexOf("information") > -1)
                    {
                        Console.WriteLine("Server received a request for information");
                        
                        byteRecord = Encoding.UTF8.GetBytes(information);
                        stream.Write(byteRecord, 0, byteRecord.Length);
                        
                        Console.WriteLine("Server sent information to request");
                    }

                    else if (dataReceive.IndexOf("exit") > -1)
                    {
                        Console.WriteLine("Server received a request for disconnecting client");
                        flag = false;
                    }
                }

                Console.WriteLine("Client {0} is disconnected", client.Client.RemoteEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "\n\n" + e.Message);
                Console.ReadLine();
                flag = false;
            }
        }
    }
}
    