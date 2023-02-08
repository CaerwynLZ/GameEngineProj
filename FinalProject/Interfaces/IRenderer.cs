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
        public void RenderOptions(Dictionary<string, string> options);
        public void RenderGame();
        public void RenderTileMap(TileMap tileMap);
    }
}
