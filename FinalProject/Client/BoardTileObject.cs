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
        TileMap tilemap;
        List<Position> GiveBehaveMove=new List<Position>();
        int dirrection;
        public BoardTileObject(Actor owner,Tile currentPos)
        {
            this.Owner = owner;
            this.Color = owner.Color;
            this.Tile = currentPos;
            this.Position = Tile.Position;
            this.ObjectState = State.Start;
            this.Name = "Pawn";
            this.Icon = "P";


            DealDirrection();

            currentPos.TileObject = this;
        }
        public override void GiveMoves(TileMap TileMap)
        {
            if(ObjectState== State.Start) 
            {
                AddMoveSet(new Position(0, 1));
                AddMoveSet(new Position(0, 2));
            }
            else
            {
                GiveBehaveMove.Clear();
                AddMoveSet(new Position(0, 1));
            }
            var right= Position+ new Position(1, 1*dirrection);
            var left= Position+ new Position(-1, 1*dirrection);

            HoldEnemy(right);
            HoldEnemy(left);

            for(int i=0; i<GiveBehaveMove.Count; i++) 
            {
                TileMap.NextMoves.Add(TileMap[GiveBehaveMove[i]]);
            }


        }

        private void HoldEnemy(Position pos)
        {
            var obj = tilemap[pos].TileObject;
            if(obj != null) 
            {
                if(!obj.Owner.Equals(this.Owner))
                {
                    AddMoveSet(pos);
                }
            }

        }
        

        private void DealDirrection()
        {
            if(this.Owner.ID==1)
            {
                dirrection= 1;
            }
            else
                dirrection=-1;
        }

        public override void AddMoveSet(Position moveSet)
        {
            moveSet = new Position(moveSet.X, moveSet.Y * dirrection);
            GiveBehaveMove.Add(moveSet);
        }

    }
}
