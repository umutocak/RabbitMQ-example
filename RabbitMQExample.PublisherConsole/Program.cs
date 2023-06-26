using RabbitMQExample.PublisherConsole.Examples;

namespace PublisherConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            BasicUsageRabbitMQ basicUsageRabbitMQ = new BasicUsageRabbitMQ();
            basicUsageRabbitMQ.Publisher();
        }
    }
}