using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorJsonGenerator
{
    public class WallList
    {
        public List<Wall> Walls { get; set; } = new List<Wall>();
    }

    public class Wall
    {
        public int WallNumber { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

    }
}
