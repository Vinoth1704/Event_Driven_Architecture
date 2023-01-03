using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SubjectService.Models;

namespace SubjectService.Services
{
    public class MessagingService : IMessagingService
    {
        private IStudentService _studentService;
        public MessagingService()
        {

        }
        public MessagingService(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void checkMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            //Direct Method
            channel.ExchangeDeclare(exchange: "Direct", ExchangeType.Direct);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "Direct", routingKey: "Create");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JsonConvert.DeserializeObject<Student>(message);
                var type = ea.RoutingKey;
                Student s = new Student() { StudentID = data!.StudentID, StudentName = data!.StudentName };
                // s.StudentID = data.StudentID;
                // s.StudentName = data.StudentName;
                Console.WriteLine($"Running + {s.StudentID}");
                try
                {
                    Console.WriteLine($"{s.StudentID + " " + s.StudentName}");
                    bool v = _studentService.CreateStudent(s);
                }
                catch
                {
                    Console.WriteLine("Failed");
                    throw;
                }
                Console.WriteLine(message);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}