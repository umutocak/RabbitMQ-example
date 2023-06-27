using RabbitMQExample.ConsumerConsole.Examples;

namespace ConsumerConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            // Basic Example
            //BasicUsageRabbitMQ basicUsageRabbitMQ = new BasicUsageRabbitMQ();
            //basicUsageRabbitMQ.Consumer();
            // Smart Queue Example
            //SmartQueue smartQueue = new SmartQueue();
            //smartQueue.Consumer();
            // Direct Exchange Example
            //DirectExchange exchange = new DirectExchange();
            //exchange.Consumer(Convert.ToInt32(args[0]));
            // Fanout Exchange Example
            FanoutExchange exchange = new FanoutExchange();
            exchange.Consumer();
        }
    }
}