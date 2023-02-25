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
        Tile _tile;
        Actor _enemy;
        Actor _playerInCheck;
        readonly Renderer _renderer;
        readonly List<TileObject> _objectsCheck;
        public Actor actor;

        public GameEngine()
        {
            _renderer = new Renderer();
            _objectsCheck = new List<TileObject>();
        }
        public override void SetTurn()
        {
            if (actor == Actor2)
            {
                actor = Actor1;
                _enemy = Actor2;
            }
            else
            {
                actor = Actor2;
                _enemy = Actor1;
            }
        }
        public override void RenderMap()
        {
            _renderer.RenderTileMap(TileMap);
        }

        /// <summary>
        /// adding number and sentence we want to show, that will be printed through RenderGameEngineOptions
        /// </summary>
        /// <param name="optionNumber"></param>
        /// <param name="describe"></param>
        public void AddPropertyOptions(string optionNumber, string describe)
        {
            PropertyOptions.Add(optionNumber, describe);
        }
        public void ResetPropertyOptions()
        {
            PropertyOptions.Clear();
        }
        public  void PrintOptions()
        {
            _renderer.RenderOptions(PropertyOptions);
        }
        public override bool ChooseTile(int x, int y)
        {
            TileMap.NextMoves.Clear();
            _tile = TileMap.SelectTile(x, y);
            if (_tile.TileObject != null && actor.TileObjects.Contains(_tile.TileObject))
            {
                if (MoveableOptions(_tile.TileObject))
                    return true;
                else
                {
                    DeselectTile();
                    return false;
                }

            }
            else
            {
                DeselectTile();
                return false;
            }
        }
        public string Check()
        {
            _objectsCheck.Clear();
            if (ActorCheck(Actor1))
            {
                _playerInCheck = Actor2;
                return Actor1.Name;
            }
            else if (ActorCheck(Actor2))
            {
                _playerInCheck = Actor1;
                return Actor2.Name;
            }
            else
                return "";
        }
        public override bool GameOver()
        {
            for(int i = 0; i < _playerInCheck.TileObjects.Count; i++)
            {
                TileObject tileObject = _playerInCheck.TileObjects[i];
                if(tileObject.Name=="King")
                {
                    continue;
                }
                if(MoveableOptions(tileObject))
                {
                    return false;
                }

            }
            return true;
        }
        /// <summary>
        /// Sees which player is Checking the king
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ActorCheck(Actor player)
        {
            for (int i = 0; i < player.TileObjects.Count; i++)
            {
                var enemyCheck = player.TileObjects[i];
                var enemyKing = enemyCheck.GiveMoves(TileMap);
                if (enemyKing != null)
                {
                    _objectsCheck.Add(enemyCheck);
                }
            }

            if(_objectsCheck.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
        public override void DeselectTile()
        {
            TileMap.SelectedTile = null;
            ResetPropertyOptions();
        }
        /// <summary>
        /// looks for how many objects are doing Check on king then checks if an object that you selected 
        /// is able to move in the position of the object's path that's checking the king
        /// </summary>
        /// <param name="tileObject"></param>
        /// <returns></returns>
        private bool MoveableOptions(TileObject tileObject)
        {
            tileObject.GiveMoves(TileMap);
            List<Tile> blockCheckPos = new List<Tile>();
            if (_objectsCheck.Count > 0)
            {
                for (int j = 0; j < _objectsCheck.Count; j++)
                {
                    for (int i = 0; i < TileMap.NextMoves.Count; i++)
                    {
                        Position pos = TileMap.NextMoves[i].Position;
                        if (InCheckPosition(pos, _objectsCheck[j]))
                        {
                            blockCheckPos.Add(TileMap.NextMoves[i]);
                        }
                    }
                } 
                if (blockCheckPos.Count > 0)
                {
                    TileMap.NextMoves= blockCheckPos;
                    return true;
                }
                else
                {
                    DeselectTile();
                    return false;
                }
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// implementing a way to check if a piece can go to where a piece is checking a king
        /// </summary>
        /// <param name="position"></param>
        /// <param name="enemyCheck"></param>
        /// <returns></returns>
        private bool InCheckPosition(Position position, TileObject enemyCheck)
        {
            for (int j = 0; j < enemyCheck.CheckablePosition.Count; j++)
            {
                Position p = enemyCheck.CheckablePosition[j];
                if (position.Equals(p))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if object can go to the chosen place, and if its a piece they can eat, otherwise Deselect
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            TileMap.NextMoves.Clear();
            _tile.TileObject.GiveMoves(TileMap);
            var givenPos = new Position(x - 1, y - 1);
            if (TileMap.NextMoves.Contains(TileMap[givenPos]))
            {
                if(TileMap[givenPos].TileObject!=null)
                {
                    EatObject(TileMap[givenPos], TileMap[givenPos].TileObject.Owner);
                }
                _tile.TileObject.SetTile(TileMap[givenPos]);
                DeselectTile();
            }
            else
            {
                DeselectTile();
            }
        }
        protected override void EatObject(Tile eaten, Actor actor)
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
    }
}
