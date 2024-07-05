namespace Production.DataAccess.Repository.IRespository;

public interface IUnitOfWork
{
    ILineRepository Line {  get; }
    IUnitRepository Unit {  get; }
    ITypeLineRepository TypeLine { get; }
    IComputerProductionRepository Computer {  get; }
    IToolRepository Tool { get; }
    IPersonnelRepository Personnel { get; }
    IMachineDeliveryRepository MachineDelivery { get; }
    ISoftwareRepository  SoftwareRepository { get; }
    IDiskRepository DiskRepository { get; } 
    void Save();
}