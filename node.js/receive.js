// Example from - https://www.rabbitmq.com/getstarted.html

// Declare amqp dependency
var amqp = require("amqplib/callback_api");
var host = "localhost";

if (process.argv[2] != null)
  host = process.argv[2];

// Create connection
amqp.connect('amqp://' + host, function(err, conn) {
  // Create channel
  conn.createChannel(function(err, ch) {
      // Define queue
      var queue = "TestQueue";
      ch.assertQueue(queue, {durable: false});
      ch.consume(queue, function(message){
         console.log("Received message from the broker %s", message.content.toString());
      }, {noAck: true});
  });
  setTimeout(function() {
    conn.close();
    process.exit(0)
  }, 1000);
});
