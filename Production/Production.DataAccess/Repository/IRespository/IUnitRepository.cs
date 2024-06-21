using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface IUnitRepository : IRepository<Unit>
{
    void Update(Unit obj);
}