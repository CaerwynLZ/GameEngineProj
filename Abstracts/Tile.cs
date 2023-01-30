using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Tile
    {
        public Position Position { get; set; }
        public abstract object Color { get; set; }
        public abstract TileObject? TileObject { get; set; }

        public Tile(int x, int y)
        {
            this.Position = new Position(x, y);
        }
    }

}
