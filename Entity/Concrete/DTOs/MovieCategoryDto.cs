using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class MovieCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
        public decimal? ImdbRate { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
