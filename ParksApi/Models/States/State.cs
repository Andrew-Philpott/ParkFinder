
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Models
{
  [Table("state")]
  public class State
  {
    [Key]
    public int StateId { get; set; }

    [Required(ErrorMessage = "State name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "State name is required")]
    public string Region { get; set; }
    public ICollection<Park> Parks { get; set; }
  }
}