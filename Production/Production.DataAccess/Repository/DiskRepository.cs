using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class DiskRepository : Repository<DiskInfo>, IDiskRepository
{
    private ApplicationDbContext _db;

    public DiskRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(DiskInfo obj)
    {
        _db.DiskInfo.Update(obj);
    }
}