using Hazelcast;

await Task.Delay(5000);
Console.WriteLine("I'm second hazelcast client");

var options = new HazelcastOptionsBuilder().Build();
options.ClientName = "second-hazelcast-client";
options.ClusterName = "hello-world";
options.Networking.SmartRouting = false;
var client = await HazelcastClientFactory.StartNewClientAsync(options);

var map = await client.GetMapAsync<string, string>("my-distributed-map");

var firstElementFromMap = await map.GetAsync("1");

Console.WriteLine(firstElementFromMap);

Console.WriteLine("hazelcast second client finished");
Console.ReadLine();