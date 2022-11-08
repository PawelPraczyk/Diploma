using Diploma.Dto;
using Diploma.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase
    {
        IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllDoctorsVisists(int doctorId)
        {
            var visits = _visitService.GetAllDoctorsVisists(doctorId);

            return Ok(visits);
        }

        [HttpPost("[action]")]
        public IActionResult AddVisist(VisitDto newVisit)
        {
            _visitService.AddVisit(newVisit);

            return Ok();
        }

        // Postaw diagnozę 
    }
}
