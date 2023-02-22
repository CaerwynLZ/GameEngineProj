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
            if (moveSet.X == 0 || moveSet.Y == 0)
            {
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
            else
            {
                var offset = 1;
                var absX = MathF.Abs(moveSet.X);

                for (int i = 1; i <= absX; i++)
                {
                    if (moveSet.X <= -1 && moveSet.Y <= -1)
                    {
                        offset = -1;
                        GiveBehaveMove.Add(new Position(i * offset, i * offset));
                    }
                    else if (moveSet.X >= 1 && moveSet.Y >= 1)
                    {
                        GiveBehaveMove.Add(new Position(i, i));
                    }
                    else if (moveSet.Y >= 1 && moveSet.X <= -1)
                    {
                        offset = -1;
                        GiveBehaveMove.Add(new Position(i * offset, i));
                    }
                    else if (moveSet.Y <= -1 && moveSet.X >= 1)
                    {
                        offset = -1;
                        GiveBehaveMove.Add(new Position(i, i * offset));
                    }
                    MoveSets.Add(GiveBehaveMove);
                }
            }
        }
    }
}
