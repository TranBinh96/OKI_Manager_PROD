using Microsoft.AspNetCore.Mvc;
using Production.DataAccess.Repository.IRespository;
using Production.Models;
using Production.Utility;

namespace SystemWeb.Areas.Admin.Controllers.APIController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwareController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SoftwareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{hostname}")]
        public IActionResult GetSoftwareByHostName(string hostname)
        {
            try
            {
                Computer_Production computer = _unitOfWork.Computer.GetFirstOrDefault(x=> x.HostName == hostname);
                if (computer != null)
                {
                    var softwareInfos = _unitOfWork.SoftwareRepository.GetAll(x=> x.IP == computer.IP).ToList();
                    return Ok(softwareInfos);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("disk/{hostname}")]
        public IActionResult GetDiskByHostName(string hostname)
        {
            try
            {
                Computer_Production computer = _unitOfWork.Computer.GetFirstOrDefault(x => x.HostName == hostname);
                if (computer != null)
                {
                    var softwareInfos = _unitOfWork.DiskRepository.GetAll(x => x.IP == computer.IP).ToList();
                    return Ok(softwareInfos);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
