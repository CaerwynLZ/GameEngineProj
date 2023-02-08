using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine;
using FinalProject.Engine.Abstracts;

namespace FinalProject.Client
{
    public class BoardTileObject : TileObject
    {
        public BoardTileObject(Actor owner,Tile currentPos)
        {
            this.Owner = owner;
            this.Color = owner.Color;
            this.Tile = currentPos;
            this.Position = Tile.Position;
            this.MoveSets = new List<List<Position>>();
            this.Name = "Liron";
            this.Icon = "L";

            AddMoveSet(new Position(1, 1));
            AddMoveSet(new Position(-1, 1));

            currentPos.TileObject = this;
        }

        //public override void AddMoveSet(Position moveSet)
        //{
        //    var p = moveSet + Position;
        //    this.MoveSets.Add(p);
        //}

    }
}
