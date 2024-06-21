using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TypeLineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeLineController(IUnitOfWork unitOfWork)
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

            return DataSourceLoader.Load(_unitOfWork.TypeLine.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newType = new TypeLine();
            JsonConvert.PopulateObject(values, newType);
            _unitOfWork.TypeLine.Add(newType);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var type = _unitOfWork.TypeLine.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, type);

            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var type = _unitOfWork.TypeLine.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.TypeLine.Remove(type);
            _unitOfWork.Save();
        }
    }
}
