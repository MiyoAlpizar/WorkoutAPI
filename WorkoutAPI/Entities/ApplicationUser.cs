using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Workout> Workouts { get; set; }
        public List<Serie> Series { get; set; }
        public List<Rutine> Rutines { get; set; }
    }
}
