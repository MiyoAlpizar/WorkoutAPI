using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutAPI.DTOs;
using WorkoutAPI.Entities;

namespace WorkoutAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RutinesController : MyControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public RutinesController(ApplicationDBContext context, IMapper mapper) : base (context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RutineDTO>>> Get([FromQuery] PaginationDTO pagination)
        {
            var queryable = context.Rutines.AsQueryable();
            queryable = queryable
                .Include(x => x.Series)
                .ThenInclude(x => x.Serie)
                .ThenInclude(x => x.Workouts)
                .ThenInclude(x => x.Workout)
                .ThenInclude(x => x.Images);

            return await Get<Rutine, RutineDTO>(pagination, queryable);
        }

        [HttpGet("{id}", Name = "GetRutine")]
        public async Task<ActionResult<RutineDTO>> Get(int id)
        {
            var queryable = context.Rutines.AsQueryable();
            queryable = queryable
                .Include(x => x.Series)
                .ThenInclude(x => x.Serie)
                .ThenInclude(x => x.Workouts)
                .ThenInclude(x => x.Workout)
                .ThenInclude(x => x.Images);

            return await Get<Rutine, RutineDTO>(id, queryable);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RutineCreateDTO rutine)
        {
            return await Post<RutineCreateDTO, Rutine, RutineDTO>(rutine, "GetRutine");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RutineCreateDTO rutine)
        {
            return await Put<RutineCreateDTO, Rutine>(id, rutine);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<RutineCreateDTO> patchDocument)
        {
            return await Patch<Rutine, RutineCreateDTO>(id, patchDocument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Rutine>(id);
        }

    }
}
