﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace mognetwork
{
    public class TcpSocket
    {
        private IPAddress ip;
        private int port;
        private Socket socket;

        public TcpSocket(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void connect()
        {
            IPEndPoint remoteEp = new IPEndPoint(this.ip, this.port);
            socket.Connect(remoteEp);
        }

        public void disconnect()
        {
            socket.Disconnect(true);
        }

        public void sendDatas(List<byte> datas)
        {
            List<byte> toSend = new List<byte>();

            toSend.AddRange(BitConverter.GetBytes((Int64)datas.Count));
            Console.WriteLine("BUFFER: '" + System.Text.Encoding.ASCII.GetString(toSend.ToArray()) + "'");
            toSend.AddRange(datas);
            Console.WriteLine("BUFFER: '" + System.Text.Encoding.ASCII.GetString(toSend.ToArray()) + "'");
            socket.Send(toSend.ToArray(), 0, toSend.Count(), SocketFlags.None);
        }

        public List<byte> receiveDatas()
        {
            byte[] buffer = new byte[sizeof(Int64)];
            int readed = 0;
            List<byte> toRet = new List<byte>();
            socket.Receive(buffer, 0, sizeof(Int64), SocketFlags.None);
            Int64 size = BitConverter.ToInt64(buffer, 0);
            Console.WriteLine("Received size " + size);
            while (readed < size)
            {
                Int64 toRead = Math.Min(size - readed, 1024);
                buffer = new byte[toRead];
                Console.WriteLine("Reading from " + readed + " to " + toRead);
                readed += socket.Receive(buffer, 0, (int)toRead, SocketFlags.None);
                Console.WriteLine("BUFFER: '" + System.Text.Encoding.ASCII.GetString(buffer) + "'");
                Console.WriteLine("Readed " + readed);
                toRet.AddRange(buffer);
            }
            return (toRet);
        }
    }
}
