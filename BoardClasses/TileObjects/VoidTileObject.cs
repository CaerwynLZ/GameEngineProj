using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BoardClasses
{
    //A void TileObject is a piece that doesn't have an owner or name. And doesn't need an x, y or tile
    public class VoidTileObject : TileObject
    {
        public VoidTileObject(object icon)
        {
            this.Icon = icon;
        }
    }
}
