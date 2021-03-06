using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
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
        private readonly DatabaseContext databaseContext = new DatabaseContext();
        private TenderService tenderService;
        private HospitalService hospitalService;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            ITenderRepository repository = new TenderRepository(databaseContext);
            IHospitalRepository hospitalRepository = new HospitalRepository(databaseContext);
            tenderService = new TenderService(repository);
            hospitalService = new HospitalService(hospitalRepository);
            List<Hospital> hospitals = hospitalService.GetAll();
            Console.WriteLine(hospitals.Count);
            foreach (Hospital hospital in hospitals) {

                var factory = new ConnectionFactory
                {
                    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
                };

                connection = factory.CreateConnection();
                channel = connection.CreateModel();

                channel.ExchangeDeclare("tender-exchange-"+hospital.HospitalConnectionInfo.ApiKey, type: ExchangeType.Fanout);
                channel.QueueDeclare("tender-queue-"+hospital.HospitalConnectionInfo.ApiKey,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                channel.QueueBind("tender-queue-" + hospital.HospitalConnectionInfo.ApiKey, "tender-exchange-" + hospital.HospitalConnectionInfo.ApiKey, string.Empty);
                Console.WriteLine(hospital.HospitalConnectionInfo.ApiKey);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, e) =>
                {
                    Console.WriteLine("Drugstore: consumer.Received");
                    byte[] body = e.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);
                    TenderDto message;
                    Console.WriteLine("Drugstore-json message: " + jsonMessage);
                    message = JsonConvert.DeserializeObject<TenderDto>(jsonMessage);
                    tenderService.AddTender(message);
                };

                channel.BasicConsume(queue: "tender-queue-" + hospital.HospitalConnectionInfo.ApiKey,
                                        autoAck: true,
                                        consumer: consumer);
            }

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

