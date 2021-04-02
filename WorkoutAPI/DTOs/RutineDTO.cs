using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAPI.DTOs
{
    public class RutineDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SerieDTO> Series { get; set; }
    }

    public class RutineCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> SeriesIds { get; set; }
    }
}
