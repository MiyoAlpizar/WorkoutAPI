using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class RutineSerie
    {
        public int RutineId { get; set; }
        public int SerieId { get; set; }
        public Rutine Rutine { get; set; }
        public Serie Serie { get; set; }
    }
}
