using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.ConsumerConsole.Examples
{
    public class BasicUsageRabbitMQ
    {
        public void Consumer()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                // Kuyruk adı Publish adı ile aynı olmalıdır.
                channel.QueueDeclare("messageQueue", false, false, true);
                // Mesajları yakalamak için bir event oluşturduk.
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                // Gelen ilgili mesajları kullanıyoruz.
                channel.BasicConsume("messageQueue", false, consumer);
                consumer.Received += (sender, e) =>
                {
                    byte[] body = e.Body.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(body));
                };
            }
            Console.Read();
        }
    }
}
