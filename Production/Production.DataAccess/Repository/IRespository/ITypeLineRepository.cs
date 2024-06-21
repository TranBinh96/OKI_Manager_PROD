using Production.Models;

namespace Production.DataAccess.Repository.IRespository;

public interface ITypeLineRepository : IRepository<TypeLine>
{
    void Update(TypeLine obj);
}