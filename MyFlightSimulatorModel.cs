using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Net;
using System.Net.Sockets;

namespace HomeWork
{
    public class MyFlightSimulatorModel : IFlightSimulatorModel
    {
        private double rudder;

        public double Rudder
        {
            get { return rudder; }
            
            set { rudder = value;
                NotifyPropertyChanged("Rudder"); 
                }
        }

        private double elevator;
        public double Elevator
        {
            get { return elevator; }

            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        public bool connect(string ip, string port)
        {

            string message_SET_THROTTLE = "set /controls/engines/current-engine/throttle 10\n";


            string message_GET_THROTTLE = "get /controls/engines/current-engine/throttle\n";

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 7777);

  

            NetworkStream networkStream = tcpClient.GetStream();



            Byte[] data_SET = System.Text.Encoding.ASCII.GetBytes(message_SET_THROTTLE);
            networkStream.Write(data_SET, 0, data_SET.Length);

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message_GET_THROTTLE);
            networkStream.Write(data, 0, data.Length);


            byte[] responce = new byte[256];
            int k = networkStream.Read(responce, 0, 100);



            string result = System.Text.Encoding.UTF8.GetString(responce);



            networkStream.Close();
            tcpClient.Close();

            return true;

        }


        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            throw new NotImplementedException();
        }
    }
}
