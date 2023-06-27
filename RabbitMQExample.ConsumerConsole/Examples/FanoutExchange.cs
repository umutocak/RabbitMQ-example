using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.ConsumerConsole.Examples
{
    public class FanoutExchange
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
                channel.ExchangeDeclare("fanoutExchange", type: ExchangeType.Fanout);

                // Rastgele queue ismi oluşturuyoruz.
                string queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: "fanoutExchange", routingKey: "");
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queueName, false, consumer);
                consumer.Received += (sender, e) =>
                {
                    byte[] body = e.Body.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(body) + " alındı");
                    channel.BasicAck(e.DeliveryTag, false);
                };
                Console.Read();
            }
        }
    }
}
