using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class Rutine : IId
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public List<RutineSerie> Series { get; set; }
    }
}
