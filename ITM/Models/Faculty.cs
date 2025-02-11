using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Faculty
{
    public int FacultyId { get; set; }

    public string FacultyName { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Experience { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public string? FacultyImg { get; set; }

    public virtual Department? Department { get; set; }
}
