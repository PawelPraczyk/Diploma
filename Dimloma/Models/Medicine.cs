using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    [Table("medicine")]
    public class Medicine
    {
        [Key]
        [Column("medicineid")]
        public int MedicineId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("dose")]
        public string Dose { get; set; }
        [Column("time")]
        public string Time { get; set; }
        [Column("afterfood")]
        public int AfterFood { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
    }
}
