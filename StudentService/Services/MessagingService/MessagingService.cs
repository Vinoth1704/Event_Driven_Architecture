using System.Text;
using RabbitMQ.Client;
using StudentService.Models;

namespace StudentService.Services
{
    public class MessagingService : IMessagingService
    {
        public void SendMessage(string student)
        {
            var factory = new ConnectionFactory() { HostName = "localHost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            //Direct Method
            channel.ExchangeDeclare(exchange: "Direct", type: ExchangeType.Direct);
            var message = student;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "Direct",
                                routingKey: "Create",
                                basicProperties: null,
                                body: body);
        }
    }

}