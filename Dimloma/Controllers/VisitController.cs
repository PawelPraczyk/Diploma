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
        public IActionResult GetAllUserVisists(int userId)
        {
            var visits = _visitService.GetAllDoctorsVisists(userId);

            return Ok(visits);
        }

        [HttpPost("[action]")]
        public IActionResult AddVisist(VisitDto newVisit)
        {
            _visitService.AddVisit(newVisit);

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SetDiagnose([FromBody] VisitDto visit)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
