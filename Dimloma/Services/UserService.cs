using Diploma.DbContexts;
using Diploma.Dto;
using Diploma.Interfaces;
using Diploma.Models;

namespace Diploma.Services
{
    public class UserService : IUserService
    {
        DiplomaDbContext _context;
        public UserService(DiplomaDbContext context)
        {
            _context = context;
        }
        public List<UserDto> GetAvailableDoctors()
        {
            var availableDoctors = (from user in _context.Users
                                    where user.AssignedPatientsCount < 20 && user.Role == 1
                                    select new UserDto
                                    {
                                        UserId = user.UserId,
                                        Name = user.Name,
                                        Surname = user.Surname,
                                        City = user.City,
                                        Street = user.Street

                                    }).ToList();

            return availableDoctors;
        }

        public UserDto GetUser(string login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login);

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                DateOfBirth = user.DateOfBirth,
                Diseases = user.Diseases,
                AssignedDoctor = user.AssignedDoctor,
                City = user.City,
                Street = user.Street,
                PostalCode = user.PostalCode,
                PersonalNumber = user.PersonalNumber,
                AssignedPatientsCount = user.AssignedPatientsCount,
                Role = user.Role
            };
        }

        public UserDto Login(LoginUserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == userDto.Login.ToLower());

            if (user == null)
            {
                throw new Exception("User with given login doesn't exists.");
            }

            if (user.Password == userDto.Password)
            {
                return new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Surname = user.Surname,
                    Login = user.Login,
                    DateOfBirth = user.DateOfBirth,
                    Diseases = user.Diseases,
                    AssignedDoctor = user.AssignedDoctor,
                    City = user.City,
                    Street = user.Street,
                    PostalCode = user.PostalCode,
                    PersonalNumber = user.PersonalNumber,
                    AssignedPatientsCount = user.AssignedPatientsCount,
                    Role = user.Role
                };
            }
            else
            {
                throw new Exception("Password is invalid.");
            }
        }

        public void Register(RegisterUserDto userDto)
        {
            if (UserExists(userDto.Login))
            {
                throw new Exception($"User with {userDto.Login} login alredy exists.");
            }

            var user = new User
            {
                Login = userDto.Login.ToLower(),
                Password = userDto.Password,
                Role = userDto.Role,
                Name = userDto.Name,
                Surname = userDto.Surname,
                DateOfBirth = userDto.DateOfBirth
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //public void InitDataBase()
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        var users = new User
        //        {
        //            Name = Faker.Name.First(),
        //            Surname = Faker.Name.Last(),
        //            Login = Faker.Internet.UserName(),
        //            DateOfBirth = Faker.Identification.DateOfBirth(),
        //            Role = 0,
        //            Password = Faker.Identification.BulgarianPin()
        //        };

        //        _context.Users.Add(users);
        //    }

        //    for (int i = 0; i < 10; i++)
        //    {
        //        var users = new User
        //        {
        //            Name = Faker.Name.First(),
        //            Surname = Faker.Name.Last(),
        //            Login = Faker.Name.Suffix(),
        //            DateOfBirth = Faker.Identification.DateOfBirth(),
        //            Role = 1,
        //            Password = Faker.Identification.BulgarianPin()
        //        };

        //        _context.Users.Add(users);
        //    }

        //    _context.SaveChanges();

        //    var patients = _context.Users.Where(x => x.Role == 0).ToList();

        //    foreach (var patient in patients)
        //    {
        //        var medicine = new Medicine
        //        {
        //            Name = Faker.Company.Name(),
        //            Time = "Rano",
        //            Dose = "2 tabletki rano",
        //            AfterFood = Faker.RandomNumber.Next(0, 1),
        //            UserId = patient.UserId
        //        };
        //    }

        //    for (int i = 0; i < 30; i++)
        //    {
        //        var visit = new Visit
        //        {
        //            /
        //        }
        //    }

        //}

        public UserDto EditUser(UserDto user)
        {
            var userToEdit = _context.Users.FirstOrDefault(x => x.Login == user.Login);

            if (userToEdit == null)
            {
                throw new Exception("User with given login doesn't exists.");
            }

            userToEdit.Name = user.Name;
            userToEdit.Surname = user.Surname;
            userToEdit.DateOfBirth = user.DateOfBirth;
            userToEdit.PersonalNumber = user.PersonalNumber;
            userToEdit.AssignedDoctor = user.AssignedDoctor;
            userToEdit.City = user.City;
            userToEdit.Street = user.Street;
            userToEdit.Diseases = user.Diseases;
            userToEdit.PostalCode = user.PostalCode;

            _context.SaveChanges();

            return user;
        }

        public int RemoveUser(string login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user == null) return -1;

            _context.Users.Remove(user);

            return _context.SaveChanges();
        }

        public void AssigneDoctorToPatient(int doctorId, string userLogin)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == userLogin);
            user.AssignedDoctor = doctorId;
            _context.SaveChanges();
        }

        public void AcceptPatient(int patientId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == patientId);

            user.AcceptedByDoctor = 1;
            _context.SaveChanges();
        }

        private bool UserExists(string login)
        {
            if (_context.Users.Any(x => x.Login == login))
            {
                return true;
            }

            return false;
        }

        public List<UserDto> GetAllPatients()
        {
            var allUsers = (from user in _context.Users
                                    where user.Role == 0
                                    select new UserDto
                                    {
                                        UserId = user.UserId,
                                        Name = user.Name,
                                        Surname = user.Surname,
                                        City = user.City,
                                        Street = user.Street

                                    }).ToList();
            return allUsers;
        }

        public List<UserDto> GetDoctorsPatients(int doctorId, int acceptedPatients)
        {
            var allUsers = (from user in _context.Users
                            where user.AssignedDoctor == doctorId && user.AcceptedByDoctor == acceptedPatients
                            select new UserDto
                            {
                                UserId = user.UserId,
                                Name = user.Name,
                                Surname = user.Surname,
                                City = user.City,
                                Street = user.Street
                            }).ToList();
            return allUsers;
        }

        public void RemovePatientAssignment(string patientLogin)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == patientLogin);
            user.AssignedDoctor = null;
            _context.SaveChanges();
        }
    }
}
