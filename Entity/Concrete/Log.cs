using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Log
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Process { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
