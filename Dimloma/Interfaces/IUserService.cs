using Diploma.Dto;
using Diploma.Models;

namespace Diploma.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAvailableDoctors();
        List<UserDto> GetAllPatients();
        List<UserDto> GetDoctorsPatients(int doctorId, int acceptedPatients);
        void AssigneDoctorToPatient(int doctorId, string userLogin);
        void AcceptPatient(int patientId);
        UserDto GetUser(string login);
        void Register(RegisterUserDto user);
        UserDto EditUser(UserDto user);
        int RemoveUser(string login);
        void RemovePatientAssignment(string patientLogin);
        UserDto Login(LoginUserDto userDto);
    }
}
