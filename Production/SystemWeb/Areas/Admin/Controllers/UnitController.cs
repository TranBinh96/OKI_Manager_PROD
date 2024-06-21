using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object GetAll (DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Unit.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newUnit = new Unit();
            JsonConvert.PopulateObject(values, newUnit);
            _unitOfWork.Unit.Add(newUnit);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, unit);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.Unit.Remove(unit);
            _unitOfWork.Save();
        }
    }
}
