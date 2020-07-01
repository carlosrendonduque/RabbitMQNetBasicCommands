using System;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public class Sender
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel= connection.CreateModel())
            {
                channel.QueueDeclare("ColaLeo123",  false, false, false, null);
                string message = "MEnsaje para Leo 12345";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "ColaLeo123", null, body);
                Console.WriteLine("Message sent : {0}...", message);

            }
            Console.Write("Press [enter] to exit Sender App...");
            Console.ReadLine();

        }
    }
}
