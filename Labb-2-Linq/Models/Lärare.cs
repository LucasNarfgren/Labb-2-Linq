using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_2_Linq.Models
{
    public class Lärare
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ämne> Ämnen { get; set; }
    }
}
