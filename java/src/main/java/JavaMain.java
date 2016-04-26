public class JavaMain {
    public static void main(String[] args) throws Exception {
        RabbitMqMessageBroker broker = new RabbitMqMessageBroker();
        broker.send();
        broker.receive();
        broker.close();
    }
}
