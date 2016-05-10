using System;
using RabbitMQ.Client;
using System.Text;

/*
* Referenced from: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
*/
class Producer
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
            String message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "TestQueue", basicProperties: null, body: body);
            Console.WriteLine("Message sent to the broker: {0}", message);
        }
    }
}
