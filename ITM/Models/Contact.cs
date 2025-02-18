using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITM.Models;

public partial class Contact
{
    [Required(ErrorMessage = "Name is Required.")]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be within 3 to 15 characters.")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Email is Required.")]
    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid email pattern.")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Message is Required.")]
    public string? Message { get; set; }

    public int Id { get; set; }
}
