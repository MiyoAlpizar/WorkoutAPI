using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{

    public enum WorkoutType
    {
        time, reps
    }

    public enum Muscle
    {
        none, chest, back, biceps, tricpes, arms, cusdriceps, femorals, shoulders, legs, calves
    }

    public class Workout : IId
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RestInSeconds { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public int TimeInSeconds { get; set; } 
        public int Reps { get; set; }
        public Muscle MainMuscle { get; set; }
        public Muscle SecondMuscle { get; set; }
        public List<UrlImage> Images { get; set; }
        public List<SerieWorkout> Workouts { get; set; }

    }
}
