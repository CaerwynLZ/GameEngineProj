using FinalProject;
using FinalProject.Client;
using FinalProject.Engine;
using FinalProject.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Actor p1= new("Sam",ConsoleColor.Red);
        Actor p2 = new("Layan", ConsoleColor.Cyan);
        GameEngine engine = new();
        int x, y;
        int _progress;
        Awake();

        void Awake()
        {
            _progress = 0;

            engine.CreateBoard(8, 8);
            engine.SetPlayers(p1, p2);
            var map = engine.TileMap;
            engine.SetUnit(new Rook(p1, map[new Position(0, 0)]));
            engine.SetUnit(new Knight(p1, map[new Position(1, 0)]));
            engine.SetUnit(new Bishop(p1, map[new Position(2, 0)]));
            engine.SetUnit(new Queen(p1, map[new Position(3, 0)]));
            engine.SetUnit(new King(p1, map[new Position(4, 0)]));
            engine.SetUnit(new Bishop(p1, map[new Position(5, 0)]));
            engine.SetUnit(new Knight(p1, map[new Position(6, 0)]));
            engine.SetUnit(new Rook(p1, map[new Position(7, 0)]));
            engine.SetUnit(new Pawn(p1, map[new Position(0, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(1, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(2, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(3, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(4, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(5, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(6, 1)]));
            engine.SetUnit(new Pawn(p1, map[new Position(7, 1)]));


            engine.SetUnit(new Rook(p2, map[new Position(0, 7)]));
            engine.SetUnit(new Knight(p2, map[new Position(1, 7)]));
            engine.SetUnit(new Bishop(p2, map[new Position(2, 7)]));
            engine.SetUnit(new Queen(p2, map[new Position(3, 7)]));
            engine.SetUnit(new King(p2, map[new Position(4, 7)]));
            engine.SetUnit(new Bishop(p2, map[new Position(5, 7)]));
            engine.SetUnit(new Knight(p2, map[new Position(6, 7)]));
            engine.SetUnit(new Rook(p2, map[new Position(7, 7)]));
            engine.SetUnit(new Pawn(p2, map[new Position(0, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(1, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(2, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(3, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(4, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(5, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(6, 6)]));
            engine.SetUnit(new Pawn(p2, map[new Position(7, 6)]));

            PassTurn();
            Update();
        }

        void Update()
        {
            engine.RenderMap();
            if(WinCondition())
            {
                Win();
            }
            else
                Battle();
        }

        bool WinCondition()
        {
            if (engine.Check())
            {
                if (engine.CheckMate() == true)
                {
                    return true;
                }
                else
                {
                    engine.TileMap.NextMoves.Clear();
                    Console.WriteLine("Check");
                }
            }
            return false;
        }

        void Battle()
        {
            Console.WriteLine($"It's {engine.actor.Name}'s turn");
            switch (_progress)
            {
                case 0:
                    x = engine.GetConsoleInput<int>("Choose Tile X");
                    y = engine.GetConsoleInput<int>("Choose Tile Y");
                    if (x < engine.TileMap.Width && y < engine.TileMap.Height)
                    {
                        bool available = engine.ChooseTile(x, y);
                        if (available)
                            _progress++;
                        else
                            _progress = 0;
                        Update();
                    }
                    else
                        Reset();
                    break;
                case 1:
                    engine.AddPropertyOptions("1.", "To deselect");
                    engine.AddPropertyOptions("2", "To Choose Were to go");
                    engine.PrintOptions();
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            engine.DeselectTile();
                            Reset();
                            break;
                        case "2":
                            x = engine.GetConsoleInput<int>("Choose Where To Move X");
                            y = engine.GetConsoleInput<int>("Choose Where To Move Y");
                            engine.MoveTo(x, y);
                            PassTurn();
                            Reset();
                            break;
                        default:
                            engine.DeselectTile();
                            Reset();
                            break;
                    }
            
                    break;
                default:
                    Reset();
                    break;
            }
        }

        void PassTurn()
        {
            engine.SetTurn();
        }
        void Reset()
        {
            _progress = 0;
            Update();
        }
        void Win()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
        }
    }
}