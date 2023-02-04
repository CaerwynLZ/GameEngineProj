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

        Awake();

        void Awake()
        {
            engine.CreateBoard(8, 8);
            engine.SetPlayers(p1, p2);
            engine.SetUnit(new BoardTileObject(p1,engine.TileMap[new Position(0,0)]));
            engine.SetUnit(new BoardTileObject(p1, engine.TileMap[new Position(2, 0)]));
            engine.SetUnit(new BoardTileObject(p1, engine.TileMap[new Position(4, 0)]));
            engine.SetUnit(new BoardTileObject(p1, engine.TileMap[new Position(6, 0)]));

            engine.SetUnit(new BoardTileObject(p2, engine.TileMap[new Position(7, 7)]));
            engine.SetUnit(new BoardTileObject(p2, engine.TileMap[new Position(5, 7)]));
            engine.SetUnit(new BoardTileObject(p2, engine.TileMap[new Position(3, 7)]));
            engine.SetUnit(new BoardTileObject(p2, engine.TileMap[new Position(1, 7)]));
        }

        void Battle()
        {
            bool exit=false;
            while(exit==false)
            {
                engine.RenderMap();
                Console.WriteLine("Select Tile");

            }
        }
        // Start a new Game Engine
        //var renderer = new Renderer();
        //renderer.RenderMenu();
    }
}