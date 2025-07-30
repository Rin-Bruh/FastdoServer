using MongoDB.Driver;
using System.Collections.Concurrent;
using FastdoServer.Infrastructure.Configurations;

namespace FastdoServer.Infrastructure.Helpers
{
  public class MongoDBHelper
  {
    private static readonly ConcurrentDictionary<string, IMongoDatabase> _databases = new();

    public static IMongoDatabase GetDatabase(string companyId)
    {
      var dbName = $"fastdo_test_{companyId}";

      return _databases.GetOrAdd(dbName, name => MongoDBConfiguration.DbConnect(dbName));
    }

    /// <summary>
    /// Get collection by company
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="companyId"></param>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IMongoCollection<T> GetCollection<T>(string companyId, string collection)
    {
      var dbName = $"fastdo_test_{companyId}";

      var database = _databases.GetOrAdd(dbName, name => MongoDBConfiguration.DbConnect(dbName));

      return database.GetCollection<T>(collection);
    }


    /// <summary>
    /// Get colection from fastdo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IMongoCollection<T> GetCollectionByFastdo<T>(string collection)
    {
      var dbName = "fastdo_test";
      var database = _databases.GetOrAdd(dbName, name => MongoDBConfiguration.DbConnect(dbName));
      
      return database.GetCollection<T>(collection);
    }
  }
}
