using Diploma.DbContexts;
using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;

namespace Diploma.Services
{
    public class MedicineService : IMedicineService
    {
        DiplomaDbContext _context;

        public MedicineService(DiplomaDbContext context)
        {
            _context = context;
        }

        public void AddMedicine(MedicineDto medicine)
        {
            var newMedicine = new Medicine()
            {
                AfterFood = medicine.AfterFood,
                Dose = medicine.Dose,
                Name = medicine.Name,
                Time = medicine.Time,
                UserId = medicine.UserId
            };
            _context.Medicines.Add(newMedicine);
            _context.SaveChanges();
        }

        public List<MedicineDto> GetPatientMedicineList(int patientId)
        {
            var medicines = _context.Medicines.Where(x => x.UserId == patientId);
            return medicines.Select(x => new MedicineDto
            {
                Dose = x.Dose,
                AfterFood = x.AfterFood,
                Name = x.Name,
                Time = x.Time,
                UserId = x.UserId
            }).ToList();
        }
    }
}
