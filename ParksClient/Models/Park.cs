using System.Collections.Generic;
using ParksClient.Services;

namespace ParksClient.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public bool IsNational { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
  }

}