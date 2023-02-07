using FinalProject.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Castle: TileObject
    {
        public Castle(Actor owner, Tile currentPos)
        {
            this.Owner = owner;
            this.Color = owner.Color;
            this.Tile = currentPos;
            this.Position = Tile.Position;
            this.MoveSets = new List<Position>();
            this.Name = "Castel";
            this.Icon = "C";

            AddMoveSet(new Position(10, 0));
            AddMoveSet(new Position(0, 10));
            AddMoveSet(new Position(-10, 0));
            AddMoveSet(new Position(0, -10));

            currentPos.TileObject = this;
        }
        public override void AddMoveSet(Position moveSet)
        {
            if(moveSet.X>=1)
            {
                for(int i = 1; i <= moveSet.X; i++)
                {
                    this.MoveSets.Add(new Position(i, 0));
                }
            }
            else if(moveSet.X <= -1)
            {
                for (int i = -1; i >= moveSet.X; i--)
                {      
                    this.MoveSets.Add(new Position(i, 0));
                }
            }
            if(moveSet.Y>=1)
            {
                for (int i = 0; i <= moveSet.Y; i++)
                {
                    
                    this.MoveSets.Add(new Position(0,i));
                }
            }
            else if (moveSet.Y <= -1)
            {
                for (int i = -1; i >= moveSet.Y; i--)
                {
                    this.MoveSets.Add(new Position(0, i));
                }
            }

        }
    }
}
