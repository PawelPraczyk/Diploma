using Diploma.Dto;

namespace Diploma.Interfaces
{
    public interface IPriceListService
    {
        void AddServicePrice(PriceListDto priceListDto);
        List<PriceListDto> GetDoctorPriceList(int doctorId);
        PriceListDto EditServicePrice(PriceListDto servicePrice);
    }
}
