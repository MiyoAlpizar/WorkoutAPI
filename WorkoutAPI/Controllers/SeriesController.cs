using AutoMapper;
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
            return await Get<Serie, SerieDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SerieCreateDTO serie)
        {
            return await Post<SerieCreateDTO, Serie, SerieDTO>(serie, "GetSerie");
        }

    }
}
