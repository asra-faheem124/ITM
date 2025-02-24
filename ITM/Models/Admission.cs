using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Admission
{
    public int StudentId { get; set; }

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string ResidentialAddress { get; set; } = null!;

    public string PermanentAddress { get; set; } = null!;

    public string AdmissionFor { get; set; } = null!;

    public string SportsDetails { get; set; } = null!;

    public string? Name { get; set; }
}
