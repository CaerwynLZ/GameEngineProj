using FinalProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Interfaces
{
    public interface IRenderer
    {
        public void RenderMenu();
        //public void RenderGameEngine(GameEngineCore gameEngine, Dictionary<string, string> options);
        public void RenderGameEngine(Dictionary<string, string> options);
        public void RenderGame();
    }
}
