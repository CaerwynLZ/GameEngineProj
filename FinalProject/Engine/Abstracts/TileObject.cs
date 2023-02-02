using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Engine.Abstracts
{
    public abstract class TileObject : IMove, ICloneable<TileObject>
    {
        public Position Position { get; set; }
        public Actor Owner { get; set; }
        public string Name { get; set; }
        public object Icon { get; set; }
        public virtual object Color { get; set; }
        public virtual Tile Tile { get; set; }
        public List<Position> MoveSets { get; set; }

        public TileObject(Actor owner, string name, object icon, Tile currentPos, List<Position> movement)
        {
           this.Tile = currentPos;
           this.Position = Tile.Position;
           this.Owner = owner;
           this.Icon = icon;
           this.Name = name;
           this.Color = owner.Color;
        }
        public void AddMoveSet(Position moveSet)
        {
            var p = moveSet + Position;
            MoveSets.Add(p);
        }

        public delegate void Move(int x, int y);

        public virtual TileObject Clone()
        {
            var u = (TileObject)MemberwiseClone();
            u.Owner = Owner;
            u.Name = Name;
            u.Icon = Icon;

            u.Owner = Owner;
            return u;
        }
    }

    public enum MoveDirect { Positive, Negative, Both };
}
