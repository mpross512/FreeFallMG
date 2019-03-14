using System;
using Foundation;
using UIKit;
using FreeFall.Shared;

namespace FreeFall.iOS
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static FreeFallGame game;

        internal static void RunGame()
        {
            game = new FreeFallGame(FreeFallGame.Platform.IOS);
            game.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
