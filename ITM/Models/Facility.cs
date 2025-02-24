using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Facility
{
    public int FacilityId { get; set; }
    [Required(ErrorMessage = "This field is required. ")]
    public string FacilityName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string FacilityDesc { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public string FacilityImg { get; set; } = null!;
}
