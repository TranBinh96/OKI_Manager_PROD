using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public object GetAll(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Line.GetAll(), loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newLine = new Line();
            JsonConvert.PopulateObject(values, newLine);
            _unitOfWork.Line.Add(newLine);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var line = _unitOfWork.Line.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, line);

            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var line = _unitOfWork.Line.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.Line.Remove(line);
            _unitOfWork.Save();
        }

    }
}
