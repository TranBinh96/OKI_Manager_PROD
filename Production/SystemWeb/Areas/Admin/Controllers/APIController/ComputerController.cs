using Microsoft.AspNetCore.Mvc;
using Production.DataAccess.Repository.IRespository;
using Production.Models;
using Production.Utility;
using System;
using System.Collections.Generic;

namespace SystemWeb.Areas.Admin.Controllers.APIController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComputerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetComputers()
        {
            try
            {
                // Retrieve computers from repository
                var computers = _unitOfWork.Computer.GetAll().ToList();
                var computerResponses = MapToComputerResponse(computers);
                return Ok(GetAll());
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }


        public List<ComputerResponse> MapToComputerResponse(List<Computer_Production> computers)
        {
            var computerResponses = new List<ComputerResponse>();

            foreach (var computer in computers)
            {
                var computerResponse = new ComputerResponse
                {
                    Id = computer.Id,
                    Station = computer.Station,
                    HostName = computer.HostName,
                    IP = computer.IP,
                    Rage = computer.Rage,
                    Type_Id = computer.Type_Id,
                    Unit_Id = computer.Unit_Id,
                    Line_Id = computer.Line_Id,
                    Note = computer.Note,
                    Running = computer.Running,
                    CreateDate = ComputerResponse.FormatDateTime(computer.CreateDate),
                    UpdateDate = computer.UpdateDate?.ToString("yyyy-MM-dd HH:mm:ss")
                };

                computerResponses.Add(computerResponse);
            }

            return computerResponses;
        }

        private List<DetailComputer> GetAll()
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
                    CreateDate = computer.computer.CreateDate,
                    UpdateDate = computer.computer.UpdateDate
                });
            }
            return detailComputers;
        }
    }




}
