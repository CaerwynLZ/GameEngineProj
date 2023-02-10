using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Engine.Abstracts
{
    public class Actor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual object Color { get; set; }
        public virtual List<TileObject> TileObjects { get; set; }

        public Actor(string name, ConsoleColor color)
        {
            Name = name;
            Color = color;
            TileObjects = new List<TileObject>();
        }
    }
}
