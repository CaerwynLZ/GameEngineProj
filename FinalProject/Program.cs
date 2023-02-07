using FinalProject;
using FinalProject.Client;
using FinalProject.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Actor p1= new Actor(1,"Sam",ConsoleColor.Red);
        Actor p2 = new Actor(2, "Layan", ConsoleColor.Cyan);
        GameEngine engine = new GameEngine();
        int x, y;
        int progress;
        Awake();

        void Awake()
        {
            progress = 0;

            engine.CreateBoard(8, 8);
            engine.SetPlayers(p1, p2);
            var map = engine.TileMap;
            engine.SetUnit(new BoardTileObject(p1,map[new Position(0,0)]));
            engine.SetUnit(new BoardTileObject(p1, map[new Position(2, 0)]));
            engine.SetUnit(new BoardTileObject(p1, map[new Position(4, 0)]));
            engine.SetUnit(new BoardTileObject(p1, map[new Position(6, 0)]));

            engine.SetUnit(new Castle(p2, map[new Position(0, 7)]));                                       
            engine.SetUnit(new BoardTileObject(p2, map[new Position(7, 7)]));
            engine.SetUnit(new BoardTileObject(p2, map[new Position(5, 7)]));
            engine.SetUnit(new BoardTileObject(p2, map[new Position(3, 7)]));
            engine.SetUnit(new BoardTileObject(p2, map[new Position(1, 7)]));

            Update();
        }

        void Update()
        {
            engine.RenderMap();
            Battle();
        }

        void Battle()
        {
            switch (progress)
            {
                case 0:
                    x = engine.GetConsoleInput<int>("Choose Tile X");
                    y = engine.GetConsoleInput<int>("Choose Tile Y");
                    engine.ChooseTile(x, y);
                    progress++;
                    Update();
                    break;
                case 1:
                    x = engine.GetConsoleInput<int>("Choose Where To Move X");
                    y = engine.GetConsoleInput<int>("Choose Where To Move Y");
                    engine.MoveTo(x,y);
                    progress = 0;
                    Update();
                    break;
                    default:
                    progress=0;
                    Update();
                    break;
            }
        }
        // Start a new Game Engine
        //var renderer = new Renderer();
        //renderer.RenderMenu();
    }
}