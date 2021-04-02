using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.DTOs;
using WorkoutAPI.Entities;

namespace WorkoutAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           
            CreateMap<Workout, WorkoutDTO>()
                .ForMember(x => x.WorkoutDescription, x => x.MapFrom(GetWorkoutDesc))
                .ForMember(x => x.MainMuscle, x => x.MapFrom(x => x.MainMuscle.GetDescription()))
                .ForMember(x => x.SecondMuscle, x => x.MapFrom(x => x.SecondMuscle.GetDescription()))
                .ForMember(x => x.Images, x => x.MapFrom(GetUrlImages));


            CreateMap<WorkoutCreateDTO, Workout>().ForMember(x => x.Images, o => o.Ignore());
            CreateMap<WorkoutUpdateDTO, Workout>().ReverseMap();

            CreateMap<Serie, SerieDTO>()
                .ForMember(x => x.Workouts, x => x.MapFrom(MapSeriesWorkouts));

            CreateMap<SerieCreateDTO, Serie>()
                .ForMember(x => x.Workouts, o => o.MapFrom(MapSeriesWorkouts));

            CreateMap<RutineCreateDTO, Rutine>()
                .ForMember(x => x.Series, x => x.MapFrom(MapRutineSeries));
           
            CreateMap<Rutine, RutineDTO>()
                .ForMember(x => x.Series, x => x.MapFrom(MapRutineSeries));
           
        }

        private List<SerieWorkout> MapSeriesWorkouts(SerieCreateDTO serieCreate, Serie serie)
        {
            var results = new List<SerieWorkout>();
            if (serieCreate.WorkoutsIds == null) return results;
            foreach (var item in serieCreate.WorkoutsIds)
            {
                results.Add(new SerieWorkout { WorkoutId = item });
            }
            return results;
        }

        private List<WorkoutDTO> MapSeriesWorkouts(Serie serie, SerieDTO serieDTO, List<WorkoutDTO> workouts , ResolutionContext context)
        {
            var results = new List<WorkoutDTO>();
            if (serie.Workouts == null) return results;
            
            foreach (var item in serie.Workouts)
            {
                results.Add(context.Mapper.Map<WorkoutDTO>(item.Workout));
            }
            return results;
        }

        private string GetWorkoutDesc(Workout workout, WorkoutDTO dTO)
        {
            string descripction;
            if (workout.WorkoutType == WorkoutType.reps)
            {
                descripction = $"{workout.Reps} reps";
            }else
            {
                descripction = $"do it {workout.TimeInSeconds} seconds";
            }
            return descripction;
        }

        private List<string> GetUrlImages(Workout workout, WorkoutDTO dTO)
        {
            var images = new List<string>();
            if (workout.Images != null)
            {
                foreach (var item in workout.Images)
                {
                    images.Add(item.Url);
                }
            }
            return images;
        }

        private List<RutineSerie> MapRutineSeries(RutineCreateDTO createDTO, Rutine rutine)
        {
            var results = new List<RutineSerie>();
            if (createDTO.SeriesIds == null) return results;
            foreach (var item in createDTO.SeriesIds)
            {
                results.Add(new RutineSerie { SerieId = item });
            }
            return results;
        }

        private List<SerieDTO> MapRutineSeries(Rutine rutine, RutineDTO rutineDTO, List<SerieDTO> serieDTOs, ResolutionContext context)
        {
            var results = new List<SerieDTO>();
            if (rutine.Series == null) return results;
            foreach (var item in rutine.Series)
            {
                results.Add(context.Mapper.Map<SerieDTO>(item.Serie));
            }
            return results;
        }
    }
}
