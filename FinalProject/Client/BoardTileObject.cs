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
            this.Name = "Pawn";
            this.Icon = "P";

            AddMoveSet(new Position(0, 1));

            currentPos.TileObject = this;
        }

        public override void AddMoveSet(Position moveSet)
        {
            var offset = 1;
            Position startPos = Position;
            if (Owner.ID == 2)
            {
                offset = -1;
                moveSet= new Position(moveSet.X, moveSet.Y*offset);
            }
            var GiveBehaveMove = new List<Position>();
            GiveBehaveMove.Add(moveSet);
            this.MoveSets.Add(GiveBehaveMove);
        }

    }
}
