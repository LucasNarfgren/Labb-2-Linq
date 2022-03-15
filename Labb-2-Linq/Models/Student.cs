using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_2_Linq.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}
