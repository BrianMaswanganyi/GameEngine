using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class IGameExtender
    {
        public static void Start(this IGame game)
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
            if(game.GameObjects == null)
            {
                game.GameObjects = new GameEngine.GameObjectCollection();
            }

            foreach (var gameObject in game.GameObjects)
            {
                gameObject.Start();
            }
        }
    }
}
