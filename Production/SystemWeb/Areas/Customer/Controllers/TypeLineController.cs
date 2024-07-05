using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TypeLineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeLineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */


        [HttpGet]
        public object Get (DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.TypeLine.GetAll(), loadOptions);
        }
    }
}
