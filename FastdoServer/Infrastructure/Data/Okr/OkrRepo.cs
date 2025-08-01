using FastdoServer.Core.Entities;
using FastdoServer.Infrastructure.Helpers;
using FastdoServer.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace FastdoServer.Infrastructure.Data.Okr
{
  public class OkrRepo : IOkrRepository
  {
	  private static string _collection = "okrs";

	  public async Task<OkrModel> Create(string companyId, OkrModel model)
	  {
	    var collection = MongoDBHelper.GetCollection<OkrModel>(companyId, _collection);

	    model.id = SystemHelper.RandomId();
	    model.date_create = DateTime.Now.Ticks;
	    model.delete = false;

	    await collection.InsertOneAsync(model);

	    return model;
	  }


	  public async Task<OkrModel> Update(string companyId, OkrModel model)
	  {
	    var collection = MongoDBHelper.GetCollection<OkrModel>(companyId, _collection);

	    var filter = Builders<OkrModel>.Filter.Eq(x => x.id, model.id);

	    var result = await collection.ReplaceOneAsync(filter, model);

	    return result.IsAcknowledged && result.ModifiedCount > 0 ? model : null;
	  }


	  public async Task<bool> Delete(string companyId, string id)
	  {
	    var collection = MongoDBHelper.GetCollection<OkrModel>(companyId, _collection);

	    var filter = Builders<OkrModel>.Filter.Eq(x => x.id, id);

	    var update = Builders<OkrModel>.Update.Set(x => x.delete, true);

	    var result = await collection.UpdateOneAsync(filter, update);

	    return result.IsAcknowledged && result.ModifiedCount > 0;
	  }


	  public async Task<OkrModel> Get(string companyId, string id)
	  {
		  throw new NotImplementedException();
	  }


	  public async Task<List<OkrModel>> GetAll(string companyId, string cycle)
	  {
	    var collection = MongoDBHelper.GetCollection<OkrModel>(companyId, _collection);

	    var filter = Builders<OkrModel>.Filter.And(
		    Builders<OkrModel>.Filter.Eq(x => x.cycle, cycle),
		    Builders<OkrModel>.Filter.Eq(x => x.delete, false)
	    );

	    var result = await collection.Find(filter).ToListAsync();

	    return result;
	  }


	  public async Task<List<OkrModel>> GetList(string companyId, string cycle, string user)
	  {
	    var collection = MongoDBHelper.GetCollection<OkrModel>(companyId, _collection);

	    var filter = Builders<OkrModel>.Filter.And(
		    Builders<OkrModel>.Filter.Eq(x => x.cycle, cycle),
		    Builders<OkrModel>.Filter.Eq(x => x.user_create, user),
		    Builders<OkrModel>.Filter.Eq(x => x.delete, false)
	    );

	    var result = await collection.Find(filter).ToListAsync();

	    return result;
	  }
  }
}
