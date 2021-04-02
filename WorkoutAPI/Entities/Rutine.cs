using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class Rutine : IId, IOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RutineSerie> Series { get; set; }
        public bool Public { get; set; } = true;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
