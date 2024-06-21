using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;
using System.Xml.Linq;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComputerProductionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComputerProductionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }

        

        [HttpGet]
        public object GetStatus(DataSourceLoadOptions loadOptions)
        {
            var status = new List<object>
            {
                new { Id = 0, Status = "Running" },
                new { Id = 1, Status = "OK" },
                new { Id = 2, Status = "Approve" }
            };
            return DataSourceLoader.Load(status, loadOptions);
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Computer.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newComputer = new Computer_Production();
            JsonConvert.PopulateObject(values, newComputer);          

            _unitOfWork.Computer.Add(newComputer);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var computer = _unitOfWork.Computer.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, computer);

            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var computer = _unitOfWork.Computer.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.Computer.Remove(computer);
            _unitOfWork.Save();
        }
    }

    public class Status
    {
        public int ID { get; set; }
        public string Status_Name { get; set; }
    }
}
