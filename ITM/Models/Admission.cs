using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Admission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string ResidentialAddress { get; set; } = null!;

    public string PermanentAddress { get; set; } = null!;

    public string Stream { get; set; } = null!;

    public string? SportsDetails { get; set; }

    public string University { get; set; } = null!;

    public string EnrollmentNumber { get; set; } = null!;

    public int ExamYear { get; set; }

    public string Field { get; set; } = null!;

    public int Marks { get; set; }

    public string Grade { get; set; } = null!;

    public string AdmissionStatus { get; set; } = null!;
}
