using System.ComponentModel.DataAnnotations;

namespace ParksApi.ViewModels.Users
{
  public class LoginViewModel
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}