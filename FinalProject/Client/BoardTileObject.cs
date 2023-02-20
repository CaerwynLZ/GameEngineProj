using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine;
using FinalProject.Engine.Abstracts;

namespace FinalProject.Client
{
    public class Pawn : TileObject
    {
        TileMap tilemap;
        List<Position> GiveBehaveMove=new List<Position>();
        int dirrection;
        Position startPos;
        bool KingHold;
        public Pawn(Actor owner,Tile currentPos)
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
            startPos = Position;
        }
        public override bool GiveMoves(TileMap TileMap)
        {
            KingHold = false;
            tilemap= TileMap;
            if (startPos.Equals(Position))
            {
                ObjectState = State.Start;
            }
            else
                ObjectState = State.Normal;

            switch (ObjectState)
            {
                case State.Start:
                    AddMoveSet(new Position(0, 1));
                    AddMoveSet(new Position(0, 2));
                    break;
                case State.Normal:
                    GiveBehaveMove.Clear();
                    AddMoveSet(new Position(0, 1));
                    break;
                default:
                    break;
            }

            var right = new Position(1, 1*dirrection) + this.Position;
            EnemyDetection(right);
            var left= new Position(-1, 1*dirrection) + this.Position;
            EnemyDetection(left);

            for(int i = 0; i < GiveBehaveMove.Count; i++)
            {
                var position= GiveBehaveMove[i]+Position;
                TileMap.NextMoves.Add(TileMap[position]);
            }
            return KingHold;
        
        }
        private void EnemyDetection(Position pos)
        {
            if (tilemap[pos].TileObject!=null)
            {
                var enemy= tilemap[pos].TileObject;
                if(!enemy.Owner.Equals(this.Owner))
                {
                    if (enemy.Name == "King")
                    {
                        KingHold = true;
                    }
                    tilemap.NextMoves.Add(tilemap[pos]);
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
