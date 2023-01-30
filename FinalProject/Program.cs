using FinalProject;

internal class Program
{
    private static void Main(string[] args)
    {
        GameEngine engine = new GameEngine();
        void Start()
        {
            engine.CreateBoard(8, 8);
        }
        // Start a new Game Engine
        var renderer = new Renderer();
        renderer.RenderMenu();
    }
}