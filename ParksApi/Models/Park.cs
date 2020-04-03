
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksApi.Models
{
  [Table("park")]
  public class Park
  {
    [Key]
    public int ParkId { get; set; }

    [Required(ErrorMessage = "Park name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Select if it is a state or national park")]
    public bool IsNational { get; set; }

    [ForeignKey(nameof(State))]
    public int StateId { get; set; }
    public State State { get; set; }
  }
}