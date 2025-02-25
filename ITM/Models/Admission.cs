using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Admission
{
    public int Id { get; set; }
    [Required(ErrorMessage ="This field is required. ")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string FatherName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string MotherName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public DateOnly DateOfBirth { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string Gender { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string ResidentialAddress { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string PermanentAddress { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string Stream { get; set; } = null!;

    public string? SportsDetails { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string University { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string EnrollmentNumber { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public int ExamYear { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string Field { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public int Marks { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string Grade { get; set; } = null!;
}
