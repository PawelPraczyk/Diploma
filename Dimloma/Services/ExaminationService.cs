using Diploma.DbContexts;
using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;

namespace Diploma.Services
{
    public class ExaminationService : IExaminationService
    {
        DiplomaDbContext _context;
        public ExaminationService(DiplomaDbContext context)
        {
            _context = context;
        }

        public void AddExamination(ExaminationDto examination)
        {
            var newExamination = new Examination
            {
                Name = examination.Name,
                IsRight = examination.IsRight,
                Results = examination.Results,
                UserId = examination.UserId
            };

            _context.Examinations.Add(newExamination);
            _context.SaveChanges();
        }
    }
}
