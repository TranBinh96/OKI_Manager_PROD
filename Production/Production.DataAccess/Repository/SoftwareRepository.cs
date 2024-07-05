using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class SoftwareRepository : Repository<SoftwareInfo>, ISoftwareRepository
{
    private ApplicationDbContext _db;

    public SoftwareRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(SoftwareInfo obj)
    {
        _db.SoftwareInfo.Update(obj);
    }
}