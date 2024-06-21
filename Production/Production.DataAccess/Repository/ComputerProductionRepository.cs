using Bulky.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class ComputerProductionRepository : Repository<Computer_Production>, IComputerProductionRepository
{
    private ApplicationDbContext _db;

    public ComputerProductionRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Computer_Production obj)
    {
        _db.Computer_Production.Update(obj);
    }
}