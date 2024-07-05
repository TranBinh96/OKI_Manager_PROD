using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class PersonnelRepository : Repository<Personnel>, IPersonnelRepository
{
    private ApplicationDbContext _db;

    public PersonnelRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Personnel obj)
    {
        _db.Personnel.Update(obj);
    }
}