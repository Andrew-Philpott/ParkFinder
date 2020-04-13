using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Entities
{
  [Table("park")]
  public class Park
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsNational { get; set; }

    [ForeignKey(nameof(State))]
    public int StateId { get; set; }
  }
}