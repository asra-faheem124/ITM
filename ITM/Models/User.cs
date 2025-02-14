using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class User
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string UserEmail { get; set; } = null!;
    [Required]
    public string UserPassword { get; set; } = null!;
}
