using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class MeritList
{
    public int MeritId { get; set; }
    [Required(ErrorMessage ="This field is required. ")]
    public string MeritName { get; set; } = null!;
    [Required(ErrorMessage = "This field is required. ")]
    public double MeritPer { get; set; }
}
