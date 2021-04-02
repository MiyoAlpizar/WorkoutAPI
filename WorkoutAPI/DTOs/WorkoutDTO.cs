using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.Entities;
using WorkoutAPI.Validations;

namespace WorkoutAPI.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 180)]
        public int RestInSeconds { get; set; }
        [Range(0, 1)]
        public string WorkoutDescription { get; set; }
        [Range(0, 10)]
        public string MainMuscle { get; set; }
        [Range(0, 10)]
        public string SecondMuscle { get; set; }
        public List<string> Images { get; set; }
    }

    public class WorkoutCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 180)]
        public int RestInSeconds { get; set; }
        [Range(0, 1)]
        public WorkoutType WorkoutType { get; set; }
        [Range(0, 180)]
        public int TimeInSeconds { get; set; }
        [Range(0, 180)]
        public int Reps { get; set; }
        [Range(0, 10)]
        public Muscle MainMuscle { get; set; }
        [Range(0, 10)]
        public Muscle SecondMuscle { get; set; }

        [FileSizeValidation(MaxSize: 1)]
        [FileTypeValidation(groupFileType: GroupFileType.Imagen)]
        public IFormFile ImageFile { get; set; }
    }

    public class WorkoutUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 180)]
        public int RestInSeconds { get; set; }
        [Range(0, 1)]
        public WorkoutType WorkoutType { get; set; }
        [Range(0, 180)]
        public int TimeInSeconds { get; set; }
        [Range(0, 180)]
        public int Reps { get; set; }
        [Range(0, 10)]
        public Muscle MainMuscle { get; set; }
        [Range(0, 10)]
        public Muscle SecondMuscle { get; set; }
    }
}
