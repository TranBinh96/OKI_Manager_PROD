using Production.DataAccess.Data;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace Production.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db) 
    {
        _db = db;
        Line = new LineRepository(_db);
        Unit = new UnitRepository(_db);
        TypeLine = new TypeLineRepository(_db);
        Computer = new ComputerProductionRepository(_db);
        Tool = new ToolRepository(_db);
        Personnel = new PersonnelRepository(_db);
        MachineDelivery = new MachineDeliveryRepository(_db);
        SoftwareRepository = new SoftwareRepository(_db);
        DiskRepository = new DiskRepository(_db);   
    }
    public ILineRepository Line { get; private set; }
    public IUnitRepository Unit { get; private set; }
    public ITypeLineRepository TypeLine { get; private set; }
    public IComputerProductionRepository Computer { get; }
    public IDetailComputerRepository DetailComputer { get; private set; }
    public IToolRepository Tool { get; private set; }
    public IMachineDeliveryRepository MachineDelivery { get; private set; }    
    public ISoftwareRepository SoftwareRepository { get; }
    public IPersonnelRepository Personnel { get; private set; }

    public IDiskRepository DiskRepository { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }
}