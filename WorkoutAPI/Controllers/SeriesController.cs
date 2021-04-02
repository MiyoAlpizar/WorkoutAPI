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
    public class SeriesController : MyControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public SeriesController(ApplicationDBContext context, IMapper mapper) : base (context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SerieDTO>>> Get([FromQuery] PaginationDTO pagination)
        {
            var queryable = context.Series.AsQueryable();
            queryable = queryable
                .Include(x => x.Workouts)
                .ThenInclude(x => x.Workout)
                .ThenInclude(x => x.Images);
            return await Get<Serie, SerieDTO>(pagination, queryable);
        }

        [HttpGet("{id}", Name ="GetSerie")]
        public async Task<ActionResult<SerieDTO>> Get(int id)
        {
            var queryable = context.Series.AsQueryable();
            queryable = queryable
                .Include(x => x.Workouts)
                .ThenInclude(x => x.Workout)
                .ThenInclude(x => x.Images);

            return await Get<Serie, SerieDTO>(id, queryable);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SerieCreateDTO serie)
        {
            return await Post<SerieCreateDTO, Serie, SerieDTO>(serie, "GetSerie");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SerieCreateDTO serie)
        {
            return await Put<SerieCreateDTO, Serie>(id, serie);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id,[FromBody] JsonPatchDocument<SerieCreateDTO> patchDocument)
        {
            return await Patch<Serie, SerieCreateDTO>(id, patchDocument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Serie>(id);
        }
    }
}
