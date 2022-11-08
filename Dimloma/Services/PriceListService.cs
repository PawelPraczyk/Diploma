using Diploma.DbContexts;
using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;

namespace Diploma.Services
{
    public class PriceListService : IPriceListService
    {
        DiplomaDbContext _context;
        public PriceListService(DiplomaDbContext context)
        {
            _context = context; 
        }
        public void AddServicePrice(PriceListDto priceListDto)
        {
            var newPriceService = new PriceList
            {
                DoctorId = priceListDto.DoctorId,
                Name = priceListDto.Name,
                Price = priceListDto.Price
            };

            _context.ServicesPrices.Add(newPriceService);
            _context.SaveChanges();
        }

        public List<PriceListDto> GetDoctorPriceList(int doctorId)
        {
            var servicePrices = _context.ServicesPrices.Where(x => x.DoctorId == doctorId).Select(x => new PriceListDto
            {
                DoctorId = x.DoctorId,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return servicePrices;
        }

        public PriceListDto EditServicePrice(PriceListDto servicePrice)
        {
            var uservicePriceToEdit = _context.ServicesPrices.FirstOrDefault(x => x.PriceId == servicePrice.PriceId);

            uservicePriceToEdit.Name = servicePrice.Name;
            uservicePriceToEdit.Price = servicePrice.Price;

            _context.SaveChanges();

            return servicePrice;
        }
    }
}
