using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class MeritList
{
    public int MeritId { get; set; }

    public string MeritName { get; set; } = null!;

    public double MeritPer { get; set; }
}
