using RabbitMQExample.PublisherConsole.Examples;

namespace PublisherConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            // Basic Usage Example
            BasicUsageRabbitMQ basicUsageRabbitMQ = new BasicUsageRabbitMQ();
            basicUsageRabbitMQ.Publisher();
            // Smart Queue Example
            SmartQueue smartQueue = new SmartQueue();
            smartQueue.Publisher();
        }
    }
}