using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("userid")]
        public int UserId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string Surname { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public int Role { get; set; } // 0, 1, 2 Dodać tabelę z cennikami (na widoku wybierz lekarza będą przyciski sprawdź cennik)
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("personalnumber")]
        public string PersonalNumber { get; set; }
        [Column("street")]
        public string Street { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("postalcode")]
        public string PostalCode { get; set; }
        [Column("diseases")]
        public string Diseases { get; set; }
        [Column("assigneddoctor")]
        public int? AssignedDoctor { get; set; }
        [Column("assignedpatientscount")]
        public int AssignedPatientsCount { get; set; }
        [Column("acceptedbydoctor")]
        public int AcceptedByDoctor { get; set; }
    }
}
