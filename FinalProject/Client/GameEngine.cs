﻿using FinalProject.Engine;
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
        Actor actor;
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
            ActorStartTurn();
        }
        private void ActorStartTurn()
        {
            int turn= Random.Shared.Next(1, 3);
            if(turn == 1) 
            {
                actor = Actor1;
            }
            else
                actor= Actor2;
        }
        //public void SetTurn()
        //{
        //    actor == Actor1 ? Actor2; 
        //}
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
        public void PrintOptions()
        {
            Renderer.RenderOptions(PropertyOptions);
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
                DeselectTile();
                return false;
            }
        }
        public void DeselectTile()
        {
            TileMap.SelectedTile = null;
            PropertyOptions.Clear();
        }
        private void MoveableOptions(TileObject tileObject)
        {
            int enemyhold;
            for (int i = 0; i < tileObject.MoveSets.Count; i++)
            {
                enemyhold = 0;
                for (int j = 0; j < tileObject.MoveSets[i].Count; j++)
                {
                    Position pos = tileObject.MoveSets[i][j] + tileObject.Position;
                    if (pos.X >= 0 && pos.X < TileMap.Width && pos.Y >= 0 && pos.Y < TileMap.Height)
                    {
                        var enemyObj = TileMap[pos].TileObject;
                        if (enemyObj == null)
                        {
                            TileMap.NextMoves.Add(TileMap[pos]);
                        }
                        else
                        {
                            if (!enemyObj.Owner.Equals(tileObject.Owner) && enemyhold==0)
                            {
                                TileMap.NextMoves.Add(TileMap[pos]);
                                enemyhold = 1;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void MoveTo(int x, int y)
        {
            var givenPos = new Position(x - 1, y - 1);
            if (TileMap.NextMoves.Contains(TileMap[givenPos]))
            {
                if(TileMap[givenPos].TileObject!=null)
                {
                    EatObject(TileMap[givenPos], TileMap[givenPos].TileObject.Owner);
                }
                tile.TileObject.SetTile(TileMap[givenPos]);
                DeselectTile();
                TileMap.NextMoves.Clear();
            }
            else
            {
                DeselectTile();
            }
        }
        private void EatObject(Tile eaten, Actor actor)
        {
            actor.TileObjects.Remove(eaten.TileObject);
            eaten.TileObject = null;
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
