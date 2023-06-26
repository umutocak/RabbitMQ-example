using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.ConsumerConsole.Examples
{
    public class SmartQueue
    {
        public void Consumer()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("smartQueue", durable: true, false, false, null);
                /*
                   Port önceliği anlamına gelen Qos servisi ile consumer özelliği eşitlenmekte ve bu sayede eşit dağılım sağlanmaktadır.
                   prefetchSize: Mesaj boyutunu ifade ediyor. 0 verdiğimizde önemsiz kılıyoruz.
                   prefetchCount: Dağıtım adetini ifade etmektedir.
                   global: True olduğunda tüm consumerların aynı anda prefetchCount kadar mesaj tüketebileceğini ifade eder.
                   False olduğunda ise her bir consumer, bir işlem süresinde diğer consumerlardan bağımsız bir şekilde işleyeceği mesajı belirtir.
                */
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("smartQueue", false, consumer);
                consumer.Received += (sender, e) =>
                {
                    byte[] body = e.Body.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(body));
                    // Kuyruktan siliniyor.
                    channel.BasicAck(e.DeliveryTag, false);
                };
                Console.Read();
            }
        }
    }
}
