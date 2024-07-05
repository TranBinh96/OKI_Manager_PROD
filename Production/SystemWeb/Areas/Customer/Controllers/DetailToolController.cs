using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DetailToolController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailToolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*public IActionResult Index()       
        {
            return View();
        }*/

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var data = GetDetailTools();
            return DataSourceLoader.Load(data, loadOptions);
        }

        private List<DetailTools> GetDetailTools()
        {
            List<Line> lines = _unitOfWork.Line.GetAll().ToList();
            List<Unit> units = _unitOfWork.Unit.GetAll().ToList();
            List<Computer_Production> computers = _unitOfWork.Computer.GetAll().ToList();
            List<Tool> tools = _unitOfWork.Tool.GetAll().ToList();
            List<DetailTools> detailtools= new List<DetailTools>();

            var query = from computer in computers
                        join unit in units
                            on computer.Unit_Id equals unit.Id
                        join line in lines
                            on computer.Line_Id equals line.Id
                        join tool in tools
                            on computer.Id equals tool.Id
                        select new { line, unit, tool, computer };
            int i = 0;
            foreach (var item in query)
            {
                i++;
                detailtools.Add(new DetailTools
                {
                    Id = i,
                    LineName = item.line.line_name,
                    UnitName = item.unit.unit_name,
                    Station = item.computer.Station,
                    HostName = item.computer.HostName,
                    IP = item.computer.IP,                    
                    NameTool = item.tool.NameTool,
                    HourRun = item.tool.HourRun,
                    Note = item.computer.Note,
                    DateCreate= item.tool.DateCreate    
                });
            }
            return detailtools;
        }
    }
}
