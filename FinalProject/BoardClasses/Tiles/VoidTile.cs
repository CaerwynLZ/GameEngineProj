using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BoardClasses
{
    public class VoidTile : Tile
    {
        public override TileObject? TileObject { get; set; }
        public override object Color { get; set; }

        public VoidTile(int x, int y) : base(x, y)
        {
            this.TileObject = null;
            this.Color = ConsoleColor.Black;
        }
    }
}
