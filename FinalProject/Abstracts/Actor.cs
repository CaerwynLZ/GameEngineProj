using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Actor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual object Color { get; set; }
        public virtual List<TileObject> TileObjects { get; set; }

        public Actor(int iD, string name, ConsoleColor color, List<TileObject> tileObjects)
        {
            this.ID = iD;
            this.Name = name;
            this.Color = color;
            this.TileObjects = tileObjects;
        }
    }
}
