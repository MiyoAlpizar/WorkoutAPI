using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.Entities;

namespace WorkoutAPI
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Rutine> Rutines { get; set; }
        public DbSet<WorkoutImages> Images { get; set; }
        public DbSet<RutineSerie> RutineSeries { get; set; }
        public DbSet<SerieWorkout> SerieWorkouts { get; set; }
        
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RutineSerie>()
                .HasKey(x => new { x.RutineId, x.SerieId });

            builder.Entity<SerieWorkout>()
                .HasKey(x => new { x.SerieId, x.WorkoutId });

            base.OnModelCreating(builder);
        }


    }
}
