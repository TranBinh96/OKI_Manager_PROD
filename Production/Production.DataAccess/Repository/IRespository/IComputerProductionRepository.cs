using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface IComputerProductionRepository : IRepository<Computer_Production>
{
    void Update(Computer_Production obj);
}