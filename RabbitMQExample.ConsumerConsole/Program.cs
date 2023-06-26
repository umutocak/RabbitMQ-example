using RabbitMQExample.ConsumerConsole.Examples;

namespace ConsumerConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            BasicUsageRabbitMQ basicUsageRabbitMQ = new BasicUsageRabbitMQ();
            basicUsageRabbitMQ.Consumer();
        }
    }
}