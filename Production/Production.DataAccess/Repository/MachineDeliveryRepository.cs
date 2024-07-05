using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class MachineDeliveryRepository : Repository<MachineDelivery>, IMachineDeliveryRepository
{
    private ApplicationDbContext _db;

    public MachineDeliveryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(MachineDelivery obj)
    {
        _db.MachineDeliverys.Update(obj);
    }
}