using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class WorkoutImages
    {
        public int WorkoutId { get; set; }
        public int ImageId { get; set; }
        public Workout Workout { get; set; }
        public UrlImage Image { get; set; }

    }
}
