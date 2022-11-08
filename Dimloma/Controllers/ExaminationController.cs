using Diploma.Dto;
using Diploma.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExaminationController : ControllerBase
    {
        IExaminationService _examinationService;
        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpPost("[action]")]
        public IActionResult AddExamination(ExaminationDto examination)
        {
            _examinationService.AddExamination(examination);

            return Ok();
        }
    }
}
