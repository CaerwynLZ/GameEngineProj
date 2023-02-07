using FinalProject.Engine;
using FinalProject.Engine.Abstracts;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Client
{
    public class GameEngine : GameEngineCore
    {
        Tile tile;
        public GameEngine()
        {
            Renderer = new Renderer();
        }
        public void CreateBoard(int tileWidth, int tileHeight)
        {
            TileMap = new TileMap(tileWidth, tileHeight);
        }
        public void SetPlayers(Actor player1, Actor player2)
        {
            Actor1 = player1;
            Actor2 = player2;
        }
        public void SetUnit(TileObject tileObject)
        {
            if (tileObject.Owner == Actor1)
            {
                Actor1.TileObjects.Add(tileObject);
            }
            else if (tileObject.Owner == Actor2)
                Actor2.TileObjects.Add(tileObject);
        }
        public void RenderMap()
        {
            Renderer.RenderTileMap(TileMap);
        }
        public void AddPropertyOptions(string optionNumber, string describe)
        {
            PropertyOptions.Add(optionNumber, describe);
        }
        public bool ChooseTile(int x, int y)
        {
            TileMap.NextMoves.Clear();
            tile = TileMap.SelectTile(x, y);
            if (tile.TileObject != null)
            {
                MoveableOptions(tile.TileObject);
                return true;
            }
            else
            {
                TileMap.SelectedTile = null;
                return false;
            }
        }
        private void MoveableOptions(TileObject tileObject)
        {
            for (int i = 0; i < tileObject.MoveSets.Count; i++)
            {
                Position pos = tileObject.MoveSets[i] + tileObject.Position;
                if (pos.X >= 0 && pos.X < TileMap.Width && pos.Y >= 0 && pos.Y < TileMap.Height)
                {
                    TileMap.NextMoves.Add(TileMap[pos]);
                }
            }
        }
        public void MoveTo(int x, int y)
        {
            var givenPos = new Position(x - 1, y - 1);
            tile.TileObject.SetTile(TileMap[givenPos]);
            TileMap.SelectedTile = null;
            TileMap.NextMoves.Clear();
        }
        public void AddMenuOptions(string optionNumber, string describe)
        {
            Options.Add(optionNumber, describe);
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
