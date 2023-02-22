using FinalProject.Engine.Abstracts;
using FinalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Client
{
    public class Knight : TileObject
    {
        public Knight(Actor owner, Tile currentPos)
        {
            this.Owner = owner;
            this.Color = owner.Color;
            this.Tile = currentPos;
            this.Position = Tile.Position;
            this.MoveSets = new List<List<Position>>();
            this.Name = "Knight";
            this.Icon = "N";

            AddMoveSet(new Position(1, 2));
            AddMoveSet(new Position(-1, 2));
            AddMoveSet(new Position(1, -2));
            AddMoveSet(new Position(-1, -2));
            AddMoveSet(new Position(2, 1));
            AddMoveSet(new Position(-2, 1));
            AddMoveSet(new Position(-2, -1));
            AddMoveSet(new Position(2, -1));


            currentPos.TileObject = this;
        }

        public override void AddMoveSet(Position moveSet)
        {
            var GiveBehaveMove = new List<Position>();
            GiveBehaveMove.Add(moveSet);
            this.MoveSets.Add(GiveBehaveMove);
        }

    }
}
