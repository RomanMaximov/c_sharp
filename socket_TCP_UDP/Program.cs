using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socket_TCP_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TCP
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);                                 // точка подключения

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // задаем сокет(семейсьво адресов, тип сокета, тип протокола передачи)
            tcpSocket.Bind(tcpEndPoint);                                                                 // связвываем сокет и точку подключения
            tcpSocket.Listen(5);                                                                         // режим ожидания(очередь 5 подключений)

            while (true)
            {
                var listener = tcpSocket.Accept();                                 // создание нового сокета под каждого конкретного клиента
                var buffer = new byte[256];                                        // буфер для приема данных
                var size = 0;                                                      // размер данных
                var data = new StringBuilder();                                    // собирает данные в один файл

                do
                {
                    size = listener.Receive(buffer);                               // размер полученных данных
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));         // добавляет данные из буфера в файл(буфер, добавить данные начиная с байта под индексом 0, размер данных)

                } while (listener.Available > 0);

                Console.WriteLine(data);  // TODO: check .ToString               

                listener.Send(Encoding.UTF8.GetBytes("Success"));                  // отправляет ответ клиенту

                listener.Shutdown(SocketShutdown.Both);                            // закрытие соединения
                listener.Close();                                                  // прекращение режима ожидания
            }
            #endregion

            #region UDP
            //const string ip = "192.168.1.38";
            //const int port = 8081;

            //var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //udpSocket.Bind(udpEndPoint);

            //while (true)
            //{
            //    var buffer = new byte[256];
            //    var size = 0;
            //    var data = new StringBuilder();
            //    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

            //    do
            //    {
            //        size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
            //        data.Append(Encoding.UTF8.GetString(buffer));
            //    } 
            //    while (udpSocket.Available > 0);

            //    udpSocket.SendTo(Encoding.UTF8.GetBytes("Message recieved"), senderEndPoint);

            //    Console.WriteLine(data);
            //}
            #endregion
        }
    }
}
