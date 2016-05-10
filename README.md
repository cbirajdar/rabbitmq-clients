### <u>Clients (Java, Node.js, C#) to connect to RabbitMQ brokers

Before executing these programs, make sure you have rabbitmq server running locally or remotely.

#### <u>Node.js

- ```cd node.js```
- ```npm install amqplib```
- To send, ```node send.js $host```
- To receive, ```node receive.js $host```

#### <u>C#

For Unix/Linux, you can install mono (cross platform open source .NET framework)

<b>Compile</b>
```
mcs /r:"RabbitMQ.Client.dll" producer.cs
mcs /r:"RabbitMQ.Client.dll" consumer.cs
```

<b>Run</b>
```
mono producer.exe $host
mono consumer.exe $host
```

#### <u>Java
```
cd java
gradle execute -PjvmArgs="-Dhost=$host"
```
