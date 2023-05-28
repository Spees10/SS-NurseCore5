using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS_Nurse.DAL.Entities
{
    [Table("Nurses")]
    public class Nurse
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        
        public string Phone { get; set; }

        [Required(ErrorMessage = "State is Required")]
        [Range(0, 1, ErrorMessage = "0 or 1 ONLY")]
        public int State { get; set; }

        [Required(ErrorMessage = "Availability is Required")]
        [Range(0, 1, ErrorMessage = "0 or 1 ONLY")]
        public int Availability { get; set; }
    }
}
