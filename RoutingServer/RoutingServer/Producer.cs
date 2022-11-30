using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using ISession = Apache.NMS.ISession;
using IConnection = Apache.NMS.IConnection;

namespace RoutingServer
{
    internal class Producer
    {
        Uri connecturi;
        ConnectionFactory connectionFactory;
        IConnection connection;
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

        public void sendMessage(string messageToSend)
        {
            ITextMessage message = session.CreateTextMessage(messageToSend);
            producer.Send(message);
        }

        public void closeConnection()
        {
            session.Close();
            connection.Close();
        }
    }
}
