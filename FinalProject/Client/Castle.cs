using FinalProject.Engine;
using FinalProject.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Client
{
    internal class Castle : TileObject
    {
        public Castle(Actor owner, Tile currentPos)
        {
            Owner = owner;
            Color = owner.Color;
            Tile = currentPos;
            Position = Tile.Position;
            MoveSets = new List<List<Position>>();
            Name = "Castel";
            Icon = "C";

            AddMoveSet(new Position(10, 0));
            AddMoveSet(new Position(0, 10));
            AddMoveSet(new Position(-10, 0));
            AddMoveSet(new Position(0, -10));

            currentPos.TileObject = this;
        }
        public override void AddMoveSet(Position moveSet)
        {
            var GiveBehaveMove = new List<Position>();
            if (moveSet.X >= 1)
            {
                for (int i = 1; i <= moveSet.X; i++)
                {
                    GiveBehaveMove.Add(new Position(i, 0));
                }
                MoveSets.Add(GiveBehaveMove);
            }
            else if (moveSet.X <= -1)
            {
                for (int i = -1; i >= moveSet.X; i--)
                {
                    GiveBehaveMove.Add(new Position(i, 0));
                }
                MoveSets.Add(GiveBehaveMove);
            }
            if (moveSet.Y >= 1)
            {
                for (int i = 1; i <= moveSet.Y; i++)
                {

                    GiveBehaveMove.Add(new Position(0, i));
                }
                MoveSets.Add(GiveBehaveMove);
            }
            else if (moveSet.Y <= -1)
            {
                for (int i = -1; i >= moveSet.Y; i--)
                {
                    GiveBehaveMove.Add(new Position(0, i));
                }
                MoveSets.Add(GiveBehaveMove);
            }
        }
    }
}
