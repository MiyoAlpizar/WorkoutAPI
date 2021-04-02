using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class SerieWorkout
    {
        public int SerieId { get; set; }
        public int WorkoutId { get; set; }
        public Serie Serie { get; set; }
        public Workout Workout { get; set; }
    }
}
