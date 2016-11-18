using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class IGameExtender
    {
        public static void StartGame(this IGame game)
        {
            Input.Input.game = game;
            game.keyboardInput = new Input.KeyBoardInput();
            game.GameObjects = new GameEngine.GameObjectCollection();

            if (game.GameLoopThread == null)
            {
                ThreadStart mainLoopThreadStart = new ThreadStart(game.RunGameLoop);
                game.GameLoopThread = new Thread(mainLoopThreadStart);
                game.GameLoopThread.Start();
            }
            
        }

        private static void RunGameLoop(this IGame game)
        {
            do
            {
                game.Update();

            } while (game.IsGameEnded());
        }
        private static bool IsGameEnded(this IGame game)
        {
            return !game.ExitGame;
        }

        private static void Update(this IGame game)
        {
            foreach (var gameObject in game.GameObjects)
            {
                gameObject.Start();

                game.Scene
            }
        }
    }
}
