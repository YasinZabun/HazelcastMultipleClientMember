using Hazelcast;

Console.WriteLine("I'm first hazelcast client");

var options = new HazelcastOptionsBuilder().Build();
options.ClientName = "first-hazelcast-client";
options.ClusterName = "hello-world";
options.Networking.SmartRouting = false;
var client = HazelcastClientFactory.StartNewClientAsync(options).Result;

var map = await client.GetMapAsync<string, string>("my-distributed-map");


await map.PutAsync("1", "John");
await map.PutAsync("2", "Mary");
await map.PutAsync("3", "Jane");

Console.WriteLine("hazelcast first client finished");
Console.ReadLine();