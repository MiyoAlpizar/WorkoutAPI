using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.DTOs;
using WorkoutAPI.Entities;
using WorkoutAPI.Services;

namespace WorkoutAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : MyControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        private readonly IFileStorage storage;
        private readonly string CONTAINER = "workouts";

        public WorkoutsController(ApplicationDBContext context, IMapper mapper, IFileStorage storage) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.storage = storage;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Workouts.AsQueryable();
            queryable = queryable.Include(x => x.Images);
            return await Get<Workout, WorkoutDTO>(paginationDTO, queryable);
        }

        [HttpGet("{id}", Name = "GetWorkout")]
        public async Task<ActionResult<WorkoutDTO>> Get(int id)
        {
            var queryable = context.Workouts.AsQueryable();
            queryable = queryable.Include(x => x.Images);
            return await Get<Workout, WorkoutDTO>(id, queryable);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] WorkoutCreateDTO workoutCreate)
        {
            var entity = mapper.Map<Workout>(workoutCreate);
            if (workoutCreate.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await workoutCreate.ImageFile.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(workoutCreate.ImageFile.FileName);
                var url = await storage.SaveFile(content, extension, CONTAINER, workoutCreate.ImageFile.ContentType);
                entity.Images = new List<UrlImage> { new UrlImage { Url = url } };
            }
            context.Add(entity);
            await context.SaveChangesAsync();
            var entityDTO = mapper.Map<WorkoutDTO>(entity);
            return new CreatedAtRouteResult("GetWorkout", new { id = entity.Id }, entityDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WorkoutUpdateDTO workoutCreate)
        {
            return await Put<WorkoutUpdateDTO, Workout>(id, workoutCreate);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<WorkoutUpdateDTO> patchDocument)
        {
            return await Patch<Workout, WorkoutUpdateDTO>(id, patchDocument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Workout>(id);
        }
    }
}
