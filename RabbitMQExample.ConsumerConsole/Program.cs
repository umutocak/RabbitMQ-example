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

            DirectExchange exchange = new DirectExchange();
            exchange.Consumer(Convert.ToInt32(args[0]));
        }
    }
}