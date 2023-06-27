using RabbitMQExample.PublisherConsole.Examples;

namespace PublisherConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            // Basic Usage Example
            //BasicUsageRabbitMQ basicUsageRabbitMQ = new BasicUsageRabbitMQ();
            //basicUsageRabbitMQ.Publisher();
            // Smart Queue Example
            //SmartQueue smartQueue = new SmartQueue();
            //smartQueue.Publisher();
            //Direct Exchange Example
            //DirectExchange exchange = new DirectExchange();
            //exchange.Publisher();
            // Fanout Exchange Example
            FanoutExchange exchange = new FanoutExchange();
            exchange.Publisher();
        }
    }
}