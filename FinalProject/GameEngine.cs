using FinalProject.Client;
using FinalProject.Engine.Abstracts;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class GameEngine : GameEngineCore
    {
        Tile tile;
        public GameEngine()
        {
            this.Renderer = new Renderer();
        }    
        public void CreateBoard(int tileWidth,int tileHeight)
        {
            this.TileMap = new TileMap(tileWidth, tileHeight);
        }
        public void SetPlayers(Actor player1, Actor player2)
        {
            this.Actor1 = player1;
            this.Actor2 = player2;
        }
        public void SetUnit(TileObject tileObject)
        {
            if (tileObject.Owner == this.Actor1)
            {
                this.Actor1.TileObjects.Add(tileObject);
            }
            else if (tileObject.Owner == this.Actor2)
                this.Actor2.TileObjects.Add(tileObject);     
        }
        public void RenderMap()
        {
            this.Renderer.RenderTileMap(this.TileMap);
        }
        public void AddPropertyOptions(string optionNumber, string describe)
        {
            this.PropertyOptions.Add(optionNumber, describe);
        }
        public void ChooseTile(int x, int y)
        {
            this.TileMap.NextMoves.Clear();
            tile = this.TileMap.SelectTile(x, y);
            MoveableOptions(tile.TileObject);

        }
        private void MoveableOptions(TileObject tileObject)
        {
            for(int i=0; i<tileObject.MoveSets.Count; i++)
            {
                Position pos= tileObject.MoveSets[i]+tileObject.Position;
                if((pos.X>=0 && pos.X<this.TileMap.Width) && (pos.Y >=0 && pos.Y < this.TileMap.Height))
                {
                    this.TileMap.NextMoves.Add(this.TileMap[pos]);
                }
            }
        }
        public void MoveTo(int x, int y)
        {
            var givenPos = new Position(x-1, y-1);
            tile.TileObject.SetTile(this.TileMap[givenPos]);
            this.TileMap.SelectedTile = null;
            this.TileMap.NextMoves.Clear();
        }

        public void AddMenuOptions(string optionNumber, string describe)
        {
            this.Options.Add(optionNumber, describe);
        }

        public dynamic GetConsoleInput<T>(string command)
        {
            Console.WriteLine(command);
            if (typeof(T) == typeof(int))
            {
                return int.Parse(Console.ReadLine());
            }
            else if (typeof(T) == typeof(string))
            {
                return Console.ReadLine();
            }
            else
            {
                return false;
            }


        }


        //public void AddPropertyOptions(string optionNumber, string desc)
        //{
        //    this.PropertyOptions.Add("1", "Add Movement Set to TileObject");
        //}
        //public void AddMenuOptions()
        //{
        //    this.Options.Add("1", "Select a tile space (x , y)");
        //    this.Options.Add("2", "Deselect the current selection");
        //    this.Options.Add("3", "Add a TileObject on selection");
        //    this.Options.Add("4", "Delete a TileObject on selection");
        //    this.Options.Add("5", "Add Property to TileObject");
        //    this.Options.Add("6", "Place a Tile on a empty space or overwrite it");
        //}

    }
}
