using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class LineRepository : Repository<Line>, ILineRepository
{
    private ApplicationDbContext _db;

    public LineRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Line obj)
    {
        _db.Line.Update(obj);
    }
}