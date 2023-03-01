using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Model;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }
        [HttpGet("getPatientDetails")]
        [Authorize]
        public IActionResult GetPAtientDetails()
        {
            var getPatientDetails = _patientServices.GetPatientDetail();

            return Ok(getPatientDetails);
        }

        [HttpGet("getpatientdetailsby{id}")]
        public IActionResult getpatientdetailsbyid(Guid id)
        {
            var getpatientdetails = _patientServices.GetPatientDetailsById(id);

            return Ok(getpatientdetails);
        }
    }
}
