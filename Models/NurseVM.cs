using SS_Nurse.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SS_NurseCore5.Models
{
    public class NurseVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(50, ErrorMessage = "Max Len 50")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Enter Phone")]
        //[RegularExpression("[010|011|012|015]-[0-9]{8}", ErrorMessage = "Enter Phone Correctly")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Nurse's State")]
        [Range(0, 1, ErrorMessage = "Enter 0 for InPatient or 1 for OutPatient")]
        public int State { get; set; }

        [Required(ErrorMessage = "Enter Nurse's Availability")]
        [Range(0, 1, ErrorMessage = "Enter 0 for Avtive or 1 for InActive")]
        public int Availability { get; set; }


    }

    public static class nurseToViewModel
    {
        public static Nurse ToViewModel(this NurseVM nursevm)
        {
            return new Nurse
            {
                id = nursevm.id,
                Name = nursevm.Name,
                Phone = nursevm.Phone,
                State = nursevm.State,
                Availability = nursevm.Availability

            };

        }
    }
}
