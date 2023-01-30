using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Player(int iD, string name)
        {
            this.ID = iD;
            this.Name = name;
        }
    }
}
