using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class BoardTileObject : TileObject
    {
        public BoardTileObject(Actor owner, string name, object icon, int x, int y)
        {
            this.Position = new Position(x, y);
            this.Owner = owner;
            this.Icon = icon;
            this.Name = name;
            this.Color = owner.Color;
        }
    }
}
