using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQExample.PublisherConsole.Examples
{
    public class BasicUsageRabbitMQ
    {
        /// <summary>
        /// RabbitMQ Basic Usage
        /// </summary>
        public void Publisher()
        {
            //Bağlantı oluşturuyoruz
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                // messageQueue => Kuyruk adı
                // durable => RabbitMQ üzerindeki verileri fiziksel olarak kayıt etmeye yarar.
                // exclusive => Kuyruğa birden fazla kanalın bağlanıp bağlanamacağını bildirir.
                // autoDelete => True değerine karşılık tüm mesajlar bitince kuyruğu otomatik siler.
                channel.QueueDeclare("messageQueue", false, false, true);
                // RabbitMQ byte veri tipini destekler. Tüm verileriniz byte tipine dönüştürülüp rabbit tarafına iletilmelidir. 
                byte[] message = Encoding.UTF8.GetBytes("Başlangıç düzeyde RabbitMQ");
                // Kanal üzerinden mesajı gönderiyoruz.
                channel.BasicPublish(exchange: "", routingKey: "messageQueue", body: message);

            }
        }
    }
}
