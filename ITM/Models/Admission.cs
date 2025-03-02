using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Admission
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? ResidentialAddress { get; set; }

    public string? PermanentAddress { get; set; }

    public string? SportsDetails { get; set; }

    public string University { get; set; } = null!;

    public string? EnrollmentNumber { get; set; }

    public string? ExamYear { get; set; }

    public string? Field { get; set; }

    public int? Marks { get; set; }

    public string? Grade { get; set; }

    public string AdmissionStatus { get; set; } = null!;

    public string? Email { get; set; }

    public int? AdmCourseId { get; set; }

    public virtual CourseItm? AdmCourse { get; set; }
}
