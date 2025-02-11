using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
