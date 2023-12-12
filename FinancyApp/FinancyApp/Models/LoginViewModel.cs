﻿using System.ComponentModel.DataAnnotations;

namespace FinancyApp.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Your Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
