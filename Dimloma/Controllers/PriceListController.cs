using Diploma.Dto;
using Diploma.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceListController : ControllerBase
    {
        IPriceListService _priceListService;
        public PriceListController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        [HttpGet("[action]")]
        public IActionResult GetDoctorPriceList(int doctorId)
        {
            var servicesPrices = _priceListService.GetDoctorPriceList(doctorId);
            return Ok(servicesPrices);
        }

        [HttpPost("[action]")]
        public IActionResult AddServicePrice(PriceListDto priceList)
        {
            _priceListService.AddServicePrice(priceList);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditServicePrice([FromBody] PriceListDto priceList)
        {
            try
            {
                var result = _priceListService.EditServicePrice(priceList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
