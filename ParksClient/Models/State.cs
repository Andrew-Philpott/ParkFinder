
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParksClient.Models
{
  public class State
  {
    public int StateId { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public virtual ICollection<Park> Parks { get; set; }
  }
}