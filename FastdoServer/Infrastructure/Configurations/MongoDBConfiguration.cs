using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FastdoServer.Infrastructure.Configurations
{
  public class MongoDBConfiguration
  {
	private static readonly MongoClient _client;

	static MongoDBConfiguration()
	{
	  IConfiguration config = new ConfigurationBuilder()
	    .AddJsonFile("appsettings.json")
		.AddEnvironmentVariables()
		.Build();

	  string dbHost = config.GetValue<string>("MongoDB:Host") ?? "localhost";
	  string dbPort = config.GetValue<string>("MongoDB:Port") ?? "27017";
	  var connectString = $"mongodb://{dbHost}:{dbPort}/";
	  _client = new MongoClient(connectString);
	}


	public static IMongoDatabase DbConnect(string dbName)
	{
	  return _client.GetDatabase(dbName);
	} 
  }
}
