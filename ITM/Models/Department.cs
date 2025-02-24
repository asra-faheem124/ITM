using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Department
{
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string DepartmentName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string? DepartmentImg { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? DepartmentDesc { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? DepartmentTeacher { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
