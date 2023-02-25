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
        protected virtual Actor Actor1 { get; set; }
        protected virtual Actor Actor2 { get; set; }
        protected IRenderer Renderer { get; set; }
        protected Dictionary<string, string> Options = new Dictionary<string, string>();
        protected Dictionary<string, string> PropertyOptions = new Dictionary<string, string>();
        public virtual void CreateBoard(int tileWidth, int tileHeight) 
        {
            TileMap = new TileMap(tileWidth, tileHeight);
        }
        public virtual void RenderMap() { }
        public virtual void SetPlayers(Actor player1, Actor player2)
        {
            Actor1 = player1;
            Actor1.ID = 1;

            Actor2 = player2;
            Actor2.ID = 2;
        }
        public virtual void SetTurn() { }
        /// <summary>
        /// Adding objects to whatever player you want, so each one has their own sets
        /// </summary>
        /// <param name="tileObject"></param>
        public virtual void SetUnit(TileObject tileObject) 
        {
            if (tileObject.Owner == Actor1)
            {
                Actor1.TileObjects.Add(tileObject);
            }
            else if (tileObject.Owner == Actor2)
                Actor2.TileObjects.Add(tileObject);
        }
        public virtual bool ChooseTile(int x, int y) { return false; }
        public virtual void DeselectTile() { }
        public virtual void MoveTo(int x, int y) { }
        protected virtual void EatObject(Tile eaten, Actor actor) { }
        public virtual bool GameOver() { return false; }
    }
}
