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
        public virtual Position Position { get; set; }
        public virtual Actor Owner { get; set; }
        public virtual string Name { get; set; }
        public virtual object Icon { get; set; }
        public virtual object Color { get; set; }
        public virtual Tile Tile { get; set; }
        public virtual List<Position> MoveSets { get; set; }

        public virtual void AddMoveSet(Position moveSet)
        {
            var p = moveSet + Position;
            MoveSets.Add(p);
        }

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
