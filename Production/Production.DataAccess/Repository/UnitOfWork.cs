using Bulky.DataAccess.Data;
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
    }
    public ILineRepository Line { get; private set; }
    public IUnitRepository Unit { get; private set; }
    public ITypeLineRepository TypeLine { get; private set; }
    public IComputerProductionRepository Computer { get; }
    public IDetailComputerRepository DetailComputer { get; private set; }   

    public void Save()
    {
        _db.SaveChanges();
    }
}