using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    [Table("pricelist")]
    public class PriceList
    {
        [Key]
        [Column("priceid")]
        public int PriceId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public string Price { get; set; }
        [Column("doctorid")]
        public int DoctorId { get; set; }
    }
}
