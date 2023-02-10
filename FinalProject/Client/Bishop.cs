using FinalProject.Engine.Abstracts;
using FinalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Client
{
    internal class Bishop : TileObject
    {
        public Bishop(Actor owner, Tile currentPos)
        {
            Owner = owner;
            Color = owner.Color;
            Tile = currentPos;
            Position = Tile.Position;
            MoveSets = new List<List<Position>>();
            Name = "Bishop";
            Icon = "B";

            AddMoveSet(new Position(10, 10));
            AddMoveSet(new Position(-10, 10));
            AddMoveSet(new Position(10, -10));
            AddMoveSet(new Position(-10, -10));

            currentPos.TileObject = this;
        }
        public override void AddMoveSet(Position moveSet)
        {
            var absX=MathF.Abs(moveSet.X);
            var GiveBehaveMove = new List<Position>();
            var offset = 1;


            for(int i = 1; i <= absX; i++)
            {
                if (moveSet.X <= -1 && moveSet.Y <= -1)
                {
                    offset = -1;
                    GiveBehaveMove.Add(new Position(i*offset, i*offset));
                }
                else if(moveSet.X >= 1 && moveSet.Y >= 1)
                {
                    GiveBehaveMove.Add(new Position(i , i));
                }
                else if(moveSet.Y >= 1 && moveSet.X <= -1)
                {
                    offset = -1;
                    GiveBehaveMove.Add(new Position(i * offset, i));
                }
                else if(moveSet.Y <= -1 && moveSet.X >= 1)
                {
                    offset = -1;
                    GiveBehaveMove.Add(new Position(i , i * offset));
                }
                MoveSets.Add(GiveBehaveMove);
            }
        }
    }
}
