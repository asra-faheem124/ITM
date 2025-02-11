using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class PreviousExam
{
    public int? StudentId { get; set; }

    public string University { get; set; } = null!;

    public string EnrollNumber { get; set; } = null!;

    public string Center { get; set; } = null!;

    public string Field { get; set; } = null!;

    public int MarksSecured { get; set; }

    public int OutOf { get; set; }

    public virtual Student? Student { get; set; }
}
