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
    }
}
