using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    [Table("visit")]
    public class Visit
    {
        [Key]
        [Column("visitid")]
        public int VisitId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("doctorid")]
        public int DoctorId { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
        [Column("diagnosis")]
        public string Diagnosis { get; set; }
        [Column("prescription")]
        public string Prescription { get; set; }
    }
}
