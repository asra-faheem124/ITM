using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Facility
{
    public int FacilityId { get; set; }

    public string FacilityName { get; set; } = null!;

    public string FacilityDesc { get; set; } = null!;

    public string? FacilityImg { get; set; }
}
