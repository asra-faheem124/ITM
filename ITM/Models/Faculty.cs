using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Faculty
{
    public int FacultyId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string FacultyName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string Designation { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string? Experience { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? Qualification { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public int? DepartmentId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? FacultyImg { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? Department { get; set; }

    public virtual Department? DepartmentNavigation { get; set; }

}
