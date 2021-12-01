﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CSharpFiles
{
    public class Colour
    {
        public List<string> Sizes = new List<string>();
        public string[] stock;
        public string ColourName;

        public Colour(string name)
        {
            ColourName = name;
        }
    }
}
