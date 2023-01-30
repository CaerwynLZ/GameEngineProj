using FinalProject.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class GameEngine : GameEngineCore
    {
        public GameEngine(int tileWidth, int tileHeight)
        {
            this.TileMap = new TileMap(tileWidth, tileHeight);
            AddMenuOptions();
            AddPropertyOptions();
        }    

        public void AddPropertyOptions()
        {
            this.PropertyOptions.Add("1", "Add Movement Set to TileObject");
        }

        public void AddMenuOptions()
        {
            this.Options.Add("1", "Select a tile space (x , y)");
            this.Options.Add("2", "Deselect the current selection");
            this.Options.Add("3", "Add a TileObject on selection");
            this.Options.Add("4", "Delete a TileObject on selection");
            this.Options.Add("5", "Add Property to TileObject");
            this.Options.Add("6", "Place a Tile on a empty space or overwrite it");
        }
    }
}
