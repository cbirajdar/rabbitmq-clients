using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

/*
* Referenced from: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
*/
class Receiver
{
    public static void Main(string[] args) {
        var hostname = "localhost";
        if (args.Length > 0) hostname = args[0];
        var factory = new ConnectionFactory() { HostName = hostname };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(
                queue: "TestQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);      
            };
            channel.BasicConsume(queue: "TestQueue", noAck: true, consumer: consumer);
            Console.WriteLine("Message Received from the broker:");
        }
    }
}
