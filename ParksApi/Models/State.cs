
using System.Collections.Generic;

namespace ParksApi.Models
{
    public class State
    {
        public State()
        {
            this.Parks = new HashSet<Park>();
        }
        public int StateId { get; set; }
        public string Name { get; set; }
        public ICollection<Park> Parks { get; set; }
    }
}