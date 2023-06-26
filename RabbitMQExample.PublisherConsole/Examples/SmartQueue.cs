using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.PublisherConsole.Examples
{
    /// <summary>
    /// Smart Queue (Akıllı kuyruk mimarisi) : Gelen mesajları güvenli bir şekilde tutup
    /// eşit bir dağılım ile tüketilip, tüketilen mesajlara dair haberdar edilmesidir.
    /// </summary>
    public class SmartQueue
    {
        public void Publisher()
        {
            string[] names = new string[] { "Umut", "Ufuk", "Fatih", "Mehmet", "Furkan", "Burak", "Tufan", "Enes" };
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("smartQueue",durable: true, false, false, null);
                for (int i = 0; i < names.Length; i++)
                {
                    byte[] message = Encoding.UTF8.GetBytes(names[i]);
                    // Bir nesne oluşturuyoruz. Bu nesnenin Persistent özelliği ile RabbitMQ' da fiziksel kayda alıyor ve kalıcılığı sağlıyoruz.
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    /*
                     basicProperties kısmına oluşturmuş olduğumuz nesneyi vererek güvenirliği sağlıyoruz.
                     Buraya kadar olan kısım Message Durability olarak adlandırılıyor.
                     */
                    channel.BasicPublish(exchange: "", routingKey: "smartQueue", basicProperties: properties, body: message);
                }
            }
        }
    }
}
