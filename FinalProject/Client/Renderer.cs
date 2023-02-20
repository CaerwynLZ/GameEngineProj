using FinalProject.BoardClasses;
using FinalProject.Engine;
using FinalProject.Engine.Abstracts;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Client
{
    public class Renderer : IRenderer
    {
        Tile tile;
        TileMap tileMap;
        ConsoleColor placeholderColor;
        public void RenderMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public void RenderOptions(Dictionary<string, string> options)
        {
            if (options != null)
            {
                RenderGameEngineOptions(options);
            }
        }
        public void RenderGame()
        {

        }
        private void RenderGameEngineOptions(Dictionary<string, string> options)
        {
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            var count = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"{count}: " + option.Value);
                count++;
            }
            Console.WriteLine("");
            Console.Write("Enter your selection: ");
        }
        public void RenderTileMap(TileMap tileMap)
        {
            this.tileMap = tileMap;
            Console.Clear();
            for (int y = 0; y < tileMap.Height; y++)
            {
                if(y==0)
                {
                    Console.Write(" ");
                    for(int i=0; i<tileMap.Width; i++) 
                    {
                        Console.Write($" {i +1} ");
                    }
                    Console.WriteLine();
                }
                for (int x = 0; x < tileMap.Width; x++)
                {
                    if (x == 0) { Console.Write($"{y + 1}"); }
                    tile = tileMap[new Position(x, y)];

                    //Make selected tile red
                    placeholderColor = ConsoleColor.White;
                    PrintSelect();
                    PrintNextMoves();
                    Console.Write(tile.IconsSides[0]);

                    //Set Tile Color if it has one
                    if (tile.Color != null)
                        Console.BackgroundColor = (ConsoleColor)tile.Color;

                    PrintIcons();
                    PrintSelect();

                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write(tile.IconsSides[1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();

            }
        }

        private void PrintSelect()
        {
            if (tileMap.SelectedTile == tile)
            {
                placeholderColor = ConsoleColor.Red;
            }
            else if(tileMap.SelectedTile == null)
            {
                placeholderColor = ConsoleColor.White;
            }
            Console.ForegroundColor = placeholderColor;

        }
        private void PrintNextMoves()
        {
            if (tileMap.NextMoves.Contains(tile) && tileMap.SelectedTile != null)
            {
                placeholderColor = ConsoleColor.DarkGreen;
            }
            Console.ForegroundColor = placeholderColor;
        }
        private void PrintIcons()
        {
            if (tile.TileObject != null)
            {
                Console.ForegroundColor = (ConsoleColor)tile.TileObject.Color;
                Console.Write(tile.TileObject.Icon);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(" ");
            }
        }


        //public void RenderMenu()
        //{
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    Console.Clear();

        //    Console.WriteLine("Welcome to the console game engine menu!");
        //    Console.WriteLine("Please select an option:");
        //    Console.WriteLine("1. Create a new tilemap (width, height)");
        //    Console.WriteLine("2. Run the most recent game");
        //    Console.WriteLine("3. Load in the most recent saved tilemap");
        //    Console.Write("Enter your selection: ");

        //    string input = Console.ReadLine();

        //    switch (input)
        //    {
        //        case "1":
        //            Console.Write("Enter the width of the tilemap: ");
        //            int width = GetConsoleInput<int>();
        //            Console.Write("Enter the height of the tilemap: ");
        //            int height = GetConsoleInput<int>();

        //            //Start a new Game Engine instance, Also render it.
        //            RenderGameEngine(new GameEngine(width, height));
        //            break;
        //        case "2":
        //            break;
        //        case "3":
        //            break;
        //        default:
        //            Console.WriteLine("Invalid selection. Please try again.");
        //            break;
        //    }
        //}

        //public void RenderGameEngine(GameEngineCore gameEngine, Dictionary<string, string> options = null)
        //{
        //    Console.Clear();

        //    RenderTileMap(gameEngine.TileMap);
        //    if (options == null) RenderGameEngineOptions(gameEngine.Options);
        //    else RenderGameEngineOptions(options);

        //    string input = GetConsoleInput<string>();

        //    while (true)
        //    {
        //        switch (input)
        //        {
        //            case "1":
        //                Console.Write("Enter the x of the tilemap: ");
        //                int x = GetConsoleInput<int>();
        //                Console.Write("Enter the y of the tilemap: ");
        //                int y = GetConsoleInput<int>();

        //                gameEngine.TileMap.SelectTile(x, y);
        //                RenderGameEngine(gameEngine);
        //                break;
        //            case "2":
        //                gameEngine.TileMap.DeselectTile();
        //                RenderGameEngine(gameEngine);
        //                break;
        //            case "3":
        //                if (gameEngine.TileMap.SelectedTile != null)
        //                {
        //                    var tileObject = gameEngine.PlaceTileObject(gameEngine.TileMap.SelectedTile, new VoidTileObject("V"));
        //                    gameEngine.TileMap.SelectedTile = tileObject.Tile;
        //                }

        //                RenderGameEngine(gameEngine);
        //                break;
        //            case "4":
        //                //Delete tile object
        //                break;
        //            case "5":
        //                if (gameEngine.TileMap.SelectedTile != null)
        //                {
        //                    //Add properties to tileobject
        //                    Console.WriteLine("1: Add Move Set");
        //                    input = GetConsoleInput<string>();

        //                    switch (input)
        //                    {
        //                        case "1":
        //                            //Add moveset to selected tileObject
        //                            bool ShouldStop = false;
        //                            while (!ShouldStop)
        //                            {
        //                                Console.WriteLine("Input a movementset in the format (ux,rx,dx,lx,ulx,urx,dlx,drx) with x being infinite and 0 being none.");
        //                                input = GetConsoleInput<string>();
        //                                var parameters = input.Split(",");

        //                                var tileObject = gameEngine.TileMap.SelectedTile.TileObject;
        //                                //tileObject.AddMoveSet(new MoveSet()
        //                                //{
        //                                //    Left = parameters[0].Last() == 'x' ? -1 : parameters[0].Last(),
        //                                //    Right = parameters[1].Last() == 'x' ? -1 : parameters[1].Last(),
        //                                //    Up = parameters[2].Last() == 'x' ? -1 : parameters[2].Last(),
        //                                //    Down = parameters[3].Last() == 'x' ? -1 : parameters[3].Last(),
        //                                //    UpLeft = parameters[4].Last() == 'x' ? -1 : parameters[4].Last(),
        //                                //    UpRight = parameters[5].Last() == 'x' ? -1 : parameters[5].Last(),
        //                                //    DownLeft = parameters[6].Last() == 'x' ? -1 : parameters[6].Last(),
        //                                //    DownRight = parameters[7].Last() == 'x' ? -1 : parameters[7].Last(),
        //                                //});

        //                                Console.WriteLine("Do you want to add another move set to the object?");
        //                                input = GetConsoleInput<string>();
        //                                if (input.ToLower() == "no") ShouldStop = true;
        //                            }

        //                            break;
        //                        default:
        //                            Console.WriteLine("Invalid selection. Please try again.");
        //                            break;
        //                    }
        //                }

        //                RenderGameEngine(gameEngine);
        //                break;
        //            case "6":
        //                if (gameEngine.TileMap.SelectedTile != null)
        //                {
        //                    var tile = gameEngine.PlaceTile(gameEngine.TileMap.SelectedTile, new BoardTile(gameEngine.TileMap.SelectedTile.Position.X, gameEngine.TileMap.SelectedTile.Position.Y));
        //                    gameEngine.TileMap.SelectedTile = tile;
        //                }
        //                RenderGameEngine(gameEngine);
        //                break;
        //            case "7":
        //                //Return to main menu
        //                break;
        //            default:
        //                Console.WriteLine("Invalid selection. Please try again.");
        //                break;
        //        }
        //    }
        //}

        //public void RenderGame()
        //{
        //    //Will render the game board when a game starts
        //}

        //private void RenderTileMap(TileMap tileMap)
        //{
        //    for (int y = 0; y < tileMap.Height; y++)
        //    {
        //        for (int x = 0; x < tileMap.Width; x++)
        //        {
        //            var tile = tileMap[new Position(x, y)];

        //            //Make selected tile red
        //            var placeholderColor = ConsoleColor.White;
        //            if (tileMap.SelectedTile == tile) placeholderColor = ConsoleColor.Red;
        //            Console.ForegroundColor = placeholderColor;

        //            Console.Write("[");

        //            //Set Tile Color if it has one
        //            if (tile.Color != null) Console.BackgroundColor = (ConsoleColor)tile.Color;

        //            //Input tile object if tile contains one
        //            if (tile.TileObject != null)
        //            {
        //                Console.Write(tile.TileObject.Icon.ToString());
        //            }
        //            else
        //            {
        //                Console.Write(" ");
        //            }

        //            Console.BackgroundColor = ConsoleColor.Black;

        //            Console.Write("]");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //private void RenderGameEngineOptions(Dictionary<string, string> options)
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("Please select an option:");
        //    Console.WriteLine("");
        //    var count = 1;
        //    foreach (var option in options)
        //    {
        //        Console.WriteLine($"{count}: " + option.Value);
        //        count++;
        //    }
        //    Console.WriteLine($"{count}: Back");
        //    Console.WriteLine("");
        //    Console.Write("Enter your selection: ");
        //}

        ////Makes sure input data is valid
        //public dynamic GetConsoleInput<T>()
        //{
        //    if (typeof(T) == typeof(int))
        //    {
        //        return int.Parse(Console.ReadLine());
        //    }
        //    else if (typeof(T) == typeof(string))
        //    {
        //        return Console.ReadLine();
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
