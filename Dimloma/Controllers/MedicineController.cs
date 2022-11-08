using Diploma.Dto;
using Diploma.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("[action]")]
        public IActionResult GetPatientMedicineList(int patientId)
        {
            var medicines = _medicineService.GetPatientMedicineList(patientId);

            return Ok(medicines);
        }

        [HttpPost("[action]")]
        public IActionResult AddMedicine(MedicineDto medicine)
        {
            _medicineService.AddMedicine(medicine);

            return Ok();
        }
    }
}
