using FastdoServer.Core.Entities;

namespace FastdoServer.Infrastructure.Interfaces
{
	public interface IOkrRepository
	{
		Task<OkrModel> Create(string companyId, OkrModel model);
		Task<bool> Delete(string companyId, string id);
		Task<OkrModel> Get(string companyId, string id);
		Task<List<OkrModel>> GetAll(string companyId, string cycle);
		Task<List<OkrModel>> GetList(string companyId, string cycle, string user);
		Task<OkrModel> Update(string companyId, OkrModel model);
	}
}
