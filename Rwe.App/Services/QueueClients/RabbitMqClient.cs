﻿using RabbitMQ.Client;
using Rwe.App.Abstractions;
using System.Text;
using System.Text.Json;

namespace Rwe.App.Services.QueueClients
{
    public class RabbitMqClient: IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                //Port = 15672
            };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();

            //Here we create channel with session and model
            using var channel = connection.CreateModel();
            
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("product", exclusive: false);

            //Serialize the message
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        }
    }
}