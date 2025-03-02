using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class CourseItm
{
    public int Courseid { get; set; }

    public string Coursename { get; set; } = null!;

    public string Courseimage { get; set; } = null!;

    public int Courseduration { get; set; }

    public int Coursefees { get; set; }

    public string Coursedesc { get; set; } = null!;

    public string Courseteacher { get; set; } = null!;

    public int? CourseDepartId { get; set; }

    public virtual ICollection<Admission> Admissions { get; set; } = new List<Admission>();

    public virtual Department? CourseDepart { get; set; }
}
