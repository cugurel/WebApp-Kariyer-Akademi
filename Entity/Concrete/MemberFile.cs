using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class MemberFile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
