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
        public Player Owner { get; set; }
        public string Name { get; set; }
        public object Icon { get; set; }
        public Tile Tile { get; set; }
        public List<MoveSet> MoveSets { get; set; }

        public TileObject()
        {

        }
        
        // -1: infinite 
        public void AddMoveSet(MoveSet moveSet)
        {
            MoveSets.Add(moveSet);
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
