using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FastdoServer.Core.Entities
{
	[BsonIgnoreExtraElements]
	public class BaseEntity
	{
		[BsonId]
		public string id { get; set; }
		public long created_at { get; set; }
		public long updated_at { get; set; }

		[BsonIgnore]
		[JsonIgnore]
		public bool is_edit { get; set; }
	}
}
