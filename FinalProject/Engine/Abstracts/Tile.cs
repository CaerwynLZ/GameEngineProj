using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Engine.Abstracts
{
    public abstract class Tile
    {
        public Position Position { get; set; }
        public virtual object Color { get; set; }
        public virtual string Icon { get; set; }
        public virtual string[] IconsSides { get; set; }
        public virtual TileObject? TileObject { get; set; }
    }
}
