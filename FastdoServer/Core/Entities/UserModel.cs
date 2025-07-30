using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FastdoServer.Core.Entities
{
  public class UserModel
  {
    [BsonId]
	public string id { get; set; }
	public string first_name { get; set; }
	public string email { get; set; }
	public string password { get; set; }
  }
}
