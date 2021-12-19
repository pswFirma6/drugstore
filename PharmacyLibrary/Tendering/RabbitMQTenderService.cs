using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PharmacyLibrary.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmacyLibrary.Tendering
{
    public class RabbitMQTenderService : BackgroundService
    {
        IConnection connection;
        IModel channel;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.ExchangeDeclare("tender-exchange", type: ExchangeType.Fanout);
            channel.QueueDeclare("tender-queue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            channel.QueueBind("tender-queue", "tender-exchange", string.Empty);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, e) =>
            {
                byte[] body = e.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                TenderDto message;
                message = JsonConvert.DeserializeObject<TenderDto>(jsonMessage);
            };

            channel.BasicConsume(queue: "tender-queue",
                                    autoAck: true,
                                    consumer: consumer);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
