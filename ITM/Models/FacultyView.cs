namespace ITM.Models
{
    public class FacultyView
    {
        public int FacultyId { get; set; }

        public string FacultyName { get; set; } = null!;

        public string Designation { get; set; } = null!;

        public string? Experience { get; set; }

        public string? Qualification { get; set; }

        public IFormFile FacultyImg { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
    }
}
