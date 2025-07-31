using FastdoServer.Core.Entities;
using FastdoServer.Infrastructure.Helpers;
using FastdoServer.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace FastdoServer.Infrastructure.Data.Okr
{
  public class OkrConfigRepo : IOkrConfigRepository
  {
    private static string _collection = "okr_config";

    public async Task<OkrConfigModel> Get(string companyId)
    {
      var collection = MongoDBHelper.GetCollection<OkrConfigModel>(companyId, _collection);

      return await collection.Find(_ => true).FirstOrDefaultAsync();
    }
  }
}
