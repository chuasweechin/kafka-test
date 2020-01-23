using System;
using Confluent.Kafka;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kafka_producer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : Controller
  {
    // GET: /<controller>/
    [Route("{something?}")]
    public async Task<string> Index(string something)
		{
    var config = new ProducerConfig {
			BootstrapServers = "localhost:9092"
		};

		// If serializers are not specified, default serializers from
		// `Confluent.Kafka.Serializers` will be automatically used where
		// available. Note: by default strings are encoded as UTF8.
    using (var p = new ProducerBuilder<Null, string>(config).Build())
    {
        try
        {
          var dr = await p.ProduceAsync("test_topic", new Message<Null, string> { Value = something ?? "Missing value" });
          Console.WriteLine($"Delivered '{ dr.Value }' to '{ dr.TopicPartitionOffset }'");
        }
        catch (ProduceException<Null, string> e)
        {
          Console.WriteLine($"Delivery failed: { e.Error.Reason }");
        }
     }

      return something ?? "Missing value";
	}
  }
}
