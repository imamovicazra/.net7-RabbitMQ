using FormulaAirline.Service.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FormulaAirline.Service.Implementation
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            if (message == null)
                throw new ArgumentNullException("Message is null");

            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "password",
                VirtualHost = "/"
            };

            var connection = connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("bookings", durable: true, exclusive: false, false, null);

            var jsonString = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "bookings", body: body);
        }
    }
}
