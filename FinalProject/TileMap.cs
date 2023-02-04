using FinalProject.BoardClasses;
using FinalProject.Engine.Abstracts;
using FinalProject.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TileMap : IEnumerable<Tile>
    {
        private Tile[,] Tiles { get; set; }  
        public Tile? SelectedTile { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // The Tilemap must implement an indexer for IPosition
        // This will let you access Tiles while tiles can be private by TileMap[new Position(x, y)]
        public Tile this[Position position]
        {
            get => Tiles[position.X, position.Y];
            set => Tiles[position.X, position.Y] = value;
        }

        public TileMap(int width, int height)
        {
            Width = width;            
            Height = height;
            Tiles = new Tile[height, width];

            //Fill the TileMap with void tiles
            //Void tiles are tiles that only have locations and no owners or tileObjects on them.
            for(var y = 0; y < height; y++)
            {
                for(var x = 0; x < width; x++)
                {
                    Tiles[x, y] = new VoidTile(x, y);
                }
            }
        }

        public Tile SelectTile(int x, int y)
        {
            SelectedTile = Tiles[x - 1, y - 1];
            return SelectedTile;
        }

        public void DeselectTile()
        {
            SelectedTile = null;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            return new SpiralEnumerator(Tiles, Width, Height);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class SpiralEnumerator : IEnumerator<Tile>
    {
        private Tile[,] _map;
        private int _width;
        private int _height;
        private int _x;
        private int _y;
        private int _direction;
        private int _steps;
        private bool _isFirst;

        public SpiralEnumerator(Tile[,] map, int width, int height)
        {
            _map = map;
            _width = width;
            _height = height;
            _x = 0;
            _y = -1;
            _direction = 0;
            _steps = 1;
            _isFirst = true;
        }

        public Tile Current
        {
            get { return _map[_y, _x]; }
        }

        object IEnumerator.Current => Current;
        public void Dispose() { }
        
        public bool MoveNext()
        {
            if (_isFirst)
            {
                _isFirst = false;
                return true;
            }

            switch (_direction)
            {
                case 0: _x++; break;
                case 1: _y++; break;
                case 2: _x--; break;
                case 3: _y--; break;
            }

            _steps--;
            if (_steps == 0)
            {
                _direction = (_direction + 1) % 4;
                if (_direction == 0 || _direction == 2) _steps++;
            }

            return (_x >= 0 && _x < _width);
        }

        public void Reset() { }
    }
}
