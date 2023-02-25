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
        Tile _tile;
        TileMap _tileMap;
        ConsoleColor _placeholderColor;
        TileObject _check;

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
        /// <summary>
        /// automatically adds number to any future option given
        /// </summary>
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
            this._tileMap = tileMap;
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
                    _tile = tileMap[new Position(x, y)];

                    //Make selected tile red
                    _placeholderColor = ConsoleColor.White;
                    PrintSelect();

                    //Print object possible moves
                    PrintNextMoves();
                    Console.Write(_tile.IconsSides[0]);

                    //Set Tile Color if it has one
                    if (_tile.Color != null)
                        Console.BackgroundColor = (ConsoleColor)_tile.Color;

                    PrintIcons();
                    PrintSelect();

                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write(_tile.IconsSides[1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();

            }
        }

        private void PrintSelect()
        {
            if (_tileMap.SelectedTile == _tile)
            {
                _placeholderColor = ConsoleColor.Magenta;
            }
            else if(_tileMap.SelectedTile == null)
            {
                _placeholderColor = ConsoleColor.White;
            }
            Console.ForegroundColor = _placeholderColor;
        }

        private void PrintNextMoves()
        {
            if (_tileMap.NextMoves.Contains(_tile) && _tileMap.SelectedTile != null)
            {

                _placeholderColor = ConsoleColor.DarkGreen;
            }
            Console.ForegroundColor = _placeholderColor;
        }

        private void PrintIcons()
        {
            if (_tile.TileObject != null)
            {
                Console.ForegroundColor = (ConsoleColor)_tile.TileObject.Color;
                Console.Write(_tile.TileObject.Icon);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}
