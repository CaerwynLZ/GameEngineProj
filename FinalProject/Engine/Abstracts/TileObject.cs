using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Engine.Abstracts
{
    public abstract class TileObject : IMove, ICloneable<TileObject>
    {
        public virtual Position Position { get; set; }
        public virtual Actor Owner { get; set; }
        public virtual string Name { get; set; }
        public virtual object Icon { get; set; }
        public virtual object Color { get; set; }
        public virtual Tile Tile { get; set; }
        public Action Move { get; set; }
        public virtual List<List<Position>> MoveSets { get; set; } 
        public virtual List<Position> CheckablePosition { get; set; }
        /// <summary>
        /// Adds positions for ListPosition depending on what each piece can do/move to
        /// </summary>
        /// <param name="moveSet"></param>
        public virtual void AddMoveSet(Position moveSet) { }

        public virtual TileObject Clone()
        {
            var u = (TileObject)MemberwiseClone();
            u.Owner = Owner;
            u.Name = Name;
            u.Icon = Icon;

            u.Owner = Owner;
            return u;
        }

        public virtual void SetTile(Tile tile)
        {
            DeleteTile();
            this.Tile = tile;
            this.Position = tile.Position;
            tile.TileObject = this;
        }

        public virtual void DeleteTile()
        {
            this.Tile.TileObject = null;
        }

        /// <summary>
        /// Gives tlemaps their possible movements and also sees if king is in check or not
        /// </summary>
        /// <param name="TileMap"></param>
        /// <returns></returns>
        public virtual TileObject GiveMoves(TileMap TileMap)
        {
            CheckablePosition= new List<Position>();
            for (int i = 0; i < this.MoveSets.Count; i++)
            {
                for (int j = 0; j < this.MoveSets[i].Count; j++)
                {
                    Position pos = this.MoveSets[i][j] + this.Position;
                    if (InBounds(pos,TileMap))
                    {
                        var enemyObj = TileMap[pos].TileObject;
                        if (enemyObj == null)
                        {
                            TileMap.NextMoves.Add(TileMap[pos]);
                        }
                        else
                        {
                            if (!enemyObj.Owner.Equals(this.Owner))
                            {
                                if (enemyObj.Name == "King")
                                {
                                    TileMap.NextMoves.Add(TileMap[pos]);
                                    CheckPositions(this.MoveSets[i], TileMap);
                                    return enemyObj;
                                }
                                else
                                {
                                    TileMap.NextMoves.Add(TileMap[pos]);
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public void CheckPositions(List<Position> list, TileMap tileMap)
        {
            for(int i=0; i<list.Count; i++) 
            {
                Position pos= list[i]+Position;
                if (InBounds(pos, tileMap))
                {
                    CheckablePosition.Add(pos);
                }
            }
        }

        /// <summary>
        /// is the position you can go to is in the map 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="TileMap"></param>
        /// <returns></returns>
        public virtual bool InBounds(Position pos, TileMap TileMap)
        {
            return pos.X >= 0 && pos.X < TileMap.Width && pos.Y >= 0 && pos.Y < TileMap.Height;
        }
    }
}
