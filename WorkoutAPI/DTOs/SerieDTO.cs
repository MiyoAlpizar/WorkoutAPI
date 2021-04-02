using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.Entities;

namespace WorkoutAPI.DTOs
{
    public class SerieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        [Range(0, 180)]
        public int RestInSeconds { get; set; }

        public List<Workout> Workouts { get; set; }

    }
}
