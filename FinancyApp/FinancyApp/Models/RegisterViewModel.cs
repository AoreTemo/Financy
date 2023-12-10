using System.ComponentModel.DataAnnotations;

namespace FinancyApp.Models;

public class RegisterViewModel
{
    [Required (ErrorMessage = "UserName is required")]
    [Display(Name = "UserName")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    public string Email { get; set; }

    [Required(ErrorMessage ="Balance Required")]
    [Display(Name = "Balance")]
    public int Balance {  get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password must be confirmed")]
    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password don't match")]
    public string ConfirmPassword { get; set; }

}
