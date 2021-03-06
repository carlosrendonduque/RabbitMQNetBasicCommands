﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection()) 
            using (var channel= connection.CreateModel())
            {
                channel.QueueDeclare("ColaLeo123", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                 {
                     var body = ea.Body;
                     var message = Encoding.UTF8.GetString(body.ToArray());
                     Console.WriteLine("Message received {0}...", message);

                 };
                channel.BasicConsume("ColaLeo123", true, consumer);
                Console.WriteLine("Press [enter] to exit the consumer...");
                Console.ReadLine();

            }
        }
    }
}
