using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class Contact
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Message { get; set; }

    public int Id { get; set; }
}
