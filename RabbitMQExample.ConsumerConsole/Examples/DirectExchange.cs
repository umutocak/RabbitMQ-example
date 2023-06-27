using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.ConsumerConsole.Examples
{
    public class DirectExchange
    {
        public void Consumer(int value)
        {
            ConnectionFactory factory = new ConnectionFactory();
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("directExchange", type: ExchangeType.Direct);
                string queueName = channel.QueueDeclare().QueueName;
                if (value == 1)
                {
                    channel.QueueBind(queue: queueName, exchange: "directExchange", routingKey: "tekSayilar");
                }
                else
                {
                    channel.QueueBind(queue: queueName, exchange: "directExchange", routingKey: "ciftSayilar");
                }
                
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queueName, false, consumer);
                consumer.Received += (sender, e) =>
                {
                    byte[] body = e.Body.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(body) + "sayısı alındı");
                    channel.BasicAck(e.DeliveryTag, false);
                };
                Console.Read();

            }
        }
    }
}
