namespace Diploma.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public int Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Diseases { get; set; }
        public int? AssignedDoctor { get; set; }
        public int AssignedPatientsCount { get; set; }
    }
}
