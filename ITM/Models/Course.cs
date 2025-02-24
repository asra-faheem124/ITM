using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Course
{
    public int CourseId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string CourseName { get; set; } = null!;
    //[Required(ErrorMessage = "This field is required. ")]
    public string? CourseImg { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string CourseDuration { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string CourseFees { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string CourseDesc { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string? CourseTeacher { get; set; }

    public virtual Department Department { get; set; } = null!;
}
