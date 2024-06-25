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

                // Simulate odata.metadata for the example
                string metadataUrl = Router.ApiPrefix + "/api/computer";

                // Creating the JSON response object
                var response = new
                {
                    odata = new { metadata = metadataUrl },
                    value = computers
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
