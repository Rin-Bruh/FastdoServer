using FastdoServer.Core.Entities;

namespace FastdoServer.Infrastructure.Interfaces
{
  public interface IOkrConfigRepository
  {
    Task<OkrConfigModel> Get(string companyId);
  }
}
