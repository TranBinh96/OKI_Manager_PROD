using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class TypeLineRepository : Repository<TypeLine>, ITypeLineRepository
{
    private ApplicationDbContext _db;

    public TypeLineRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(TypeLine obj)
    {
        _db.TypeLine.Update(obj);
    }
}