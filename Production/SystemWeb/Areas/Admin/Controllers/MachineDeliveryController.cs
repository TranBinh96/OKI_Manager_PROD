using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MachineDeliveryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MachineDeliveryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.MachineDelivery.GetAll(), loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newMachineDelivery = new MachineDelivery();
            JsonConvert.PopulateObject(values, newMachineDelivery);   
            newMachineDelivery.DateCreate = DateTime.Now;   
            _unitOfWork.MachineDelivery.Add(newMachineDelivery);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var MachineDelivery = _unitOfWork.MachineDelivery.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, MachineDelivery);            
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var MachineDelivery = _unitOfWork.MachineDelivery.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.MachineDelivery.Remove(MachineDelivery);
            _unitOfWork.Save();
        }

    }
}
