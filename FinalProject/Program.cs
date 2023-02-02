using FinalProject;
using FinalProject.Engine.Abstracts;
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Actor p1= new Actor(1,"Sam",ConsoleColor.Red);
        List<Position> moveTo= new List<Position>();

        GameEngine engine = new GameEngine();
        void Awake()
        {
            engine.CreateBoard(8, 8);
            engine.CreateUnit();
        }
        // Start a new Game Engine
        var renderer = new Renderer();
        renderer.RenderMenu();
    }
}