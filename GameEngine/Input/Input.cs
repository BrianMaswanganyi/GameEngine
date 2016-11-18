using System;
namespace GameEngine.Input
{
    public class Input
    {

        internal static IGame game;
        public static bool Key(KeyStrokes checkkey)
        {
            return checkkey == game.keyboardInput.LastKeyPressed;   
        }
    }
}
