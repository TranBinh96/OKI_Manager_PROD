using Bulky.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    private ApplicationDbContext _db;

    public UnitRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Unit obj)
    {
        _db.Unit.Update(obj);
    }
}