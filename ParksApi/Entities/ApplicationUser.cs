using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Entities
{
  [Table("user")]
  public class ApplicationUser
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}