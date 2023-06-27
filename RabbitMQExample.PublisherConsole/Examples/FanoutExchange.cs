using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.PublisherConsole.Examples
{
    /// <summary>
    /// Alınan mesajları doğrudan bütün kuyruklara aktarılır. İlgili kuyrukları dinleyen
    /// bütün consumerlar bu mesajı işlemektedir.
    /// Bu Algoritma örneğinde bir kuyruk oluşturmaya gerek yoktur, Exchange ilgili 
    /// kuyrukları otomatik oluşturmaktadır.
    /// </summary>
    public class FanoutExchange
    {
        public void Publisher()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                // Exchange oluşturuyoruz ve tipini Fanout yapıyoruz.
                channel.ExchangeDeclare("fonoutExchange", type: ExchangeType.Fanout);
                for (int i = 0; i <= 100; i++)
                {
                    byte[] message = Encoding.UTF8.GetBytes($"numara - {i}");
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    channel.BasicPublish(exchange: "fonoutExchange", routingKey: "", basicProperties: properties, body: message);
                }
            }
        }
    }
}
