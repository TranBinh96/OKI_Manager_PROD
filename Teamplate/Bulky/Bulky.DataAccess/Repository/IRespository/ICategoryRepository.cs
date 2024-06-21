using BulkyWeb.Models;

namespace Bulky.DataAccess.Respository.IRespository;

public interface ICategoryRepository : IRepository<Category>
{
   void Update(Category obj);
}