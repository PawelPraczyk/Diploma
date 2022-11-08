using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult GetUser(string login)
        {
            var user = _userService.GetUser(login);

            return Ok(user);
        }

        [HttpGet("[action]")]
        public IActionResult GetAvailableDoctors()
        {
            var doctors = _userService.GetAvailableDoctors();

            return Ok(doctors);
        }

        [HttpGet("[action]")]
        public IActionResult GetAllPatients()
        {
            var doctors = _userService.GetAllPatients();

            return Ok(doctors);
        }

        [HttpGet("[action]")]
        public IActionResult GetDoctorsPatients(int doctorId, bool acceptedPatients)
        {
            var doctors = _userService.GetDoctorsPatients(doctorId, acceptedPatients ? 1 : 0);

            return Ok(doctors);
        }

        [HttpPost("[action]")]
        public IActionResult LoginUser(LoginUserDto user)
        {
            try
            {
                var loggedUser = _userService.Login(user);
                return Ok(loggedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }

        [HttpPost("[action]")]
        public IActionResult RegisterUser(RegisterUserDto user)
        {
            _userService.Register(user);

            return Ok();
        }


        [HttpPost("[action]")]
        public IActionResult AssigneDoctorToPatient(int doctorId, string userLogin)
        {
            try
            {
                _userService.AssigneDoctorToPatient(doctorId, userLogin);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("[action]")]
        public IActionResult AcceptPatient(int patientId)
        {
            try
            {
                _userService.AcceptPatient(patientId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditUser([FromBody] UserDto userDto)
        {
            try
            {
                var result = _userService.EditUser(userDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("[action]/{patientLogin}")]
        public async Task<IActionResult> RemovePatientAssignment(string patientLogin)
        {
            if (patientLogin == null)
            {
                return BadRequest();
            }

            try
            {
                _userService.RemovePatientAssignment(patientLogin);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("[action]/{login}")]
        public async Task<IActionResult> RemoveUser(string login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            try
            {
                var removeResult = _userService.RemoveUser(login);

                return Ok(removeResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
