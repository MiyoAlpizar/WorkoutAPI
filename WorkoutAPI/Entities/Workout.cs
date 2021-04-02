using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{

    public enum WorkoutType
    {
        [Description("Time")]
        time,
        [Description("Reps")]
        reps
    }

    public enum Muscle
    {
        [Description("None")]
        none,
        [Description("Chest")]
        chest,
        [Description("Back")]
        back,
        [Description("Biceps")]
        biceps,
        [Description("Tricpes")]
        tricpes,
        [Description("Arms")]
        arms,
        [Description("Cuadriceps")]
        cusdriceps,
        [Description("Femorals")]
        femorals,
        [Description("Shoulders")]
        shoulders,
        [Description("Legs")]
        legs,
        [Description("Calves")]
        calves
    }

    public class Workout : IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,180)]
        public int RestInSeconds { get; set; }
        [Range(0,1)]
        public WorkoutType WorkoutType { get; set; }
        [Range(0, 180)]
        public int TimeInSeconds { get; set; }
        [Range(0, 180)]
        public int Reps { get; set; }
        [Range(0, 10)]
        public Muscle MainMuscle { get; set; }
        [Range(0, 10)]
        public Muscle SecondMuscle { get; set; }
        public List<WorkoutImages> Images { get; set; }
        public List<SerieWorkout> Workouts { get; set; }

    }
}
