using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    [Table("examination")]
    public class Examination
    {
        [Key]
        [Column("examinationid")]
        public int ExaminationId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("results")]
        public string Results { get; set; }
        [Column("isright")]
        public int IsRight { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
    }
}
