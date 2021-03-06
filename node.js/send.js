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
      // Send message to the queue
      ch.sendToQueue(queue, new Buffer('Hello World!'));
      console.log("Message Sent to the broker");
      return;
  });
  setTimeout(function() {
    conn.close();
    process.exit(0)
  }, 1000);
});
