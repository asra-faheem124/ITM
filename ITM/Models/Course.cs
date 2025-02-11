using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseImg { get; set; } = null!;

    public string CourseDuration { get; set; } = null!;

    public string CourseFees { get; set; } = null!;

    public string CourseDesc { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? CourseTeacher { get; set; }

    public virtual Department Department { get; set; } = null!;
}
