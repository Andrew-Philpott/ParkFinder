using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Entities
{
  [Table("review")]
  public class Review
  {
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(Park))]
    public int ParkId { get; set; }
    [ForeignKey(nameof(ApplicationUser))]
    public int UserId { get; set; }
  }
}