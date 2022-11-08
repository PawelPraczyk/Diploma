namespace Diploma.Dto
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public int Role { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
