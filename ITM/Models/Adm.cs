using System.ComponentModel.DataAnnotations;

namespace ITM.Models
{
    public class Adm
    {
        [Required]
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        [DataType(DataType.Date)]
        public int DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}
