using System;
using System.Collections.Generic;

namespace ITM.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Useremail { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public int? UserRoleId { get; set; }

    public virtual Role? UserRole { get; set; }
}
