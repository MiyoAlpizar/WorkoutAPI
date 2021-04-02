using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class Serie : IId, IOwner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        [Range(0,180)]
        public int RestInSeconds { get; set; }

        public List<SerieWorkout> Workouts { get; set; }

        public List<RutineSerie> Series { get; set; }

        public bool Public { get; set; } = true;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
