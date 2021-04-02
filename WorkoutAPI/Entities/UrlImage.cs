using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class WorkoutImages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
