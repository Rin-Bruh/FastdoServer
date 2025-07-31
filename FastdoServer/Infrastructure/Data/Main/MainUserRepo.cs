using FastdoServer.Common.Helpers;
using FastdoServer.Core.Entities;
using MongoDB.Driver;

namespace FastdoServer.Infrastructure.Data.Main
{
  public class MainUserRepo
  {
	private readonly IMongoCollection<UserModel> _users;

	public MainUserRepo(IConfiguration config)
	{
	  var client = new MongoClient(config.GetConnectionString("MongoDb"));

	  var database = client.GetDatabase("fastdo_test");

	  _users = database.GetCollection<UserModel>("users");
	}

	public async Task<UserModel> LoginAsync(string email, string password)
	{
	  var pass = AppHelper.CreateMD5(password);

	  var user = await _users
		  .Find(u => u.email == email && u.password == pass)
		  .FirstOrDefaultAsync();

	  return user;
	}
  }
}
