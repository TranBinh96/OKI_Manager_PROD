using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface ILineRepository : IRepository<Line>
{
    void Update(Line obj);
}