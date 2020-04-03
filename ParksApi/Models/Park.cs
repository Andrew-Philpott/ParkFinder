
using System.Collections.Generic;

namespace ParksApi.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public bool IsNational { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}