using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonnelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonnelController(IUnitOfWork unitOfWork)
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
            var data = _unitOfWork.Personnel.GetAll();
            return DataSourceLoader.Load(_unitOfWork.Personnel.GetAll(), loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newPersonnel = new Personnel();
            JsonConvert.PopulateObject(values, newPersonnel);            
            _unitOfWork.Personnel.Add(newPersonnel);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var Personnel = _unitOfWork.Personnel.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, Personnel);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var Personnel = _unitOfWork.Personnel.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.Personnel.Remove(Personnel);
            _unitOfWork.Save();
        }

    }
}
