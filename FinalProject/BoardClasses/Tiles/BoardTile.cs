using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine.Abstracts;

namespace FinalProject.BoardClasses
{
    public class BoardTile : Tile
    {
        public override TileObject? TileObject { get; set; }

        public override object Color { get; set; }
        public override string Icon { get; set; }

        public BoardTile(int x, int y, TileObject piece = null)
        {
            this.TileObject = piece;
            this.Color = ConsoleColor.DarkYellow;
            this.Position = new Position(x, y);
        }
    }
}
