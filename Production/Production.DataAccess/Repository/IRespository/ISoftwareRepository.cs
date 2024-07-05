using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface ISoftwareRepository : IRepository<SoftwareInfo>
{
    void Update(SoftwareInfo obj);
}