import com.rabbitmq.client.*;

import java.io.IOException;
import java.util.concurrent.TimeoutException;

public class RabbitMqMessageBroker {

    private final String QUEUE = "TestQueue";

    private final String hostname = System.getProperty("host");

    private Connection connection;

    private Channel channel;

    RabbitMqMessageBroker() throws Exception {
        createConnection();
    }

    private void createConnection() throws IOException, TimeoutException {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        connectionFactory.setHost(hostname);
        connection = connectionFactory.newConnection();
        channel = connection.createChannel();
        channel.queueDeclare(QUEUE, false, false, false, null);
    }

    public void send() throws IOException {
        channel.basicPublish("", QUEUE, null, "Hello World!".getBytes());
    }

    public void receive() throws IOException {
        Consumer consumer = new DefaultConsumer(channel) {
            @Override public void handleDelivery(String consumerTag, Envelope envelope, AMQP.BasicProperties properties, byte[] body) throws IOException {
                String message = new String(body, "UTF-8");
                System.out.println(message);
            }
        };
        channel.basicConsume(QUEUE, true, consumer);
    }

    public void close() throws IOException, TimeoutException {
        channel.close();
        connection.close();
    }
}
