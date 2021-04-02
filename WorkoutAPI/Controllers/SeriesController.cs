using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
}
