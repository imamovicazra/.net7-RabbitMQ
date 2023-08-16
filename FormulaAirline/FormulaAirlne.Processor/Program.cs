using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to ticketing service. The message will come after you trigger publisher");

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/"
};

var connection = connectionFactory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("bookings", durable: true, exclusive: false, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"A message has been received for {message}");
};

channel.BasicConsume("bookings", true, consumer);
Console.ReadKey();
