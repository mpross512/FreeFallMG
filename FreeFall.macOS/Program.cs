using System;
using FreeFall.Shared;


namespace FreeFall.macOS
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new FreeFallGame(FreeFallGame.Platform.MAC))
            {
                game.IsMouseVisible = true;
                game.Window.AllowUserResizing = true;
                //game.Window.Title = "FreeFall";
                game.Run();
            }
        }
    }
}
