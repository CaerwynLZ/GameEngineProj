using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine;
using FinalProject.Engine.Abstracts;
using FinalProject.Interfaces;

namespace FinalProject.Client
{
    public class Pawn : TileObject
    {
        int _dirrection;
        readonly Position _startPos;
        public Pawn(Actor owner,Tile currentPos)
        {
            this.Owner = owner;
            this.Color = owner.Color;
            this.Tile = currentPos;
            this.Position = Tile.Position;
            this.MoveSets = new List<List<Position>>();
            this.Name = "Pawn";
            this.Icon = "P";
            
            DealDirrection();
            AddMoveSet(new Position(0, 1));
            AddMoveSet(new Position(0, 2));
            AddMoveSet(new Position(-1, 1));
            AddMoveSet(new Position(1, 1));
            currentPos.TileObject = this;
            _startPos = Position;
        }

        public override TileObject GiveMoves(TileMap TileMap)
        {
            for(int i=0; i<MoveSets.Count; i++)
            {
                for(int j=0; j < MoveSets[i].Count; j++)
                {
                    Position pos = MoveSets[i][j];
                    if(pos.X==0 && pos.Y!=0)
                    {
                        if((pos.Y==-2 || pos.Y==2) && !_startPos.Equals(Position))
                        {
                            break;
                        }
                        Position nexPos = pos + Position;
                        if (InBounds(nexPos, TileMap))
                        {
                            if (TileMap[nexPos].TileObject == null)
                            {
                                TileMap.NextMoves.Add(TileMap[nexPos]);
                            }
                        }
                        else
                            break;
                    }
                    else
                    {
                        Position nexPos = pos + Position;
                        if (InBounds(nexPos, TileMap))
                        {
                            TileObject enemy = TileMap[nexPos].TileObject;
                            if (enemy != null && !enemy.Owner.Equals(this.Owner))
                            {
                                TileMap.NextMoves.Add(TileMap[nexPos]);
                                if (enemy.Name == "King")
                                {
                                    return enemy;
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return null;
        }
        //public override bool GiveMoves(TileMap TileMap)
        //{
        //    KingHold = false;
        //    tilemap= TileMap;
        //    if (startPos.Equals(Position))
        //    {
        //        ObjectState = State.Start;
        //    }
        //    else
        //        ObjectState = State.Normal;

        //    switch (ObjectState)
        //    {
        //        case State.Start:
        //            AddMoveSet(new Position(0, 1));
        //            AddMoveSet(new Position(0, 2));
        //            break;
        //        case State.Normal:
        //            GiveBehaveMove.Clear();
        //            AddMoveSet(new Position(0, 1));
        //            break;
        //        default:
        //            break;
        //    }

        //    var right = new Position(1, 1*dirrection) + this.Position;
        //    EnemyDetection(right);
        //    var left= new Position(-1, 1*dirrection) + this.Position;
        //    EnemyDetection(left);

        //    for(int i = 0; i < GiveBehaveMove.Count; i++)
        //    {
        //        var position= GiveBehaveMove[i]+Position;
        //        if (InBounds(position, TileMap))
        //        {
        //            TileMap.NextMoves.Add(TileMap[position]);
        //        }
        //    }
        //    return KingHold;

        //}
        //private void EnemyDetection(Position pos)
        //{
        //    if (tilemap[pos].TileObject!=null)
        //    {
        //        var enemy= tilemap[pos].TileObject;
        //        if(!enemy.Owner.Equals(this.Owner))
        //        {
        //            if (enemy.Name == "King")
        //            {
        //                KingHold = true;
        //            }
        //            tilemap.NextMoves.Add(tilemap[pos]);
        //        }
        //    }
        //}

        private void DealDirrection()
        {
            if(this.Owner.ID==1)
            {
                _dirrection= 1;
            }
            else
                _dirrection=-1;
        }

        public override void AddMoveSet(Position moveSet)
        {
            List<Position> positions= new List<Position>();
            moveSet = new Position(moveSet.X, moveSet.Y * _dirrection);
            positions.Add(moveSet);
            MoveSets.Add(positions);

        }

    }
}
