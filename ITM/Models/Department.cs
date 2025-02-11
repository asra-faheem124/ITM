using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? DepartmentImg { get; set; }

    public string? DepartmentDesc { get; set; }

    public string? DepartmentTeacher { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
