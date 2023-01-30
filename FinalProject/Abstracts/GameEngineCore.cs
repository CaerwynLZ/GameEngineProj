using FinalProject.BoardClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Abstracts
{
    public abstract class GameEngineCore
    {
        public TileMap TileMap {get; set;}
        public Renderer Renderer {get; set;}
        public Dictionary<string, string> Options = new Dictionary<string, string>();
        public Dictionary<string, string> PropertyOptions = new Dictionary<string, string>();
        public TileObject PlaceTileObject(Tile tile, TileObject tileObject)
        {
            //If a piece is placed on a void tile. make the tile into a board tile 
            if(tile.GetType() == typeof(VoidTile))
            {
                tile = new BoardTile(tile.Position.X, tile.Position.Y);
                tile.TileObject = tileObject;
            }
            else
            {
                tile.TileObject = tileObject;
            }

            tileObject.Tile = tile;

            //Replace current tile with new tile
            TileMap[new Position(tile.Position.X, tile.Position.Y)] = tile;

            return tileObject;
        }

        public Tile PlaceTile(Tile selectedTile, Tile newTile)
        {
            //Replace current tile with new tile
            TileMap[new Position(newTile.Position.X, newTile.Position.Y)] = newTile;

            return newTile;
        }
    }
}
