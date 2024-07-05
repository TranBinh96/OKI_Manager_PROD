using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface IDiskRepository : IRepository<DiskInfo>
{
    void Update(DiskInfo obj);
}