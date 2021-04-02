using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class Serie : IId
    {
        public int Id { get; set; }

        public string Comments { get; set; }

        public int RestInSeconds { get; set; }

        public List<SerieWorkout> Workouts { get; set; }

        public List<RutineSerie> Series { get; set; }
    }
}
