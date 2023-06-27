using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.PublisherConsole.Examples
{
    /// <summary>
    /// Publisherin gönderdiği mesajları istediği consumerlar üzerine yönlendirmeye yarar.
    /// Bunu yapabilmek için routingKey kullanılır.
    /// </summary>
    public class DirectExchange
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
                // Direct Exchange özelliğini type ile ayarlıyoruz
                channel.ExchangeDeclare("directExchange", type: ExchangeType.Direct);
                for (int i = 0; i < 100; i++)
                {
                    byte[] message = Encoding.UTF8.GetBytes($"sayı * {i}");
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    // Duruma göre kuyruğa gönderdik
                    if (i % 2 == 0)
                        channel.BasicPublish(exchange: "directExchange", routingKey: "ciftSayilar", basicProperties: properties, body: message);
                    else
                        channel.BasicPublish(exchange: "directExchange", routingKey: "tekSayilar", basicProperties: properties, body: message);

                }
            }
        }
    }
}
