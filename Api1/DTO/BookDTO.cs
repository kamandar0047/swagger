﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.DTO
{
    public class BookDTO:BaseDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
