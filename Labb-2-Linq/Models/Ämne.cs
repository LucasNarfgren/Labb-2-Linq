﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_2_Linq.Models
{
    public class Ämne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LärareId { get; set; }
        public Lärare Lärare { get; set; }
    }
}
