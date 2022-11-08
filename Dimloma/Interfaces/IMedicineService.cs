using Diploma.Dto;
using Diploma.Models;

namespace Diploma.Interfaces
{
    public interface IMedicineService
    {
        void AddMedicine(MedicineDto medicine);
        List<MedicineDto> GetPatientMedicineList(int patientId);
    }
}
