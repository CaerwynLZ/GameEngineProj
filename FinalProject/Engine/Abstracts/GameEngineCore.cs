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

    }
}
