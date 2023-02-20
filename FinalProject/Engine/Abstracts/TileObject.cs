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
        public virtual State ObjectState { get; set; }
        public virtual Tile Tile { get; set; }
        public Action Move { get; set; }
        public virtual List<List<Position>> MoveSets { get; set; } 
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

        public virtual void GiveMoves(TileMap TileMap)
        {
            for (int i = 0; i < this.MoveSets.Count; i++)
            {

                for (int j = 0; j < this.MoveSets[i].Count; j++)
                {
                    Position pos = this.MoveSets[i][j] + this.Position;
                    if (pos.X >= 0 && pos.X < TileMap.Width && pos.Y >= 0 && pos.Y < TileMap.Height)
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
                                TileMap.NextMoves.Add(TileMap[pos]);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        public enum State { Start, Normal, Attack}

    }
}
