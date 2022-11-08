using Diploma.Dto;
using Diploma.Models;

namespace Diploma.Interfaces
{
    public interface IVisitService
    {
        void AddVisit(VisitDto visit);
        List<VisitDto> GetAllDoctorsVisists(int doctorId);
    }
}
