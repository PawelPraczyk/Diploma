using Diploma.DbContexts;
using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;

namespace Diploma.Services
{
    public class VisitService : IVisitService
    {
        DiplomaDbContext _context;
        public VisitService(DiplomaDbContext context)
        {
            _context = context;
        }

        public void AddVisit(VisitDto visit)
        {
            var newVisit = new Visit
            {
                Date = visit.Date,
                Diagnosis = visit.Diagnosis,
                DoctorId = visit.DoctorId,
                UserId = visit.UserId
            };

            _context.Visits.Add(newVisit);
            _context.SaveChanges();
        }

        public List<VisitDto> GetAllDoctorsVisists(int doctorId)
        {
            var visits = _context.Visits.Where(x => x.DoctorId == doctorId);

            return visits.Select(x => new VisitDto
            {
                Date = x.Date,
                Diagnosis = x.Diagnosis,
                UserId = x.UserId,
                DoctorId = x.DoctorId
            }).ToList();
        }
    }
}
