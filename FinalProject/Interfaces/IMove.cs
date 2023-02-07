using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Engine;

namespace FinalProject.Interfaces
{
    public interface IMove
    {
        public List<Position> MoveSets { get; set; }
        public void AddMoveSet(Position moveset);
    }
}
