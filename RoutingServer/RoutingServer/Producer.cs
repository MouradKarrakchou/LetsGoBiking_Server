using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;


namespace RoutingServer
{
    internal class Producer
    {
        Uri connecturi;
        ConnectionFactory connectionFactory;
        Connection connection;
        ISession session;
        IDestination destination;
        IMessageProducer producer;
        public Producer()
        {
            // Create a Connection Factory.
            connecturi = new Uri("activemq:tcp://localhost:61616");
            connectionFactory = new ConnectionFactory(connecturi);

            // Create a single Connection from the Connection Factory.
            connection = connectionFactory.CreateConnection();
            session = connection.CreateSession();
            destination = session.GetQueue("test");

            // Create a Producer targetting the selected queue.
            producer = session.CreateProducer(destination);
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

        }

        public void sendMessage(string message)
        {
            ITextMessage message = session.CreateTextMessage(message);
            producer.Send(message);
        }

        public void closeConnection()
        {
            session.Close();
            connection.Close();
        }
    }
}
