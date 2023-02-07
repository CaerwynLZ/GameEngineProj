using FinalProject.BoardClasses;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Engine.Abstracts
{
    public abstract class GameEngineCore
    {
        public virtual TileMap TileMap { get; set; }
        public virtual Actor Actor1 { get; set; }
        public virtual Actor Actor2 { get; set; }
        public IRenderer Renderer { get; set; }

        public Dictionary<string, string> Options = new Dictionary<string, string>();
        public Dictionary<string, string> PropertyOptions = new Dictionary<string, string>();

        //public virtual Action<Tile> Action { get; set; }

        //public TileObject PlaceTileObject(Tile tile, TileObject tileObject)
        //{
        //    //If a piece is placed on a void tile. make the tile into a board tile 
        //    if (tile.GetType() == typeof(TileObject))
        //    {
        //        tile = new BoardTile(tile.Position.X, tile.Position.Y);
        //        tile.TileObject = tileObject;
        //    }
        //    else
        //    {
        //        tile.TileObject = tileObject;
        //    }

        //    tileObject.Tile = tile;

        //    //Replace current tile with new tile
        //    TileMap[new Position(tile.Position.X, tile.Position.Y)] = tile;

        //    return tileObject;
        //}

        //public Tile PlaceTile(Tile selectedTile, Tile newTile)
        //{
        //    //Replace current tile with new tile
        //    TileMap[new Position(newTile.Position.X, newTile.Position.Y)] = newTile;

        //    return newTile;
        //}
    }
}
