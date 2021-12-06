using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CSharpFiles
{
    public class Colour
    {
        public List<string> Sizes = new List<string>();
        public List<string> stock = new List<string>();
        public string ColourName;
        public int ColourId;

        public Colour(string name, int colourid)
        {
            ColourName = name;
            ColourId = colourid;
        }
    }
}
