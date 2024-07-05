using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class ToolRepository : Repository<Tool>, IToolRepository
{
    private ApplicationDbContext _db;

    public ToolRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Tool obj)
    {
        _db.Tools.Update(obj);
    }
}