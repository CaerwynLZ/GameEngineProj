using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine.Abstracts;

namespace FinalProject.Client
{
    public class BoardTileObject : TileObject
    {
        public BoardTileObject(Actor owner, string name, object icon, Tile currentPos, List<Position> movement) : base(owner, name, icon, currentPos, movement)
        {
            AddMoveSet(new Position(1, 1));
            AddMoveSet(new Position(-1, 1));
            AddMoveSet(new Position(-1, -1));
            AddMoveSet(new Position(1, -1));
        }
    }
}
