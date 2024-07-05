using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UnitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public object Get (DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Unit.GetAll(), loadOptions);
        }
    }
}
