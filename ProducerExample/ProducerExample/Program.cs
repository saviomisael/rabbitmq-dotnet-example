using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProducerExample;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "admin", Password = "admin" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("hello", false, false, false, null);

var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new User("teste@email.com", "userTest")));

channel.BasicPublish(string.Empty, "hello", null, body);
Console.WriteLine($" [x] Sent {JsonConvert.SerializeObject(new User("teste@email.com", "userTest"))}");

Console.WriteLine("Press enter to exit.");
Console.ReadLine();