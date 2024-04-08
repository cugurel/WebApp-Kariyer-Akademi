using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
   public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
        public decimal? ImdbRate { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
    
}
