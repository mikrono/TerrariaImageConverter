using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaImageConverter
{
    public class PaintToolFile
    {
        // {"type":0,"frameX":0,"frameY":0,"wall":155,"liquid":0,"sTileHeader":0,"bTileHeader":0,"bTileHeader2":1,"bTileHeader3":1,"collisionType":0}
        public ushort type { get; set; }
        public short frameX { get; set; }
        public short frameY { get; set; }
        public ushort wall { get; set; }
        public byte liquid { get; set; }
        public ushort sTileHeader { get; set; }
        public byte bTileHeader { get; set; }
        public byte bTileHeader2 { get; set; }
        public byte bTileHeader3 { get; set; }
        public int collisionType { get; set; }
    }
}
