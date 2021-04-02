using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAPI.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int _RowsPerPage { get; set; } = 10;

        private readonly int MaxRowsPerPage = 50;

        public int RowsPerPage
        {
            get => _RowsPerPage;
            set
            {
                _RowsPerPage = (value > MaxRowsPerPage ? _RowsPerPage : value);
            }
        }
    }
}
