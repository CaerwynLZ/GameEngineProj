using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class TileObject : IMove, ICloneable<TileObject>
    {
        public Position Position { get; set; }
        public Actor Owner { get; set; }
        public string Name { get; set; }
        public object Icon { get; set; }
        public virtual object Color { get; set; }
        public Tile Tile { get; set; }
        public List<Position> MoveSets { get; set; }

        // -1: infinite 
        public void AddMoveSet(Position moveSet)
        {
            var p= moveSet + this.Position;
            MoveSets.Add(p);
        }

        public delegate void Move(int x, int y);

        public virtual TileObject Clone()
        {
            var u = (TileObject)MemberwiseClone();
            u.Owner = this.Owner;
            u.Name = this.Name;
            u.Icon = this.Icon;

            u.Owner = this.Owner;
            return u;
        }
    }

    public enum MoveDirect { Positive, Negative, Both };
}
