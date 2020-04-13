
using System.Collections.Generic;

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