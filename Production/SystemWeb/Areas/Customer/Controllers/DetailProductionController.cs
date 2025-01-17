﻿using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Production.DataAccess.Repository.IRespository;
using Production.Models;

namespace SystemWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DetailProductionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailProductionController(IUnitOfWork unitOfWork)
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
            var data = GetDetailComputers();
            return DataSourceLoader.Load(data, loadOptions);
        }

        private List<DetailComputer> GetDetailComputers()
        {
            List<Line> lines = _unitOfWork.Line.GetAll().ToList();
            List<Unit> units = _unitOfWork.Unit.GetAll().ToList();
            List<TypeLine> typeLines = _unitOfWork.TypeLine.GetAll().ToList();
            List<Computer_Production> computers = _unitOfWork.Computer.GetAll().ToList();

            List<DetailComputer> detailComputers = new List<DetailComputer>();

            var query = from computer in computers
                        join unit in units
                            on computer.Unit_Id equals unit.Id
                        join line in lines
                            on computer.Line_Id equals line.Id
                        join type in typeLines
                            on computer.Type_Id equals type.Id
                        select new { line, unit, type, computer };
            int i = 0;
            foreach (var computer in query)
            {
                i++;
                detailComputers.Add(new DetailComputer
                {
                    Id = i,
                    LineName = computer.line.line_name,
                    UnitName = computer.unit.unit_name,
                    Station = computer.computer.Station,
                    HostName = computer.computer.HostName,
                    AddressIP = computer.computer.IP,
                    Rage = computer.computer.Rage,
                    Note = computer.computer.Note,
                    PersonCharge = computer.line.Manager,
                    TypePC = computer.type.Type_name,
                    CreateDate = computer.computer.CreateDate
                });
            }
            return detailComputers;
        }
    }
}
