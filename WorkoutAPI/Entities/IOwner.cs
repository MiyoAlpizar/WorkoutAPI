using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.Entities
{
    public interface IOwner
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
