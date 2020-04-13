using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Entities
{
  [Table("state")]
  public class State
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
  }
}