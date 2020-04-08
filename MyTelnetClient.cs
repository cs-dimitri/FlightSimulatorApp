using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace HomeWork
{
    public class MyTelnetClient : ITelnetClient
    {



        private NetworkStream networkStream;
        private bool isConnected;
        private TcpClient tcpClient;

        public bool connect(string ip, int port)
        {
            try
            {
                isConnected = true;
                this.tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);

                this.networkStream = tcpClient.GetStream();
                this.networkStream.ReadTimeout = 5000; //5 seconds
                return isConnected;

            }
            catch (SocketException e)// doesnt catch !!!!
            {
                isConnected = false;
                Console.WriteLine(e.Source);
                return isConnected;

            }
        }

        public void disconnect()
        {
            if (this.networkStream != null)
            {
                this.networkStream.Close();

            }

            if (this.tcpClient != null)
            {
                this.tcpClient.Close();

            }
        }
        public void makeFlush()
        {
            networkStream.Flush();
        }

        public string read()
        {
            try
            {
                byte[] response = new byte[256];
                int k = networkStream.Read(response, 0, 256);
                string result = System.Text.Encoding.UTF8.GetString(response);

                networkStream.Flush();

                return result;

            }
            catch (IOException)
            {
                if (this.tcpClient.Connected) //timeout
                {
                    return "time out\n"; //the server didn't crash, there was a time out
                }
                else //server crashed!
                {
                    throw new IOException("didn't succed to read");
                }
            }
            catch (ObjectDisposedException e)
            {

                throw new ObjectDisposedException("stupid user (unless Keti) dont try to read.. Server ALAX BYEEE!!!!");
            }
        }

        public void write(string command)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
                networkStream.Write(data, 0, data.Length);

            }
            catch (IOException) //in case of a timeout
            {
                throw new IOException("didn't succed to write");

            }
            catch (ObjectDisposedException e)
            {
                throw new ObjectDisposedException("stupid user (unless Keti) dont try to play.. Server ALAX BYEEE!!!!");
            }
        }

    }
}
