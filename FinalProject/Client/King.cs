using FinalProject.Engine.Abstracts;
using FinalProject.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject.Client
{
    internal class King : TileObject
    {
        public King(Actor owner, Tile currentPos)
        {
            Owner = owner;
            Color = owner.Color;
            Tile = currentPos;
            Position = Tile.Position;
            MoveSets = new List<List<Position>>();
            Name = "King";
            Icon = "K";

            AddMoveSet(new Position(0, 1));
            AddMoveSet(new Position(0, -1));
            AddMoveSet(new Position(1, 0));
            AddMoveSet(new Position(-1, 0));
            AddMoveSet(new Position(1, 1));
            AddMoveSet(new Position(-1, 1));
            AddMoveSet(new Position(1, -1));
            AddMoveSet(new Position(-1, -1));

            currentPos.TileObject = this;
        }

        public override void AddMoveSet(Position moveSet)
        {
            var GiveBehaveMove = new List<Position>();
            GiveBehaveMove.Add(moveSet);
            MoveSets.Add(GiveBehaveMove);
        }
    }
}
