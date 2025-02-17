using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Name is Required.")]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be within 3 to 15 characters.")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Email is Required.")]
    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid email pattern.")]
    public string Useremail { get; set; } = null!;
    [Required(ErrorMessage = "Password is Required.")]
    [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must contain atleast 6 characters.")]
    public string Userpassword { get; set; } = null!;

    public int? UserRoleId { get; set; }

    public virtual Role? UserRole { get; set; }
}
